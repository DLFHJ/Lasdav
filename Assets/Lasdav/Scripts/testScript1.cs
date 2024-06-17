using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class testScript1 : MonoBehaviour
{
    // nicht vergessen zu verknüpfen!
    public GameObject go; // GameObject welches dupliziert werden soll

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() //FixedUpdate
    {
        // bitte if-Abfrage oder destry sonst wird jedes frame 1 object gespawnt

        Vector3 position = new Vector3(0,0,0); // position am Ursprung 0,0,0
        GameObject clone = (GameObject) Instantiate(go, position, Quaternion.identity);
        clone.tag = "enemy"; // hier kannst du tags setzen falls nötig
        // Destroy(clone, 3.0f);

        // das hier alleine ist auch möglich
        Instantiate(go, position, Quaternion.identity);
    }


}
