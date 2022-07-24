using Maryland.DataTypes;
using System.Text;

namespace Maryland.PatchInstructions
{
    /// <summary>
    /// Deserializes <see cref="IInstruction"/>s from <see cref="byte"/> streams.
    /// </summary>
    public sealed class PatchInstructionDeserializer : IPatchInstructionDeserializer
    {
        /// <inheritdoc />
        public async IAsyncEnumerable<IInstruction> Deserialize(IAsyncEnumerable<byte> bytes)
        {
            if (bytes == null)
            {
                throw new ArgumentNullException(nameof(bytes));
            }
            else
            {
                var enumerator = bytes.GetAsyncEnumerator();

                while (await enumerator.MoveNextAsync())
                {
                    switch (enumerator.Current)
                    {
                        case 0:
                            {
                                var entity = await Maryland.Deserialize.Guid(enumerator, "Unexpected EOF during entity in set reference instruction.");
                                var attribute = await Maryland.Deserialize.Guid(enumerator, "Unexpected EOF during attribute in set reference instruction.");
                                var value = await Maryland.Deserialize.Guid(enumerator, "Unexpected EOF during value in set reference instruction.");
                                yield return new SetReference(entity, attribute, value);
                                break;
                            }

                        case 1:
                            {
                                var entity = await Maryland.Deserialize.Guid(enumerator, "Unexpected EOF during entity in set string instruction.");
                                var attribute = await Maryland.Deserialize.Guid(enumerator, "Unexpected EOF during attribute in set string instruction.");
                                var length = await Maryland.Deserialize.U16(enumerator, "Unexpected EOF during value length in set string instruction.");
                                var value = await Maryland.Deserialize.MutableBytes(enumerator, length, "Unexpected EOF during value content in set string instruction.");
                                yield return new SetString(entity, attribute, Encoding.UTF8.GetString(value));
                                break;
                            }

                        case 2:
                            {
                                var entity = await Maryland.Deserialize.Guid(enumerator, "Unexpected EOF during entity in set float instruction.");
                                var attribute = await Maryland.Deserialize.Guid(enumerator, "Unexpected EOF during attribute in set float instruction.");
                                var value = await Maryland.Deserialize.F32(enumerator, "Unexpected EOF during value in set float instruction.");
                                yield return new SetFloat(entity, attribute, value);
                                break;
                            }

                        case 3:
                            {
                                var entity = await Maryland.Deserialize.Guid(enumerator, "Unexpected EOF during entity in set flag instruction.");
                                var attribute = await Maryland.Deserialize.Guid(enumerator, "Unexpected EOF during attribute in set flag instruction.");
                                yield return new SetFlag(entity, attribute);
                                break;
                            }

                        case 4:
                            {
                                var entity = await Maryland.Deserialize.Guid(enumerator, "Unexpected EOF during entity in clear flag instruction.");
                                var attribute = await Maryland.Deserialize.Guid(enumerator, "Unexpected EOF during attribute in clear flag instruction.");
                                yield return new ClearFlag(entity, attribute);
                                break;
                            }

                        case 5:
                            {
                                var identifier = await Maryland.Deserialize.Guid(enumerator, "Unexpected EOF during identifier in set tag instruction.");
                                var length = await Maryland.Deserialize.Byte(enumerator, "Unexpected EOF during value length in set tag instruction.");

                                if (length == 0)
                                {
                                    throw new InvalidDataException("Set tag instruction has empty value.");
                                }

                                var value = await Maryland.Deserialize.MutableBytes(enumerator, length, "Unexpected EOF during value content in set tag instruction.");
                                yield return new SetTag(identifier, Encoding.UTF8.GetString(value));
                                break;
                            }

                        case 6:
                            {
                                var entity = await Maryland.Deserialize.Guid(enumerator, "Unexpected EOF during entity in set color instruction.");
                                var attribute = await Maryland.Deserialize.Guid(enumerator, "Unexpected EOF during attribute in set color instruction.");
                                var value = await Maryland.Deserialize.Color(enumerator, "Unexpected EOF during attribute in set color instruction.");
                                yield return new SetColor(entity, attribute, value);
                                break;
                            }

                        case 7:
                            {
                                var entity = await Maryland.Deserialize.Guid(enumerator, "Unexpected EOF during entity in set image instruction.");
                                var attribute = await Maryland.Deserialize.Guid(enumerator, "Unexpected EOF during attribute in set image instruction.");
                                var value = await ImageDeserializer.Deserialize(enumerator);
                                yield return new SetImage(entity, attribute, value);
                                break;
                            }

                        case 8:
                            {
                                var entity = await Maryland.Deserialize.Guid(enumerator, "Unexpected EOF during entity in set mesh instruction.");
                                var attribute = await Maryland.Deserialize.Guid(enumerator, "Unexpected EOF during attribute in set mesh instruction.");
                                var value = await MeshDeserializer.Deserialize(enumerator);
                                yield return new SetMesh(entity, attribute, value);
                                break;
                            }

                        default:
                            throw new InvalidDataException("Unexpected instruction type.");
                    }
                }
            }
        }
    }
}
