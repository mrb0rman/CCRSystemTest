using CCRSystemTest.Scripts.View;
using Zenject;

namespace CCRSystemTest.Scripts
{
    namespace Installers
    {
        public class ViewInstaller : Installer<ViewInstaller>
        {
            public override void InstallBindings()
            {
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
                
                Container
                    .BindMemoryPool<DogButtonView, DogButtonView.Pool>()
                    .WithInitialSize(10)
                    .FromComponentInNewPrefabResource(ResourcesSourceConst.DogButtonSource)
                    .UnderTransformGroup("DogButtonGroup");
            }
        }
    }
}

