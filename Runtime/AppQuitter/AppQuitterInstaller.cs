using SBaier.DI;

namespace SBaier.AppQuit
{
    public class AppQuitterInstaller : Installer
    {
        public void InstallBindings(Binder binder)
        {
#if UNITY_EDITOR
            binder.Bind<AppQuitter>().ToNew<EditorAppQuitter>().AsSingle();
#elif UNITY_WEBGL
            binder.Bind<AppQuitter>().ToNew<WebGLAppQuitter>().AsSingle();
#else
            binder.Bind<AppQuitter>().ToNew<StandaloneAppQuitter>().AsSingle();
#endif
        }
    }
}
