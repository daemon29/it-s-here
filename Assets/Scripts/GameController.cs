using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public static GameController Instance;
    public GameObject quit;
    public void Pause()
    {
    if (quit.activeSelf == false) quit.SetActive(true);
    else quit.SetActive(false);
    }
    public void Exit()
    {
        SceneManager.LoadScene(0);
    }

}
