namespace Maryland.Stores
{
    /// <summary>
    /// Generates <see cref="StoreDiff"/>s from pairs of <see cref="Store"/>s.
    /// </summary>
    public interface IStoreComparer
    {
        /// <summary>
        /// Generates a <see cref="StoreDiff"/> which describes the changes between two <see cref="Store"/>s.
        /// </summary>
        /// <param name="a">The first <see cref="Store"/> to compare.</param>
        /// <param name="b">The second <see cref="Store"/> to compare.</param>
        /// <returns>A <see cref="StoreDiff"/> which describes the changes which need to be applied to <paramref name="a"/> to make it equivalent to <paramref name="b"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="a"/> is null.</exception>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="b"/> is null.</exception>
        StoreDiff Compare(Store a, Store b);
    }
}
