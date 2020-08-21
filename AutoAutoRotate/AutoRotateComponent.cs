using ImageProcessor.Web.HttpModules;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using Umbraco.Core.Composing;

namespace AutoAutoRotate
{
    class AutoRotateComponent : IComponent
    {
        public void Initialize()
        {
            ImageProcessingModule.ValidatingRequest += (s, e) =>
            {
                NameValueCollection queryCollection = HttpUtility.ParseQueryString(e.QueryString);

                if (!queryCollection.AllKeys.Contains("autorotate"))
                {
                    queryCollection.Add("autorotate", "true");
                    e.QueryString = queryCollection.ToString();
                }
            };
        }

        public void Terminate()
        {
        }
    }
}
