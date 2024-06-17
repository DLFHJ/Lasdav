using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace lasdav
{
    public class g2_movementScript : MonoBehaviour
    {
        Vector3 worldPosition;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void FixedUpdate() //FixedUpdate
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = Camera.main.nearClipPlane + 30;
            worldPosition = Camera.main.ScreenToWorldPoint(mousePos);

            Vector3 changedPos = this.gameObject.transform.position;
            changedPos.x = worldPosition.x;

            this.gameObject.transform.position = changedPos;
        }


    }
}
