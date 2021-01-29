using Umbraco.Core;
using Umbraco.Core.Composing;

namespace Our.Umbraco.AutoAutoRotate
{
    public class Composer : IUserComposer
    {
        public void Compose(Composition composition)
        {
            composition.Components().Append<AutoRotateComponent>();
        }
    }
}
