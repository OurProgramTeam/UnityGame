using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VariablesAndBasicFunctions : MonoBehaviour
{

    AudioSource audio;

    //To watch in Unity
    [SerializeField]
    private int i = 0;

    //Awake before start
    private void Awake()
    {
        print("Awake Hi!");
    }

    // Use this for initialization
    void Start()
    {
        print("Hi!");
    }

    private void FixedUpdate()
    {
        //Debug.LogFormat("Fixed update delta time: {0}", Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.LogFormat("Update delta time: {0}", Time.deltaTime);
    }
}
