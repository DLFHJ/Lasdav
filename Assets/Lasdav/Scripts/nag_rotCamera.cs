using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nag_rotCamera : MonoBehaviour
{
    private GameObject go;
    RaycastHit hit;
    private float throwForce = 2f;
    Vector3 lastMousePosition;

    void Start()
    {
        go = this.gameObject;
    }

    private void Update()
    {
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Quaternion quat = Quaternion.Euler(worldPosition);
        go.transform.rotation = quat;
    }
}
