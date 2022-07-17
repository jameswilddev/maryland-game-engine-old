namespace Maryland.DataTypes
{
    /// <summary>
    /// A 32-bit red/green/blue/opacity color.
    /// </summary>
    public struct ColorWithOpacity
    {
        /// <summary>
        /// The intensity of the red channel, where 0 is the minimum possible intensity and 255 is the maximum possible intensity.
        /// </summary>
        /// <remarks>Premultiplied by the <see cref="Opacity"/>.</remarks>
        public readonly byte Red;

        /// <summary>
        /// The intensity of the green channel, where 0 is the minimum possible intensity and 255 is the maximum possible intensity.
        /// </summary>
        /// <remarks>Premultiplied by the <see cref="Opacity"/>.</remarks>
        public readonly byte Green;

        /// <summary>
        /// The intensity of the blue channel, where 0 is the minimum possible intensity and 255 is the maximum possible intensity.
        /// </summary>
        /// <remarks>Premultiplied by the <see cref="Opacity"/>.</remarks>
        public readonly byte Blue;

        /// <summary>
        /// The opacity of the color, where 0 is fully transparent and 255 is fully opaque.
        /// </summary>
        public readonly byte Opacity;

        /// <summary>
        /// Creates a 32-bit red/green/blue/opacity color.
        /// </summary>
        /// <param name="red">The intensity of the red channel, where 0 is the minimum possible intensity and 255 is the maximum possible intensity.</param>
        /// <param name="green">The intensity of the green channel, where 0 is the minimum possible intensity and 255 is the maximum possible intensity.</param>
        /// <param name="blue">The intensity of the blue channel, where 0 is the minimum possible intensity and 255 is the maximum possible intensity.</param>
        /// <param name="opacity">The opacity of the color, where 0 is fully transparent and 255 is fully opaque.</param>
        public ColorWithOpacity(byte red, byte green, byte blue, byte opacity)
        {
            Red = red;
            Green = green;
            Blue = blue;
            Opacity = opacity;
        }
    }
}
