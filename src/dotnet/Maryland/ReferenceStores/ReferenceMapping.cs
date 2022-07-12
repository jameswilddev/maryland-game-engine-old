namespace Maryland.ReferenceStores
{
    /// <summary>
    /// Describes an entity/attribute identifier pair, and the value identifier it maps to.
    /// </summary>
    public struct ReferenceMapping
    {
        /// <summary>
        /// The identifier of the entity.
        /// </summary>
        public readonly Guid Entity;

        /// <summary>
        /// The identifier of the attribute.
        /// </summary>
        public readonly Guid Attribute;

        /// <summary>
        /// The identifier of the value.
        /// </summary>
        public readonly Guid Value;

        /// <summary>
        /// Creates a new entity/attribute identifier pair, withe value identifier it maps to.
        /// </summary>
        /// <param name="entity">The identifier of the entity.</param>
        /// <param name="attribute">The identifier of the attribute.</param>
        /// <param name="value">The identifier of the value.</param>
        public ReferenceMapping(Guid entity, Guid attribute, Guid value)
        {
            if (value == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(value));
            }
            else
            {
                Entity = entity;
                Attribute = attribute;
                Value = value;
            }
        }

        /// <summary>
        /// Throws an <see cref="InvalidOperationException"/> should <see langword="this"/> <see cref="ReferenceMapping"/> be uninitialized.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown when <see langword="this"/> <see cref="ReferenceMapping"/> is uninitialized.</exception>
        public void ThrowIfUninitialized()
        {
            if (Value == Guid.Empty)
            {
                throw new InvalidOperationException("ReferenceMapping uninitialized.");
            }
        }
    }
}
