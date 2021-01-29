using ImageProcessor.Web.HttpModules;
using System.Linq;
using System.Web;
using Umbraco.Core.Composing;

namespace Our.Umbraco.AutoAutoRotate
{
    class AutoRotateComponent : IComponent
    {
        public const string AutoRotateQueryParam = "autorotate";

        public void Initialize()
        {
            ImageProcessingModule.ValidatingRequest += (s, e) =>
            {
                // We don't actually need to do anything with the image unless ImageProcessor is going to process it 
                // as un-processed images with exif oritentation data intact should "just work" in the browser 🤞
                // Could potentially check if the qs matches a valid configured plugin, but this is only about 
                // saving cache space so just checking for the presence of a qs is probably enough
                if (string.IsNullOrEmpty(e.QueryString)) return;

                var queryCollection = HttpUtility.ParseQueryString(e.QueryString);

                if (!queryCollection.AllKeys.Contains(AutoRotateQueryParam))
                {
                    queryCollection.Add(AutoRotateQueryParam, "true");
                    e.QueryString = queryCollection.ToString();
                }
            };
        }

        public void Terminate()
        {
        }
    }
}
