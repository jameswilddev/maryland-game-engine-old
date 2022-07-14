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
        /// Retrieves the state of an entity flag.
        /// </summary>
        /// <param name="entity">The identifer of the entity to query.</param>
        /// <param name="attribute">The identifier of the entity flag to retrieve.</param>
        /// <returns><see langword="true"/> when the entity flag is set, otherwise, <see langword="false"/>.</returns>
        bool GetEntityFlag(Guid entity, Guid attribute);

        /// <summary>
        /// Sets an entity flag.
        /// </summary>
        /// <remarks>A no-op if the entity flag is currently set.</remarks>
        /// <param name="entity">The identifer of the entity to change.</param>
        /// <param name="attribute">The identifier of the entity flag to set.</param>
        void SetEntityFlag(Guid entity, Guid attribute);

        /// <summary>
        /// Clears a entity flag.
        /// </summary>
        /// <remarks>A no-op if the entity flag is not currently set.</remarks>
        /// <param name="entity">The identifer of the entity to change.</param>
        /// <param name="attribute">The identifier of the entity flag to clear.</param>
        void ClearEntityFlag(Guid entity, Guid attribute);

        /// <summary>
        /// Retrieves a entity float.
        /// </summary>
        /// <param name="entity">The identifer of the entity to query.</param>
        /// <param name="attribute">The identifier of the entity float to retrieve.</param>
        /// <returns>The requested entity float.</returns>
        float GetEntityFloat(Guid entity, Guid attribute);

        /// <summary>
        /// Changes a entity float.
        /// </summary>
        /// <param name="entity">The identifer of the entity to change.</param>
        /// <param name="attribute">The identifier of the entity float to change.</param>
        /// <param name="value">The value to change the entity float to.</param>
        void SetEntityFloat(Guid entity, Guid attribute, float value);

        /// <summary>
        /// Retrieves a entity reference.
        /// </summary>
        /// <param name="entity">The identifer of the entity to query.</param>
        /// <param name="attribute">The identifier of the entity reference to retrieve.</param>
        /// <returns>The requested entity reference.</returns>
        Guid GetEntityReference(Guid entity, Guid attribute);

        /// <summary>
        /// Retrieves all entities with an attribute referencing a specified entity.
        /// </summary>
        /// <remarks>This will NOT include references which have never been specified, i.e. GetEntitiesReferencing(anything, Guid.Empty) will ONLY list cases where SetEntityReference has been used to set them to Guid.Empty.</remarks>
        /// <param name="attribute">The identifier of the attribute to search for.</param>
        /// <param name="entity">The referenced entity to search for.</param>
        /// <returns>The identifiers of the entities where the specified <paramref name="attribute"/> references the specified <paramref name="entity"/>.</returns>
        IEnumerable<Guid> GetEntitiesReferencing(Guid attribute, Guid entity);

        /// <summary>
        /// Changes a entity reference.
        /// </summary>
        /// <param name="entity">The identifer of the entity to change.</param>
        /// <param name="attribute">The identifier of the entity string to change.</param>
        /// <param name="value">The value to change the entity reference to.</param>
        void SetEntityReference(Guid entity, Guid attribute, Guid value);

        /// <summary>
        /// Retrieves a entity string.
        /// </summary>
        /// <param name="entity">The identifer of the entity to query.</param>
        /// <param name="attribute">The identifier of the entity string to retrieve.</param>
        /// <returns>The requested entity string.</returns>
        string GetEntityString(Guid entity, Guid attribute);

        /// <summary>
        /// Changes a entity string.
        /// </summary>
        /// <param name="entity">The identifer of the entity to change.</param>
        /// <param name="attribute">The identifier of the entity string to change.</param>
        /// <param name="value">The value to change the entity string to.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="value"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="value"/> exceeds 65535 bytes in length when encoded as UTF-8.</exception>
        void SetEntityString(Guid entity, Guid attribute, string value);

        /// <summary>
        /// Retrieves the state of a global flag.
        /// </summary>
        /// <param name="attribute">The identifier of the global flag to retrieve.</param>
        /// <returns><see langword="true"/> when the global flag is set, otherwise, <see langword="false"/>.</returns>
        bool GetGlobalFlag(Guid attribute);

        /// <summary>
        /// Sets a global flag.
        /// </summary>
        /// <remarks>A no-op if the global flag is currently set.</remarks>
        /// <param name="attribute">The identifier of the global flag to set.</param>
        void SetGlobalFlag(Guid attribute);

        /// <summary>
        /// Clears a global flag.
        /// </summary>
        /// <remarks>A no-op if the global flag is not currently set.</remarks>
        /// <param name="attribute">The identifier of the global flag to clear.</param>
        void ClearGlobalFlag(Guid attribute);

        /// <summary>
        /// Retrieves a global float.
        /// </summary>
        /// <param name="identifier">The identifier of the global float to retrieve.</param>
        /// <returns>The requested global float.</returns>
        float GetGlobalFloat(Guid identifier);

        /// <summary>
        /// Changes a global float.
        /// </summary>
        /// <param name="identifier">The identifier of the global float to change.</param>
        /// <param name="value">The value to change the global float to.</param>
        void SetGlobalFloat(Guid identifier, float value);

        /// <summary>
        /// Retrieves a global reference.
        /// </summary>
        /// <param name="identifier">The identifier of the global reference to retrieve.</param>
        /// <returns>The requested global reference.</returns>
        Guid GetGlobalReference(Guid identifier);

        /// <summary>
        /// Changes a global reference.
        /// </summary>
        /// <param name="identifier">The identifier of the global string to change.</param>
        /// <param name="value">The value to change the global reference to.</param>
        void SetGlobalReference(Guid identifier, Guid value);

        /// <summary>
        /// Retrieves a global string.
        /// </summary>
        /// <param name="identifier">The identifier of the global string to retrieve.</param>
        /// <returns>The requested global string.</returns>
        string GetGlobalString(Guid identifier);

        /// <summary>
        /// Changes a global string.
        /// </summary>
        /// <param name="identifier">The identifier of the global string to change.</param>
        /// <param name="value">The value to change the global string to.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="value"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="value"/> exceeds 65535 bytes in length when encoded as UTF-8.</exception>
        void SetGlobalString(Guid identifier, string value);

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
    }
}
