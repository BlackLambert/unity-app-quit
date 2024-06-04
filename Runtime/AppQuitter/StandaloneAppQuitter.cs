using UnityEngine;

namespace SBaier.AppQuit
{
    public class StandaloneAppQuitter : AppQuitter
    {
        public override void Quit()
        {
            Application.Quit();
        }
    }
}
