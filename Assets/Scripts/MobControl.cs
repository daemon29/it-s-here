using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobControl : MonoBehaviour {
    public float speed =2f;
    Transform target;
    public SpriteRenderer sprites;
    public Sprite[] list_Sprites;
    void Start()
    {
        int i = Random.Range(0, list_Sprites.Length);
        sprites.sprite = list_Sprites[i];
    }
    void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
            sprites.enabled = true;
        }
    }
    void OnTriggerExit(Collider collision)
    {
        sprites.enabled = false;

    }
    void OnTriggerStay(Collider collision)
    
    {
        if (collision.tag == "Player")
        {
            target = collision.transform;
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        }          
    }
}
