using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.NetworkSystem;

public class PlayerSetup : NetworkBehaviour {

    [SerializeField]
    Behaviour[] ComponenttoDisable;
    public Light light;
    void Start()
    {
        int count = NetworkServer.connections.Count;
        if (count % 2 == 0) light.color = new Color32(55, 72, 255, 255);
        else light.color = new Color32(225, 64, 228, 255);
        if (!isLocalPlayer)
        {
            for(int i = 0; i < ComponenttoDisable.Length; i++)
            {
                ComponenttoDisable[i].enabled = false;
            }
        }
        else {
            Camera.main.gameObject.SetActive(false);}
    }

    public override void OnStartClient()
    {
        NetworkManagerHUD hud = FindObjectOfType<NetworkManagerHUD>();
        if (hud != null)
            hud.showGUI = false;
    }
}
