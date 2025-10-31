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
                    .Bind<APIWeatherConfig>()
                    .FromNewScriptableObjectResource(ResourcesSourceConst.APIWeatherConfig)
                    .AsSingle();
                
                Container
                    .Bind<ClickerConfig>()
                    .FromNewScriptableObjectResource(ResourcesSourceConst.ClickerConfig)
                    .AsSingle();
            }
        }
    }
}