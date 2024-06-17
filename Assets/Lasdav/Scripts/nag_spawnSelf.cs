using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nag_spawnSelf : MonoBehaviour
{
    private int timer = 0;
    public GameObject clone;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(logEverySecond());
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    private void spawnMe()
    {
        
    }

    IEnumerator logEverySecond()
    {
        while (true)
        {
            Instantiate(clone, this.gameObject.transform.position, Quaternion.identity);
            

            yield return new WaitForSeconds(.1f);
        }
    }
}
