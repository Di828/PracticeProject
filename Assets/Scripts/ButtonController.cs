using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class ButtonController : MonoBehaviour
{
    public void ClickOnReturn()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void ClickOnStartButton()
    {
        SceneManager.LoadScene("LevelOne");
    }
    public void ClickOnQuitButton()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();
#else
application.Quit();
#endif
    }
}
