using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationController : MonoBehaviour
{

    public void GoToIntroScene()
    {
        Application.LoadLevel(0);
    }

    public void GoToGameScene()
    {
        Application.LoadLevel(2);
    }

    public void GoToGameOverScene()
    {
        Application.LoadLevel(2);
    }

    public void GoToVictoryScene()
    {
        Application.LoadLevel(3);
    }

    public void Quit()
    {
        Application.Quit ();
    }

}
