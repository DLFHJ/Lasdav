using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testMov : MonoBehaviour
{
    private int speed = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 Movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        this.gameObject.transform.position += Movement * speed * Time.deltaTime;
    }

    

}
