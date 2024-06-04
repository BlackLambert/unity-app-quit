using SBaier.DI;

namespace SBaier.AppQuit
{
    public class QuitProcessEnqueueInstaller : Installer
    {
        private QuitProcessEnqueueTrigger.Arguments _arguments = null;
        
        public QuitProcessEnqueueInstaller()
        {
            
        }
        
        public QuitProcessEnqueueInstaller(QuitProcessEnqueueTrigger.Arguments arguments)
        {
            _arguments = arguments;
        }

        public void InstallBindings(Binder binder)
        {
            if (_arguments != null)
            {
                binder.Bind<QuitTrigger>()
                    .ToNew<QuitProcessEnqueueTrigger>()
                    .WithArgument(_arguments)
                    .AsSingle();
            }
            else
            {
                binder.Bind<QuitTrigger>()
                    .ToNew<QuitProcessEnqueueTrigger>()
                    .AsSingle();
            }
        }
    }
}
