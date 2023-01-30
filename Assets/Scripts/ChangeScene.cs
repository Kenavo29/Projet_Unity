using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string gameOverScene = "GameOver";
    public string Level1 = "Level1";

    public void LoadGameOverScene()
    {
        SceneManager.LoadScene(gameOverScene);
    }
    public void LoadMainScene()
    {
        SceneManager.LoadScene(Level1);
    }

    public void exitGame()
    {
        Application.Quit();
    }
}
