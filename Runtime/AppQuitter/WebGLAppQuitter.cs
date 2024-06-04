using UnityEngine;

namespace SBaier.AppQuit
{
    public class WebGLAppQuitter : AppQuitter
    {
        public override void Quit()
        {
            Debug.LogWarning("Cannot quit WebGL application programmatically.");
        }
    }
}