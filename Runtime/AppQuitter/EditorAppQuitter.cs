using UnityEditor;

namespace SBaier.AppQuit
{
    public class EditorAppQuitter : AppQuitter
    {
        public override void Quit()
        {
            EditorApplication.isPlaying = false;
        }
    }
}
