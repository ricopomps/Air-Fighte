using System.Collections.Generic;
using Eflatun.SceneReference;
using MEC;
using UnityEngine.SceneManagement;

public static class Loader
{
    static SceneReference TargetScene;
    static SceneReference LoadingScene = new(SceneGuidToPathMapProvider.ScenePathToGuidMap["Assets/Scenes/Loading.unity"]);

    public static void Load(SceneReference scene)
    {
        TargetScene = scene;
        SceneManager.LoadScene("Loading");
        Timing.RunCoroutine(LoadTargetScene());
    }

    static IEnumerator<float> LoadTargetScene()
    {
        yield return Timing.WaitForOneFrame;
        SceneManager.LoadScene(TargetScene.Name);
    }
}
