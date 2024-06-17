using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace lasdav
{
    public class DragObject : MonoBehaviour
    {
        private GameObject go;
        RaycastHit hit;
        private float throwForce = 2f;
        Vector3 lastMousePosition;

        void Start()
        {
            go = this.gameObject;
        }

        void OnMouseDown()
        {
            lastMousePosition = Input.mousePosition;
        }

        void OnMouseDrag()
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {
                // Calculate the desired distance from the camera.
                float desiredDistance = 1f; // Adjust this value as needed.

                // Calculate the new position with the desired distance.
                Vector3 newPosition = hit.point + Camera.main.transform.forward * desiredDistance;

                // height
                Vector3 yAxisHeight = Vector3.up * (go.transform.localScale.y / .5f);

                // Set your object's position to the new position.
                go.transform.position = newPosition + yAxisHeight;
                //go.transform.rotation = new Quaternion.Euler(newPosition);
               // Quaternion quat = Quaternion.Euler(newPosition);

            }
        }

        private void OnMouseUp()
        {
            //Vector3 mouseDelta = Input.mousePosition - lastMousePosition;
            //ector3 throwVelocity = Camera.main.transform.TransformDirection(mouseDelta) * throwForce;
            //go.GetComponent<Rigidbody>().AddForce(throwVelocity, ForceMode.Force);
        }


    }
}