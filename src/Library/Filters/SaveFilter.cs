using System;
using CompAndDel.Pipes;
using CompAndDel.Filters;

namespace CompAndDel.Filters
{
    public class SaveFilter : IFilter
    {
        public IPicture Filter(IPicture image)
        {
            PictureProvider provider = new PictureProvider();
            provider.SavePicture(image, @"resultado.jpg");

            return image;
        }
    }
}