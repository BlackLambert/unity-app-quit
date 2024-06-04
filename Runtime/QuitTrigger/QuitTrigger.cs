using System.Threading.Tasks;
using SBaier.DI;

namespace SBaier.AppQuit
{
    public abstract class QuitTrigger : Injectable
    {
        public ReadonlyObservable<bool> Quitting => _quitting;

        protected AppQuitter _quitter;
        protected MainThreadDispatcher _dispatcher;
        private Observable<bool> _quitting = new ();
        
        public virtual void Inject(Resolver resolver)
        {
            _quitter = resolver.Resolve<AppQuitter>();
            _dispatcher = resolver.Resolve<MainThreadDispatcher>();
        }

        public async void Quit()
        {
            _quitting.Value = true;
            await DoQuit();
            _quitting.Value = false;
        }

        protected virtual async Task DoQuit()
        {
            await Task.Run(() => _dispatcher.ExecuteOnMainThread(_quitter.Quit));
        }
    }
}