#if UNITY_EDITOR
using UnityEditor;
#endif

namespace SBaier.AppQuit
{
    public class EditorAppQuitter : AppQuitter
    {
        public override void Quit()
        {
#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
#endif
        }
    }
}
