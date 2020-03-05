﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour
{

    private float minSwipeDistY = 0f;
                                  
    private float minSwipeDistX = 0f;

    private Vector2 startPos;

    public GameObject character;
    private float speed = 5f;

    void Update()
    {
        //#if UNITY_ANDROID
        if (Input.touchCount > 0)

        {

            Touch touch = Input.touches[0];
            switch (touch.phase)

            {

                case TouchPhase.Began:

                    startPos = touch.position;

                    break;



                case TouchPhase.Moved:
                    float swipeDistHorizontal = (new Vector3(touch.position.x, 0, 0) - new Vector3(startPos.x, 0, 0)).magnitude;

                    if (swipeDistHorizontal > minSwipeDistX)

                    {

                        float swipeValue = Mathf.Sign(touch.position.x - startPos.x);

                        if (swipeValue > 0) //right swipe

                            //character.transform.position += new Vector3(0, 0, Time.deltaTime * speed);
                            character.GetComponent<Rigidbody>().velocity = new Vector3(
                                speed,
                                character.GetComponent<Rigidbody>().velocity.y,
                                character.GetComponent<Rigidbody>().velocity.z
                                );


                        else if (swipeValue < 0) //left swipe

                            // character.transform.position += new Vector3(0, 0, -Time.deltaTime * speed);
                            character.GetComponent<Rigidbody>().velocity = new Vector3(
                                -speed,
                                character.GetComponent<Rigidbody>().velocity.y,
                                character.GetComponent<Rigidbody>().velocity.z
                                );
                    }


                    float swipeDistVertical = (new Vector3(0, touch.position.y, 0) - new Vector3(0, startPos.y, 0)).magnitude;

                    if (swipeDistVertical > minSwipeDistY)

                    {

                        float swipeValue = Mathf.Sign(touch.position.y - startPos.y);

                        if (swipeValue > 0)//up swipe

                            //character.transform.position += new Vector3(-Time.deltaTime * speed, 0, 0);
                            character.GetComponent<Rigidbody>().velocity = new Vector3(
                                character.GetComponent<Rigidbody>().velocity.x,
                                character.GetComponent<Rigidbody>().velocity.y,
                                speed
                                );

                        else if (swipeValue < 0) //down swipe

                            //character.transform.position += new Vector3(Time.deltaTime * speed, 0, 0);
                            character.GetComponent<Rigidbody>().velocity = new Vector3(
                                character.GetComponent<Rigidbody>().velocity.x,
                                character.GetComponent<Rigidbody>().velocity.y,
                                -speed
                                );
                    }

                    
                    break;
            }
        }
    }




}