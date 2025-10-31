using CCRSystemTest.Scripts.Configs;
using Zenject;

namespace CCRSystemTest.Scripts
{
    namespace Installers
    {
        public class ConfigInstaller : Installer<ConfigInstaller>
        {
            public override void InstallBindings()
            {
                Container
                    .Bind<APIConfig>()
                    .FromNewScriptableObjectResource(ResourcesSourceConst.APIConfig)
                    .AsSingle();
                
                Container
                    .Bind<ClickerConfig>()
                    .FromNewScriptableObjectResource(ResourcesSourceConst.ClickerConfig)
                    .AsSingle();
            }
        }
    }
}