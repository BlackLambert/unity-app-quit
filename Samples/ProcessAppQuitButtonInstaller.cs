using SBaier.DI;

namespace SBaier.AppQuit.Samples
{
    public class ProcessAppQuitButtonInstaller : MonoInstaller
    {
        public override void InstallBindings(Binder binder)
        {
            new AppQuitterInstaller().InstallBindings(binder);
            new QuitProcessEnqueueInstaller().InstallBindings(binder);
        }
    }
}
