using Maryland.Patches.Instructions;

namespace Maryland.Databases
{
    /// <summary>
    /// Represents a database.
    /// </summary>
    /// <remarks>
    /// Implementations must allow for concurrent reads, but only need to be able to accept one write at a time, without any concurrent read activity.
    /// </remarks>
    public interface IDatabase
    {
        /// <summary>
        /// Retrieves the state of a flag.
        /// </summary>
        /// <param name="entity">The identifer of the entity to query.</param>
        /// <param name="attribute">The identifier of the flag to retrieve.</param>
        /// <returns><see langword="true"/> when the flag is set, otherwise, <see langword="false"/>.</returns>
        bool GetFlag(Guid entity, Guid attribute);

        /// <summary>
        /// Sets a flag.
        /// </summary>
        /// <remarks>A no-op if the flag is currently set.</remarks>
        /// <param name="entity">The identifer of the entity to change.</param>
        /// <param name="attribute">The identifier of the flag to set.</param>
        void SetFlag(Guid entity, Guid attribute);

        /// <summary>
        /// Clears a flag.
        /// </summary>
        /// <remarks>A no-op if the flag is not currently set.</remarks>
        /// <param name="entity">The identifer of the entity to change.</param>
        /// <param name="attribute">The identifier of the flag to clear.</param>
        void ClearFlag(Guid entity, Guid attribute);

        /// <summary>
        /// Retrieves a float.
        /// </summary>
        /// <param name="entity">The identifer of the entity to query.</param>
        /// <param name="attribute">The identifier of the float to retrieve.</param>
        /// <returns>The requested float.</returns>
        float GetFloat(Guid entity, Guid attribute);

        /// <summary>
        /// Changes a float.
        /// </summary>
        /// <param name="entity">The identifer of the entity to change.</param>
        /// <param name="attribute">The identifier of the float to change.</param>
        /// <param name="value">The value to change the float to.</param>
        void SetFloat(Guid entity, Guid attribute, float value);

        /// <summary>
        /// Retrieves a entity reference.
        /// </summary>
        /// <param name="entity">The identifer of the entity to query.</param>
        /// <param name="attribute">The identifier of the reference to retrieve.</param>
        /// <returns>The requested reference.</returns>
        Guid GetReference(Guid entity, Guid attribute);

        /// <summary>
        /// Retrieves all entities with an attribute referencing a specified entity.
        /// </summary>
        /// <remarks>This will NOT include references which have never been specified, i.e. GetEntitiesReferencing(anything, Guid.Empty) will ONLY list cases where SetReference has been used to set them to Guid.Empty.</remarks>
        /// <param name="attribute">The identifier of the attribute to search for.</param>
        /// <param name="entity">The referenced entity to search for.</param>
        /// <returns>The identifiers of the entities where the specified <paramref name="attribute"/> references the specified <paramref name="entity"/>.</returns>
        IEnumerable<Guid> GetReferrers(Guid attribute, Guid entity);

        /// <summary>
        /// Changes a entity reference.
        /// </summary>
        /// <param name="entity">The identifer of the entity to change.</param>
        /// <param name="attribute">The identifier of the string to change.</param>
        /// <param name="value">The value to change the reference to.</param>
        void SetReference(Guid entity, Guid attribute, Guid value);

        /// <summary>
        /// Retrieves a string.
        /// </summary>
        /// <param name="entity">The identifer of the entity to query.</param>
        /// <param name="attribute">The identifier of the string to retrieve.</param>
        /// <returns>The requested string.</returns>
        string GetString(Guid entity, Guid attribute);

        /// <summary>
        /// Changes a string.
        /// </summary>
        /// <param name="entity">The identifer of the entity to change.</param>
        /// <param name="attribute">The identifier of the string to change.</param>
        /// <param name="value">The value to change the string to.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="value"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="value"/> exceeds 65535 bytes in length when encoded as UTF-8.</exception>
        void SetString(Guid entity, Guid attribute, string value);

        /// <summary>
        /// Retrieves a tag by its identifier.
        /// </summary>
        /// <param name="identifier">The identifier of the tag to retrieve.</param>
        /// <returns>The requested tag.</returns>
        string GetTag(Guid identifier);

        /// <summary>
        /// Changes a tag.
        /// </summary>
        /// <param name="identifier">The identifier of the tag to change.</param>
        /// <param name="value">The value to change the tag to.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="value"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="value"/> exceeds 255 bytes in length when encoded as UTF-8.</exception>
        void SetTag(Guid identifier, string value);

        /// <summary>
        /// This <see cref="IDatabase"/>, converted to a sequence of <see cref="IInstruction"/>s as would be found in a patch file.
        /// </summary>
        IEnumerable<IInstruction> Patch { get; }

        /// <summary>
        /// Generates a patch from <see langword="this"/> <see cref="IDatabase"/> and applies it directly to another <see cref="IDatabase"/>.
        /// </summary>
        /// <param name="to">The <see cref="IDatabase"/> to apply the changes to.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="to"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="to"/> is <see langword="this"/>.</exception>
        void Apply(IDatabase to);

        /// <summary>
        /// Deletes all records from <see langword="this"/> <see cref="IDatabase"/>.
        /// </summary>
        void Clear();
    }
}
