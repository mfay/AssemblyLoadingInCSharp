using Filters;
using System.Drawing;

namespace LoadMeAnAssembly
{
    public class GreyFilter : IFilter
    {
        public Image Apply(Image image)
        {
            var bmp = new Bitmap(image);
            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    var c = bmp.GetPixel(x, y);
                    var avg = (c.R + c.B + c.G) / 3;
                    bmp.SetPixel(x, y, Color.FromArgb(avg, avg, avg));
                }
            }
            return bmp;

        }
    }
}
