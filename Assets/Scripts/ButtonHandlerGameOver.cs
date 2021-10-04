using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandlerGameOver : MonoBehaviour
{
    public void PlayAgain()
    {
        TriggerGenerator.initialized = false;
        SceneManager.LoadScene(sceneName: "SampleScene");
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
