using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class testScript3 : MonoBehaviour
{

    //public float multiplier;
    public GameObject go1 = null;
    //public GameObject go2 = null;
    public GameObject cursor = null;

    private bool switcher = true;
    private int counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate() //FixedUpdate
    {
        Vector3 pos = cursor.transform.position;
        Vector3 offset = new Vector3(0.0f, 10.0f, 0.0f);

        GameObject clone = (GameObject)Instantiate(go1, pos + offset, Quaternion.identity);
        clone.tag = "enemy";

        var mat = this.gameObject.GetComponent<Renderer>();
        mat.material.SetColor("_Color", UnityEngine.Random.ColorHSV());

        Destroy(clone, 3.0f);

        if (Input.GetMouseButtonDown(1))
        {
        }

    }

   

}
