using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace lasdav
{
    public class DragObject1 : MonoBehaviour
    {
        private Vector3 mOffset;
        private float mZCoord;
        private GameObject go;

        void Start()
        {
            go = this.gameObject;
        }
        void OnMouseDown()

        {
            mZCoord = Camera.main.WorldToScreenPoint(go.transform.position).z;
            // Store offset = gameobject world pos - mouse world pos
            mOffset = go.transform.position - GetMouseAsWorldPoint();
        }

        private Vector3 GetMouseAsWorldPoint()
        {
            // Pixel coordinates of mouse (x,y)
            Vector3 mousePoint = Input.mousePosition;
            Debug.Log(mousePoint);
            // z coordinate of game object on screen
            mousePoint.z = mZCoord;
            // Convert it to world points
            return Camera.main.ScreenToWorldPoint(mousePoint);
        }

        void OnMouseDrag()

        {
            transform.position = GetMouseAsWorldPoint() + mOffset;
        }

    }
}