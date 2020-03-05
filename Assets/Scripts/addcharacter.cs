using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addcharacter : MonoBehaviour {

    public GameObject gameObject;
    
	// Use this for initialization
	void Start () {

        Instantiate(gameObject, transform.position, Quaternion.identity);
	}
	
}
