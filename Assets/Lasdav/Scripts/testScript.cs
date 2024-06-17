using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testScript : MonoBehaviour
{

    public float multiplier;
    public GameObject go1 = null;
    public GameObject go2 = null;
    public GameObject cursor = null;

    private bool switcher = true;
    private int counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() //FixedUpdate
    {
        //multiplier = Random.Range(0.0f, 10.0f);
        //GetComponent<Rigidbody>().AddForce(new Vector3(1.0f, 0.0f, 0.0f) * multiplier); 
        if (go1 != null && go2 != null) 
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 pos = cursor.transform.position;
                Vector3 offset = new Vector3(0.0f, 10.0f, 0.0f);
                
                

                if (switcher) 
                {
                    GameObject clone = (GameObject) Instantiate(go1, pos + offset, Quaternion.identity);
                    clone.tag = "enemy";
                    Destroy(clone, 3.0f);
                } else {
                    GameObject clone = (GameObject)Instantiate(go2, pos + offset, Quaternion.identity);
                    Destroy(clone, 3.0f);
                }
                
                switcher = !switcher;
                counter++;
                
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("You have created: " + counter + " objects thus far!");
            
        }

    }

   

}
