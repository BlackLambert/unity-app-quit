using System.Threading.Tasks;
using SBaier.DI;
using SBaier.Process;
using SBaier.Process.UI;
using UnityEngine;

namespace SBaier.AppQuit
{
    public class QuitProcessEnqueueTrigger : QuitTrigger
    {
        private const string _defaultProcessName = "Quitting application";

        private ProcessQueue _processQueue;
        private Time.Time _time;
        private Arguments _arguments;

        public override void Inject(Resolver resolver)
        {
            base.Inject(resolver);
            _processQueue = resolver.Resolve<ProcessQueue>();
            _time = resolver.Resolve<Time.Time>();
            _arguments = resolver.ResolveOptional<Arguments>() ?? new Arguments() { ProcessName = _defaultProcessName };
        }

        protected override async Task DoQuit()
        {
            Process.Process quitProcess = new TaskProcess(base.DoQuit)
                .WithName(_arguments.ProcessName)
                .WithUnscaledStartTime(_time);
            _processQueue.Enqueue(quitProcess);

            while (!quitProcess.Complete.Value && !quitProcess.Stopped.Value)
            {
                await Task.Yield();
            }
        }

        public class Arguments
        {
            public string ProcessName { get; set; }
        }
    }
}