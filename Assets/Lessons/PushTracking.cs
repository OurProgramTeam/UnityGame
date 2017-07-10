using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushTracking : MonoBehaviour
{
    public GameObject obj;
    public float range = 5f;
    public float moveSpeed = 3f;
    public float turnSpeed = 40f;

    void Update()
    {
        //float h = Input.GetAxis("Horizontal");

        //float xPos = h * range;

        //obj.transform.position = new Vector3(xPos, 0f, 0f);

        if (Input.GetKey(KeyCode.UpArrow))
        {
            obj.transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            obj.transform.Translate(-Vector3.forward * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            obj.transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);
            Debug.Log(turnSpeed);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            obj.transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
        }
    }
}
