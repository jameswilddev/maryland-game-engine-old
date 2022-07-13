namespace Maryland.Stores.ReferenceStores
{
    /// <summary>
    /// Generates <see cref="ReferenceStoreDiff"/>s from pairs of <see cref="IReferenceStore"/>s.
    /// </summary>
    public interface IReferenceStoreComparer
    {
        /// <summary>
        /// Generates a <see cref="ReferenceStoreDiff"/> which describes the changes between two <see cref="IReferenceStore"/>s.
        /// </summary>
        /// <param name="a">The first <see cref="IReferenceStore"/> to compare.</param>
        /// <param name="b">The second <see cref="IReferenceStore"/> to compare.</param>
        /// <returns>A <see cref="ReferenceStoreDiff"/> which describes the changes which need to be applied to <paramref name="a"/> to make it equivalent to <paramref name="b"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="a"/> is null.</exception>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="b"/> is null.</exception>
        ReferenceStoreDiff Compare(IReferenceStore a, IReferenceStore b);
    }
}
