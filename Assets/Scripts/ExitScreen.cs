using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitScreen : MonoBehaviour
{
    public GameObject exitMenu;
    public static bool esc;

    private void Start()
    {
        esc = false;
    }

    public void SetExitMenu(bool isEsc)
    {
        esc = isEsc;
        exitMenu.SetActive(esc);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_ANDROID
        Application.Quit();
#endif
    }
}
