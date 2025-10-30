using CCRSystemTest.Scripts.Bootstrap;
using CCRSystemTest.Scripts.Command;
using Zenject;

namespace CCRSystemTest.Scripts
{
    namespace Installers
    {
        public class SystemInstaller : Installer<SystemInstaller>
        {
            public override void InstallBindings()
            {
                Container
                    .Bind<IBootstrap>()
                    .To<Bootstrap.Bootstrap>()
                    .AsSingle();
            
                Container
                    .Bind<CommandStorage>()
                    .AsSingle()
                    .NonLazy();
            }
        }
    }
}

