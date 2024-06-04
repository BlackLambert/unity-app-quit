using System;
using SBaier.DI;
using UnityEngine;
using UnityEngine.UI;

namespace SBaier.AppQuit
{
    public class QuitTriggerButton : MonoBehaviour, Injectable, Initializable, Cleanable
    {
        [SerializeField] 
        private Button _button;

        private QuitTrigger _quitTrigger;
        
        public void Inject(Resolver resolver)
        {
            _quitTrigger = resolver.Resolve<QuitTrigger>();
        }

        private void Reset()
        {
            _button = GetComponent<Button>();
        }

        public void Initialize()
        {
            _button.onClick.AddListener(OnClick);
            _quitTrigger.Quitting.OnValueChanged += OnQuittingChanged;
            UpdateInteractable();
        }

        public void Clean()
        {
            _button.onClick.RemoveListener(OnClick);
            _quitTrigger.Quitting.OnValueChanged -= OnQuittingChanged;
        }

        private void OnClick()
        {
            _quitTrigger.Quit();
        }

        private void OnQuittingChanged(bool formervalue, bool newvalue)
        {
            UpdateInteractable();
        }

        private void UpdateInteractable()
        {
            _button.interactable = !_quitTrigger.Quitting.Value;
        }
    }
}