using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coroutine : MonoBehaviour
{

    public GameObject obj;

    private void Start()
    {
        Invoke("Inst", 2f);
    }

    void Inst()
    {
        Instantiate(obj, new Vector3(Random.Range(-10f, 10f), 0f, Random.Range(-10f, 10f)), Quaternion.identity);
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.F))
        {
            StartCoroutine(InstObj());
        }
    }

    IEnumerator InstObj()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.5f);
            Instantiate(obj, new Vector3(Random.Range(-10f, 10f), 0f, Random.Range(-10f, 10f)), Quaternion.identity);
        }
    }
}
