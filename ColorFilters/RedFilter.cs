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
                    var tint = avg + (int)(avg * 1.1);
                    if (tint > 255) tint = 255;
                    bmp.SetPixel(x, y, Color.FromArgb(tint, avg, avg));
                }
            }
            return bmp;
        }
    }
    public class BlueFilter : IFilter
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
                    var tint = avg + (int)(avg * 1.1);
                    if (tint > 255) tint = 255;
                    bmp.SetPixel(x, y, Color.FromArgb(avg, avg, tint));
                }
            }
            return bmp;
        }
    }
    public class GreenFilter : IFilter
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
                    var tint = avg + (int)(avg * 1.1);
                    if (tint > 255) tint = 255;
                    bmp.SetPixel(x, y, Color.FromArgb(avg, tint, avg));
                }
            }
            return bmp;
        }
    }
}
