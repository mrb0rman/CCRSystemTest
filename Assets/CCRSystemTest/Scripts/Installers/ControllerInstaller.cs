using CCRSystemTest.Scripts.Controller;
using Zenject;

namespace CCRSystemTest.Scripts
{
    namespace Installers
    {
        public class ControllerInstaller : Installer<ControllerInstaller>
        {
            public override void InstallBindings()
            {
                Container
                    .Bind<NavigationBarController>()
                    .AsSingle()
                    .NonLazy();
                
                Container
                    .Bind<ClickerController>()
                    .AsSingle();
                
                Container
                    .Bind<WeatherController>()
                    .AsSingle();
                
                Container
                    .Bind<DogController>()
                    .AsSingle();
            }
        }
    }
}

