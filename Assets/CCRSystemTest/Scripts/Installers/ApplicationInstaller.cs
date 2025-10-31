using CCRSystemTest.Scripts.View;
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
                
                Container
                    .Bind<CameraView>()
                    .FromComponentInNewPrefabResource(ResourcesSourceConst.CameraSource)
                    .AsSingle();

                Container
                    .BindMemoryPool<CoinView, CoinView.Pool>()
                    .WithInitialSize(10)
                    .FromComponentInNewPrefabResource(ResourcesSourceConst.CoinSource)
                    .UnderTransformGroup("CoinGroup");
                
                Container
                    .BindMemoryPool<SoundClickView, SoundClickView.Pool>()
                    .WithInitialSize(10)
                    .FromComponentInNewPrefabResource(ResourcesSourceConst.SoundClickSource)
                    .UnderTransformGroup("SoundClickGroup");
                
                ConfigInstaller.Install(Container);

                Container
                    .Bind<NavigationBarController>()
                    .AsSingle()
                    .NonLazy();
                
                Container
                    .Bind<ClickerController>()
                    .AsSingle();
                
                Container
                    .Bind<ApplicationLaunch>()
                    .AsSingle()
                    .NonLazy();
            }
        }
    }
}

