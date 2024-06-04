using SBaier.DI;

namespace SBaier.AppQuit
{
    public class BasicQuitTriggerInstaller : Installer
    {
        public void InstallBindings(Binder binder)
        {
            binder.Bind<QuitTrigger>()
                .ToNew<BasicQuitTrigger>()
                .AsSingle();
        }
    }
}