using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    CharacterController cc;
    public Camera cam;
    public float movespeed = 5.5f;
    float gravity = 0f;
    // Use this for initialization
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }
    void Movement()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(x, 0, z).normalized;
        float cameraDirection = cam.transform.localEulerAngles.y;
        direction = Quaternion.AngleAxis(cameraDirection, Vector3.up) * direction;
        Vector3 velecity = direction * movespeed * Time.deltaTime;

        if (cc.isGrounded)
        {
            gravity = 0;
        }
        else
        {
            gravity += 0.25f;
            gravity = Mathf.Clamp(gravity, 1f, 20f);
        }
        Vector3 gravityVector = -Vector3.up * gravity * Time.deltaTime;
        cc.Move(velecity + gravityVector);
        if (velecity.magnitude > 0)
        {
            //float yAngel = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            //transform.localEulerAngles = new Vector3(0, yAngel, 0);
        }
    }
}
