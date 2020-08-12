using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneScript : MonoBehaviour
{
    public void ToTitleScene()
    {
        SceneManager.LoadScene("TitleScene");
    }

    public void ToMainScene()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void ToClearScene()
    {
        SceneManager.LoadScene("ClearScene");
    }

    public void ToGameOverScene()
    {
        SceneManager.LoadScene("GameOverScene");
    }
}
