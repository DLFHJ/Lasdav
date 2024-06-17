using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class g3_movement : MonoBehaviour
{
    Rigidbody rb;
    public float sThrust = 10f;
    public float sJump = 200f;

    bool lockJump = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       //Debug.Log(lockJump);

        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (lockJump == false)
            {
                
                rb.AddForce(transform.up * sJump);
                lockJump = true;
            }
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddForce(transform.right * sThrust);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddForce(new Vector3(-1, 0, 0) * sThrust);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (lockJump) 
        {
            lockJump = false;
        }
    }
}
