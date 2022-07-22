using Maryland.DataTypes;
using Maryland.PatchInstructions;
using System.Collections.Immutable;
using System.Numerics;
using System.Text;

namespace Maryland.Databases
{
    /// <summary>
    /// An instance of the Maryland database.
    /// </summary>
    public sealed class Database : IDatabase
    {
        private struct EntityAttributePair
        {
            public readonly Guid Entity;
            public readonly Guid Attribute;

            public EntityAttributePair(Guid entity, Guid attribute)
            {
                Entity = entity;
                Attribute = attribute;
            }
        }

        private readonly HashSet<EntityAttributePair> SetFlags = new();
        private readonly HashSet<EntityAttributePair> ClearFlags = new();
        private readonly Dictionary<EntityAttributePair, float> Floats = new();
        private readonly Dictionary<EntityAttributePair, Guid> ReferenceForward = new();
        private readonly Dictionary<EntityAttributePair, HashSet<Guid>> ReferenceInverse = new();
        private readonly Dictionary<EntityAttributePair, string> Strings = new();
        private readonly Dictionary<Guid, string> Tags = new();
        private readonly Dictionary<EntityAttributePair, Color> Colors = new();
        private readonly Dictionary<EntityAttributePair, Image> Images = new();
        private readonly Dictionary<EntityAttributePair, Mesh> Meshes = new();

        /// <inheritdoc />
        public IEnumerable<IInstruction> Patch => SetFlags
            .Select(flag => new SetFlag(flag.Entity, flag.Attribute))
            .Cast<IInstruction>()
            .Concat(ClearFlags.Select(flag => new ClearFlag(flag.Entity, flag.Attribute)))
            .Concat(Floats.Select(kv => new SetFloat(kv.Key.Entity, kv.Key.Attribute, kv.Value)))
            .Concat(ReferenceForward.Select(kv => new SetReference(kv.Key.Entity, kv.Key.Attribute, kv.Value)))
            .Concat(Strings.Select(kv => new SetString(kv.Key.Entity, kv.Key.Attribute, kv.Value)))
            .Concat(Tags.Select(kv => new SetTag(kv.Key, kv.Value)))
            .Concat(Colors.Select(kv => new SetColor(kv.Key.Entity, kv.Key.Attribute, kv.Value)))
            .Concat(Images.Select(kv => new SetImage(kv.Key.Entity, kv.Key.Attribute, kv.Value)));

        /// <inheritdoc />
        public void ClearFlag(Guid entity, Guid attribute)
        {
            var key = new EntityAttributePair(entity, attribute);

            SetFlags.Remove(key);
            ClearFlags.Add(key);
        }

        /// <inheritdoc />
        public bool GetFlag(Guid entity, Guid attribute)
        {
            var key = new EntityAttributePair(entity, attribute);

            return SetFlags.Contains(key);
        }

        /// <inheritdoc />
        public float GetFloat(Guid entity, Guid attribute)
        {
            Floats.TryGetValue(new EntityAttributePair(entity, attribute), out var value);
            return value;
        }

        /// <inheritdoc />
        public Guid GetReference(Guid entity, Guid attribute)
        {
            ReferenceForward.TryGetValue(new EntityAttributePair(entity, attribute), out var value);
            return value;
        }

        /// <inheritdoc />
        public IEnumerable<Guid> GetReferrers(Guid attribute, Guid entity)
        {
            if (ReferenceInverse.TryGetValue(new EntityAttributePair(entity, attribute), out var referrers))
            {
                return referrers;
            }
            else
            {
                return Enumerable.Empty<Guid>();
            }
        }

        /// <inheritdoc />
        public string GetString(Guid entity, Guid attribute)
        {
            if (Strings.TryGetValue(new EntityAttributePair(entity, attribute), out var value))
            {
                return value;
            }
            else
            {
                return string.Empty;
            }
        }

        /// <inheritdoc />
        public string GetTag(Guid identifier)
        {
            if (Tags.TryGetValue(identifier, out var value))
            {
                return value;
            }
            else
            {
                return identifier.ToString("N");
            }
        }

        /// <inheritdoc />
        public void SetFlag(Guid entity, Guid attribute)
        {
            var key = new EntityAttributePair(entity, attribute);

            SetFlags.Add(key);
            ClearFlags.Remove(key);
        }

        /// <inheritdoc />
        public void SetFloat(Guid entity, Guid attribute, float value)
        {
            Floats[new EntityAttributePair(entity, attribute)] = value;
        }

        /// <inheritdoc />
        public void SetReference(Guid entity, Guid attribute, Guid value)
        {
            var forwardKey = new EntityAttributePair(entity, attribute);
            var inverseKey = new EntityAttributePair(value, attribute);

            if (ReferenceForward.TryGetValue(forwardKey, out var existingValue))
            {
                if (value == existingValue)
                {
                    return;
                }
                else
                {
                    var existingInverseKey = new EntityAttributePair(existingValue, attribute);

                    var existingReferenceInverse = ReferenceInverse[existingInverseKey];

                    if (existingReferenceInverse.Count > 1)
                    {
                        existingReferenceInverse.Remove(entity);
                    }
                    else
                    {
                        ReferenceInverse.Remove(existingInverseKey);
                    }
                }
            }

            ReferenceForward[forwardKey] = value;

            if (ReferenceInverse.TryGetValue(inverseKey, out var referenceInverse))
            {
                referenceInverse.Add(entity);
            }
            else
            {
                ReferenceInverse[inverseKey] = new HashSet<Guid> { entity };
            }
        }

        /// <inheritdoc />
        public void SetString(Guid entity, Guid attribute, string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }
            else if (Encoding.UTF8.GetByteCount(value) > 65535)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "Cannot exceed 65535 bytes in length when encoded as UTF-8.");
            }
            else
            {
                Strings[new EntityAttributePair(entity, attribute)] = value;
            }
        }

        /// <inheritdoc />
        public void SetTag(Guid identifier, string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(nameof(value), "Value cannot be null or empty.");
            }
            else if (Encoding.UTF8.GetByteCount(value) > 255)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "Cannot exceed 255 bytes in length when encoded as UTF-8.");
            }
            else
            {
                Tags[identifier] = value;
            }
        }

        /// <inheritdoc />
        public void Apply(IDatabase to)
        {
            foreach (var flag in SetFlags)
            {
                to.SetFlag(flag.Entity, flag.Attribute);
            }

            foreach (var flag in ClearFlags)
            {
                to.ClearFlag(flag.Entity, flag.Attribute);
            }

            foreach (var kv in Floats)
            {
                to.SetFloat(kv.Key.Entity, kv.Key.Attribute, kv.Value);
            }

            foreach (var kv in ReferenceForward)
            {
                to.SetReference(kv.Key.Entity, kv.Key.Attribute, kv.Value);
            }

            foreach (var kv in Strings)
            {
                to.SetString(kv.Key.Entity, kv.Key.Attribute, kv.Value);
            }

            foreach (var kv in Tags)
            {
                to.SetTag(kv.Key, kv.Value);
            }

            foreach (var kv in Colors)
            {
                to.SetColor(kv.Key.Entity, kv.Key.Attribute, kv.Value);
            }

            foreach (var kv in Images)
            {
                to.SetImage(kv.Key.Entity, kv.Key.Attribute, kv.Value);
            }
        }

        /// <inheritdoc />
        public void Clear()
        {
            SetFlags.Clear();
            ClearFlags.Clear();
            Floats.Clear();
            ReferenceForward.Clear();
            ReferenceInverse.Clear();
            Strings.Clear();
            Tags.Clear();
            Colors.Clear();
            Images.Clear();
        }

        /// <inheritdoc />
        public Color GetColor(Guid entity, Guid attribute)
        {
            Colors.TryGetValue(new EntityAttributePair(entity, attribute), out var value);
            return value;
        }

        /// <inheritdoc />
        public void SetColor(Guid entity, Guid attribute, Color value)
        {
            Colors[new EntityAttributePair(entity, attribute)] = value;
        }

        private static readonly Image DefaultImage = new(1, ImmutableArray.Create(default(ColorWithOpacity)));

        /// <inheritdoc />
        public Image GetImage(Guid entity, Guid attribute)
        {
            if (Images.TryGetValue(new EntityAttributePair(entity, attribute), out var value))
            {
                return value;
            }
            else
            {
                return DefaultImage;
            }
        }

        /// <inheritdoc />
        public void SetImage(Guid entity, Guid attribute, Image value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }
            else
            {
                Images[new EntityAttributePair(entity, attribute)] = value;
            }
        }

        private static readonly Mesh DefaultMesh = new
        (
            ImmutableSortedSet.Create(Guid.Empty),
            ImmutableArray.Create<byte>(0),
            ImmutableArray.Create(default(Vector3)),
            null,
            null,
            null,
            ImmutableArray.Create<byte>(0),
            ImmutableArray.Create(default(Vector3)),
            null,
            null,
            null,
            ImmutableArray.Create<byte>(0),
            ImmutableSortedDictionary<Guid, ImmutableArray<Vector2>>.Empty,
            ImmutableSortedDictionary<Guid, ImmutableArray<ColorWithOpacity>>.Empty,
            ImmutableArray.Create<ushort>(0, 0, 0)
        );

        /// <inheritdoc />
        public Mesh GetMesh(Guid entity, Guid attribute)
        {
            if (Meshes.TryGetValue(new EntityAttributePair(entity, attribute), out var value))
            {
                return value;
            }
            else
            {
                return DefaultMesh;
            }
        }

        /// <inheritdoc />
        public void SetMesh(Guid entity, Guid attribute, Mesh value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }
            else
            {
                Meshes[new EntityAttributePair(entity, attribute)] = value;
            }
        }
    }
}
