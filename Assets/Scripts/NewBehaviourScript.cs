using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject target;
    public float desireDistance = 7f;
    public float pitch = 0f;
    public float yaw = 0f;
    public float roll = 0f;
    float pitchMin = -40f;
    float pitchMax = 60f;
    public float sensity = 5f;

    // Update is called once per frame
    void Update()
    {
        pitch -= sensity * Input.GetAxis("Mouse Y");
        yaw += sensity * Input.GetAxis("Mouse X");

        transform.position = target.transform.position - desireDistance * transform.forward + Vector3.up * 3.5f;

        pitch = Mathf.Clamp(pitch, pitchMin, pitchMax);

        transform.localEulerAngles = new Vector3(pitch, yaw, roll);
    }
}
