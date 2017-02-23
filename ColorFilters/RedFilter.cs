using Filters;
using System.Drawing;

namespace ColorFilters
{
    public class RedFilter : IFilter
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
                    var r = avg + (int)(avg * 1.2);
                    if (r > 255) r = 255;
                    bmp.SetPixel(x, y, Color.FromArgb(r, avg, avg));
                }
            }
            return bmp;
        }
    }
}
