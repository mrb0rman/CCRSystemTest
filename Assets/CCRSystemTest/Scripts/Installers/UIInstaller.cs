using CCRSystemTest.Scripts.UI;
using Zenject;

namespace CCRSystemTest.Scripts
{
    namespace Installers
    {
        public class UIInstaller : Installer<UIInstaller>
        {
            public override void InstallBindings()
            {
                Container
                    .Bind<IUIRoot>()
                    .To<UIRoot>()
                    .FromComponentInNewPrefabResource(ResourcesSourceConst.UIRootSource)
                    .AsSingle();
                
                Container
                    .Bind<IUIService>()
                    .To<UIService>()
                    .AsSingle();

                Container
                    .Bind<UINavigationBarController>()
                    .AsSingle();
                
                Container
                    .Bind<UIClickerController>()
                    .AsSingle();
            }
        }
    }
}