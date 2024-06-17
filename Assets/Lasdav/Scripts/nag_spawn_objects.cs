using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

namespace lasdav
{
    public class nag_spawn_objects : MonoBehaviour
    {
        // public 
        public GameObject go1;
        public GameObject go2;
        public GameObject go3;
        public GameObject go4;
        public GameObject go5;

        // private
        List<GameObject> goList;
        private float r;

        // Start is called before the first frame update
        void Start()
        {
            goList = new List<GameObject>();
        }

        // Update is called once per frame
        void Update()
        {
            Vector3 spawnPosition = new Vector3(0, 0, 0);

            if (Input.GetKeyDown("1"))
            {
                Debug.Log("1 key was pressed");
                spawnObject(go1, spawnPosition);
            }
            if (Input.GetKeyDown("2"))
            {
                Debug.Log("2 key was pressed");
                spawnObject(go2, spawnPosition);
            }
            if (Input.GetKeyDown("3"))
            {
                Debug.Log("3 key was pressed");
                spawnObject(go3, spawnPosition);
            }
            if (Input.GetKeyDown("4"))
            {
                Debug.Log("4 key was pressed");
            }
            if (Input.GetKeyDown("5"))
            {
                Debug.Log("5 key was pressed");
            }

            if (Input.GetKey(KeyCode.A))
            {
                Vector3 rot = this.transform.rotation.ToEuler();
                rot.x += r;
                Quaternion quat = Quaternion.Euler(rot);
                this.transform.rotation = quat;
                r++;
            }
            if (Input.GetKey(KeyCode.S))
            {
                Vector3 rot = this.transform.rotation.ToEuler();
                rot.y += r;
                Quaternion quat = Quaternion.Euler(rot);
                this.transform.rotation = quat;
                r++;
            }
            if (Input.GetKey(KeyCode.D))
            {
                Vector3 rot = this.transform.rotation.ToEuler();
                rot.z += r;
                Quaternion quat = Quaternion.Euler(rot);
                this.transform.rotation = quat;
                r++;
            }
        }

        private void spawnObject(GameObject go, Vector3 spawnPos)
        {
            GameObject spawnedObject = Instantiate(go, spawnPos, Quaternion.identity);
            goList.Add(spawnedObject);

            // do more fun stuff...
        }
    }

}