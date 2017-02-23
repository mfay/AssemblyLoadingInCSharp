using System.Drawing;

namespace Filters
{
    public interface IFilter
    {
        Image Apply(Image image);
    }

}
