using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

public class SceneSwitchEditor
{
    [MenuItem("Scenes/Main Scene")]
    public static void LoadMainScene()
    {
        EditorSceneManager.OpenScene("Assets/Scenes/Main/MainScene");
        EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
    }

    [MenuItem("Scenes/Fabio Scene")]
    public static void LoadFabioScene()
    {
        EditorSceneManager.OpenScene("Assets/Scenes/Fabio/FabioScene");
        EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
    }

    [MenuItem("Scenes/Kyle Scene")]
    public static void LoadKyleScene2()
    {
        EditorSceneManager.OpenScene("Assets/Scenes/Kyle/KyleScene");
        EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
    }

    [MenuItem("Scenes/Samuel Scene")]
    public static void LoadSamuelScene()
    {
        EditorSceneManager.OpenScene("Assets/Scenes/Samuel/SamuelScene");
        EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
    }

    [MenuItem("Scenes/Rik Scene")]
    public static void LoadRikScene()
    {
        EditorSceneManager.OpenScene("Assets/Scenes/Rik/RikScene");
        EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
    }
}
