using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scale : MonoBehaviour
{

    private void OnMouseDown()
    {
        var localScale = transform.localScale;
        transform.localScale = new Vector3(localScale.x / 2, localScale.y / 2, localScale.z / 2);
    }

    //with as button if on this object
    private void OnMouseUpAsButton()
    {
        var localScale = transform.localScale;
        transform.localScale = new Vector3(localScale.x * 2, localScale.y * 2, localScale.z * 2);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.LogFormat("Enter: {0}", collision.gameObject.name);
    }

    private void OnCollisionExit(Collision collision)
    {
        Debug.LogFormat("Exit: {0}", collision.gameObject.name);
    }

    private void OnCollisionStay(Collision collision)
    {
        Debug.LogFormat("Stay: {0}", collision.gameObject.name);
    }
}
