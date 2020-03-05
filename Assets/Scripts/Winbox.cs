using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class Winbox : NetworkBehaviour {
    int check = 0;
    int player_count;
    void Update()
    {
        player_count = NetworkServer.connections.Count;
    }



    void OnTriggerEnter(Collider cls)
    {
        if (cls.tag == "Player") check++;
        if (check == player_count) Win();
        Debug.Log(check);
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            check--;
        Debug.Log(check);

    }
    void Win()
    {
        Debug.Log("Win");

        SceneManager.LoadScene("swin");
    }
}
