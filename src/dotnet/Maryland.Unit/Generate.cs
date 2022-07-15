namespace Maryland.Unit
{
    internal static class Generate
    {
        internal static float Float()
        {
            var bytes = new byte[4];
            Random.Shared.NextBytes(bytes);
            return BitConverter.ToSingle(bytes);
        }

        internal static string String()
        {
            return $"Test {Guid.NewGuid()} String";
        }
    }
}
