/* using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseResume : MonoBehaviour
{
    public GameObject PauseScreen;
    public static bool paused;
    public KeyCode PauseButton;
    // Start is called before the first frame update
    void Start()
    {
        paused= false;
        PauseScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(PauseButton) && !paused)
        {
            pause();
        }
        else if(Input.GetKeyDown(PauseButton && paused))
        {
            resume();
        }
       /* if(PauseResume.paused)
        {
            if(Input.GetKeyDown(Spacebar) && grounded)
            {
                Jump();
            }
        }
    }

    void pause()
    {
        PauseScreen.SetActive(true);
        paused= true;
        time.timeScale=0;
    }
    void resume()
    {
        PauseScreen.SetActive(false);
        paused=false;
        Time.timeScale=1;
    }
}
}

*/