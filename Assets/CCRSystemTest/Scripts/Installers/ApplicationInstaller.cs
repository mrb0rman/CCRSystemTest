using Zenject;

namespace CCRSystemTest.Scripts
{
    namespace Installers
    {
        public class ApplicationInstaller : MonoInstaller
        {
            public override void InstallBindings()
            {
                SystemInstaller.Install(Container);
                UIInstaller.Install(Container);
                ConfigInstaller.Install(Container);
                ViewInstaller.Install(Container);
                ControllerInstaller.Install(Container);
                
                Container
                    .Bind<ApplicationLaunch>()
                    .AsSingle()
                    .NonLazy();
            }
        }
    }
}

