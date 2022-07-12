namespace Maryland.ReferenceStores
{
    /// <summary>
    /// Describes an entity/attribute identifier pair.
    /// </summary>
    public struct EntityAttributeIdentifierPair
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
        /// Creates a new entity/attribute identifier pair.
        /// </summary>
        /// <param name="entity">The identifier of the entity.</param>
        /// <param name="attribute">The identifier of the attribute.</param>
        public EntityAttributeIdentifierPair(Guid entity, Guid attribute)
        {
            Entity = entity;
            Attribute = attribute;
        }
    }
}
