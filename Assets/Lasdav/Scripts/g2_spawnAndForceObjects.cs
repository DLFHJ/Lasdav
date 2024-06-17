using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace lasdav
{
    public class g2_spawnAndForceObjects : MonoBehaviour
    {

        public GameObject ball;
        public float stepSize = 500.0f;
        public GameObject paddle;

        private double counter;
        private Vector3 spawnPosition;

        // Start is called before the first frame update
        void Start()
        {
            counter = 0;
            spawnPosition = transform.position;
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            counter++;
            //Debug.Log(counter);

            if (counter % stepSize == 0 || counter == 1)
            {
                //Vector3 spawnPosition = new Vector3(Random.Range(-5f, 5f), 0f, Random.Range(-5f, 5f));
                GameObject spawnedObject = Instantiate(ball, spawnPosition, Quaternion.identity);

                // Apply random force
                Rigidbody rb = spawnedObject.GetComponent<Rigidbody>();
                Vector3 randomForce = new Vector3(Random.Range(-10f, 10f), Random.Range(-10f, 10f), 0f);
                rb.AddForce(randomForce, ForceMode.Impulse);
            }


        }
    }
}
