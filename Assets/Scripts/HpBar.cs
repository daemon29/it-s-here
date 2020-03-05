using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HpBar : MonoBehaviour
{
    public Rigidbody rbd;
    public Light light;
    bool checkMeet = false;
    private bool stop = false;
    private Transform g;
    public AudioSource ads;

    private void Start()
    {
        if (gameObject.name.Contains("Clone"))
        {
            g = GameObject.Find("Goal").transform;
            g.gameObject.SetActive(false);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            light.range = light.range - 0.5f;
            if (light.range < 5f) {
                light.range = 1.5f;
                light.color = new Color32(202, 9, 9, 255);              
                StartCoroutine(BeforeDie());
            }         
        }
        if (other.tag == "Player") { Debug.Log("Yes");checkMeet = true; }
    }
 
       
    private void Update()
    {
        if (checkMeet)
        {
            if(gameObject.name.Contains("Clone")) g.gameObject.SetActive(true);
            checkMeet = false;
        }
        if (stop)
        {
            Invoke("ChangeColour", 1);
            //Time.timeScale = 0;
            SceneManager.LoadScene("slose");
        }
    }
    IEnumerator BeforeDie()
    {
        //play
        ads.Play();
        yield return new WaitForSeconds(3);
        stop = true;
        ads.Stop();
    }
}
