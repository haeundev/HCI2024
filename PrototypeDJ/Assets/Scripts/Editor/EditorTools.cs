using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Editor
{
    public static class EditorTools
    {
        private static int _count;

        [MenuItem("MyTools/CaptureScreen _l")]
        public static void CaptureScreen()
        {
            _count++;
            var tScene = SceneManager.GetActiveScene();
            var name = tScene.name;
            var timeStamps = System.DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
            ScreenCapture.CaptureScreenshot("ScreenShot/" + name + timeStamps + ".png");
        }
    }
}