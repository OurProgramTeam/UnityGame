using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionOnTrigger : MonoBehaviour
{
    public GameObject obj;
    private GameObject instObj;
    [SerializeField]
    private float speed = 4f;

    private void Start()
    {
        instObj = Instantiate(obj, new Vector3(0f, 0f, 0f), Quaternion.identity) as GameObject;
    }

    private void Update()
    {
        float zPos = Input.GetAxis("Vertical");

        instObj.transform.Translate(Vector3.forward * speed * zPos * Time.deltaTime);
    }


}
