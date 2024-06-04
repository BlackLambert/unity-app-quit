using SBaier.DI;

namespace SBaier.AppQuit.Samples
{
    public class AppQuitSceneInstaller : MonoInstaller
    {
        public override void InstallBindings(Binder binder)
        {
            new AppQuitterInstaller().InstallBindings(binder);
            new BasicQuitTriggerInstaller().InstallBindings(binder);
            
            binder.BindComponent<MainThreadDispatcher>()
                .FromNewComponentOnNewGameObject("Dispatcher", transform)
                .AsSingle();
        }
    }
}
