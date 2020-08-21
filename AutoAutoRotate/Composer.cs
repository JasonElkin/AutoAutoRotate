using Umbraco.Core;
using Umbraco.Core.Composing;

namespace AutoAutoRotate
{
    public class Composer : IUserComposer
    {
        public void Compose(Composition composition)
        {
            composition.Components().Append<AutoRotateComponent>();
        }
    }
}
