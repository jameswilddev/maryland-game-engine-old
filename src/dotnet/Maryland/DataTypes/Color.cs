namespace Maryland.DataTypes
{
    /// <summary>
    /// A 24-bit red/green/blue color.
    /// </summary>
    public struct Color
    {
        /// <summary>
        /// The intensity of the red channel, where 0 is the minimum possible intensity and 255 is the maximum possible intensity.
        /// </summary>
        public readonly byte Red;

        /// <summary>
        /// The intensity of the green channel, where 0 is the minimum possible intensity and 255 is the maximum possible intensity.
        /// </summary>
        public readonly byte Green;

        /// <summary>
        /// The intensity of the blue channel, where 0 is the minimum possible intensity and 255 is the maximum possible intensity.
        /// </summary>
        public readonly byte Blue;

        /// <summary>
        /// Creates a 24-bit red/green/blue color.
        /// </summary>
        /// <param name="red">The intensity of the red channel, where 0 is the minimum possible intensity and 255 is the maximum possible intensity.</param>
        /// <param name="green">The intensity of the green channel, where 0 is the minimum possible intensity and 255 is the maximum possible intensity.</param>
        /// <param name="blue">The intensity of the blue channel, where 0 is the minimum possible intensity and 255 is the maximum possible intensity.</param>
        public Color(byte red, byte green, byte blue)
        {
            Red = red;
            Green = green;
            Blue = blue;
        }
    }
}
