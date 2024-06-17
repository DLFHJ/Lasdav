using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeColor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.tag == "enemy")
        {
            var mat = collision.collider.gameObject.GetComponent<Renderer>();
            mat.material.SetColor("_Color", UnityEngine.Random.ColorHSV());
        }
    }
}
