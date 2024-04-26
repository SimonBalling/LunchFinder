namespace LunchFinder.Server.Extensions
{
    using System.Drawing;

    public static class ColorExtension
    {
        /// <summary>
        /// Takes a System.Drawing.Color and converts it to a hex value
        /// </summary>
        /// <param name="color">The <see cref="System.Drawing.Color">Color</see> </param>
        /// <returns>The <see cref="System.Drawing.Color">Color</see> as a hex string</returns>
        public static string ToHex(this Color color)
            => $"#{color.R:X2}{color.G:X2}{color.B:X2}";


        /// <summary>
        /// Takes a System.Drawing.Color and converts it to a hex value
        /// </summary>
        /// <param name="color">The <see cref="System.Drawing.Color">Color</see></param>
        /// <returns>The <see cref="System.Drawing.Color">Color</see> as an RGB string</returns>
        public static string ToRGB(this Color color)
            => $"RGB({color.R},{color.G},{color.B})";
    }
}
