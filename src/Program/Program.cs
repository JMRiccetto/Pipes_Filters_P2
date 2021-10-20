using System;
using CompAndDel.Pipes;
using CompAndDel.Filters;

namespace CompAndDel
{
    class Program
    {
        static void Main(string[] args)
        {
            PictureProvider provider = new PictureProvider();
            IPicture picture = provider.GetPicture(@"Luke.jpg");

            IPipe pipeNull = new PipeNull();
            IFilter filterTwitter = new FilterTwitter();
            IPipe twitterPipe = new PipeSerial(filterTwitter, pipeNull);
            IFilter filterNegative = new FilterNegative();
            IPipe pipeSerial1 = new PipeSerial(filterNegative, twitterPipe);
            IFilter saveFilter = new SaveFilter();
            IPipe pipeSerial2 = new PipeSerial(saveFilter, pipeSerial1);
            IFilter conditionalFilter = new FaceFilter();
            IPipe conditionalForkPipe = new PipeFork(conditionalFilter, pipeSerial2, pipeNull);
            IFilter filterGreyScale = new FilterGreyscale();
            IPipe pipeSerial3 = new PipeSerial(filterGreyScale, pipeSerial2);

            IPicture result = pipeSerial3.Send(picture);
            provider.SavePicture(result, @"lukefinal.jpg");
        }
    }
}
