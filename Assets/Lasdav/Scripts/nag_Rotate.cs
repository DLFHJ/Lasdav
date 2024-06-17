using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace lasdav
{
    public class nag_Rotate : MonoBehaviour
    {

        public GameObject sun;
        public float rotSpeed;
        public Vector3 axis;
        // Start is called before the first frame update
        void Start()
        {
            axis = new Vector3(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
            rotSpeed = Random.Range(5f, 100f);
        }

        // Update is called once per frame
        void Update()
        {
            this.transform.RotateAround(sun.transform.position, axis, rotSpeed * Time.deltaTime);
        }
    }
}
