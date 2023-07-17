using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ExitMenu : MonoBehaviour
{
    public ExitScreen exitScreen;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            exitScreen.SetExitMenu(true);
        }
    }
}
