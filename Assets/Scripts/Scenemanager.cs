using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Scenemanager : MonoBehaviour {
    public void LoadSceneMode()
    {
        string scenename = SceneManager.GetActiveScene().name;
        if (scenename=="swin")
        SceneManager.LoadScene(0);
        if (scenename == "slose")
            SceneManager.LoadScene(0);
        if (scenename == "MainMenu")
            SceneManager.LoadScene(1);
        if (scenename == "Credit")
            SceneManager.LoadScene(0);

    }
    public void Credit()
    {
        SceneManager.LoadScene(4);
    }

}
