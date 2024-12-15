using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NavigationController : MonoBehaviour
{
    public void GoToIntroScene()
    {
        SceneManager.LoadScene(0); // Load Intro scene by index (0)
    }

    public void GoToGameScene()
    {
        SceneManager.LoadScene(1); // Load Game scene by index (1)
    }

    public void GoToGameOverScene()
    {
        SceneManager.LoadScene(5); // Load GameOver scene by index (5)
    }

    public void GoToVictoryScene()
    {
        SceneManager.LoadScene(6); // Load Victory scene by index (6)
    }

    public void Quit()
    {
        Application.Quit();  // Keep original functionality
    }

    // This method will load the next scene based on the current scene's index.
    public void GoToNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex; // Get current scene's build index
        int nextSceneIndex = currentSceneIndex + 1; // Increment index to load the next scene

        // Check if the next scene exists in the build settings
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex); // Load the next scene based on the index
        }
        else
        {
            GoToVictoryScene(); // Load Victory scene if it's the last level
        }
    }
}
