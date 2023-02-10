using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lost : MonoBehaviour
{
    public void RePlay()
    {
        Scene scene = SceneManager.GetActiveScene();

        SceneManager.LoadScene(scene.name);
    }
    public void ReturnHome()
    {
        SceneManager.LoadScene("ChooseLevel");
    }
    public void NextScene(string nameScene)
    {
        SceneManager.LoadScene(nameScene);
    }
}
