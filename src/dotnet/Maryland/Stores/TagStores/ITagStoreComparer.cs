namespace Maryland.Stores.TagStores
{
    /// <summary>
    /// Generates <see cref="TagStoreDiff"/>s from pairs of <see cref="ITagStore"/>s.
    /// </summary>
    public interface ITagStoreComparer
    {
        /// <summary>
        /// Generates a <see cref="TagStoreDiff"/> which describes the changes between two <see cref="ITagStore"/>s.
        /// </summary>
        /// <param name="a">The first <see cref="ITagStore"/> to compare.</param>
        /// <param name="b">The second <see cref="ITagStore"/> to compare.</param>
        /// <returns>A <see cref="TagStoreDiff"/> which describes the changes which need to be applied to <paramref name="a"/> to make it equivalent to <paramref name="b"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="a"/> is null.</exception>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="b"/> is null.</exception>
        TagStoreDiff Compare(ITagStore a, ITagStore b);
    }
}
