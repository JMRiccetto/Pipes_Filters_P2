using CognitiveCoreUCU;

namespace CompAndDel.Filters
{
    public class FaceFilter : IFilter
    {
        public IPicture Filter(IPicture image)
        {
            var CognitiveApi = new CognitiveFace();
            CognitiveApi.Recognize(@"luke.jpg");

            if (CognitiveApi.FaceFound == true)
            {
                IFilter twitter = new FilterTwitter();
                twitter.Filter(image);
            }

            else
            {
                IFilter filterNegative = new FilterNegative();
                filterNegative.Filter(image);
            }

            return image;
        }
    }
}