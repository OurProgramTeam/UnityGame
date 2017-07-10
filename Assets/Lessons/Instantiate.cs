using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiate : MonoBehaviour {

    public GameObject[] objects;
    private GameObject instObj;

    private void Start()
    {
        int rand = Random.Range(0, objects.Length - 1);
        instObj = Instantiate(objects[rand], objects[rand].transform.position, Quaternion.identity) as GameObject;
    }
}
