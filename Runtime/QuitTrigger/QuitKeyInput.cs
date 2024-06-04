using System.Collections.Generic;
using System.Linq;
using SBaier.DI;
using UnityEngine;

namespace SBaier.AppQuit
{
    public class QuitKeyInput : MonoBehaviour, Injectable
    {
        [SerializeField] 
        private List<KeyCode> _quitKeys = new List<KeyCode>();
        
        private QuitTrigger _quitTrigger;
        
        public void Inject(Resolver resolver)
        {
            _quitTrigger = resolver.Resolve<QuitTrigger>();
        }
        
        private void Update()
        {
            if (!_quitTrigger.Quitting.Value
                && Input.anyKey 
                && _quitKeys.Any(Input.GetKeyDown))
            {
                _quitTrigger.Quit();
            }
        }
    }
}