using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
    public void QuitGame()
    {
        Application.Quit();
    }
    public void LoadGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("SampleScene");
    }
    public void ReLoadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
