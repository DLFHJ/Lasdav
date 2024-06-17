using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gDR_main_v2 : MonoBehaviour
{
    /* Vars */
    // private
    private int winCount = 12;
    private float stepSize = 1.25f;
    private int numEntitiesInt = 4;
    private int difficulty = 3;

    private KeyCode[] keys = new KeyCode[26];
    private bool lockKeys = false;
    private KeyCode randKey;

    //public
    public GameObject player = null;
    public GameObject summon1 = null;
    public GameObject enemy = null;

    public TextMeshProUGUI textInput;
 

    List<GameObject> entities = new List<GameObject>();

    public GameObject tmpWin;
    public GameObject tmpLose;


    // Start is called before the first frame update
    void Start()
    {
        // enemy Coroutine
        StartCoroutine(decreaseEntities());

        // setup keys
        keys[0] = KeyCode.A;
        keys[1] = KeyCode.B;
        keys[2] = KeyCode.C;
        keys[3] = KeyCode.D;
        keys[4] = KeyCode.E;
        keys[5] = KeyCode.F;
        keys[6] = KeyCode.G;
        keys[7] = KeyCode.H;
        keys[8] = KeyCode.I;
        keys[9] = KeyCode.J;
        keys[10] = KeyCode.K;
        keys[11] = KeyCode.L;
        keys[12] = KeyCode.M;
        keys[13] = KeyCode.N;
        keys[14] = KeyCode.O;
        keys[15] = KeyCode.P;
        keys[16] = KeyCode.Q;
        keys[17] = KeyCode.R;
        keys[18] = KeyCode.S;
        keys[19] = KeyCode.T;
        keys[20] = KeyCode.U;
        keys[21] = KeyCode.V;
        keys[22] = KeyCode.W;
        keys[23] = KeyCode.X;
        keys[24] = KeyCode.Y;
        keys[25] = KeyCode.Z;
    }


    // Update is called once per frame
    void Update()
    {
        // victory
        if (numEntitiesInt >= winCount)
        {
            Debug.Log("you WIN");
            tmpWin.SetActive(true);

            Invoke("reloadScene", 1.0f);
        }

        // defeat
        if (numEntitiesInt <= -1)
        {
            Debug.Log("you LOSE");
            Destroy(player);
            tmpLose.SetActive(true);

            Invoke("reloadScene", 1.0f);
        }

        /* --- main game logic --- */

        /* random input */
        if (lockKeys == false)
        {
            // gen rand input 
            randKey = keys[Random.Range(0, 25)]; // --> 26
            displayKeys(randKey);
            lockKeys = true;
        }
        // show rand input
        
        //Debug.Log(randKey);

        // player - increase minion size
        if (Input.GetKeyDown(randKey))
        {
            numEntitiesInt++;
            lockKeys = false;
        }

        // enemy - decrease minion size
        // --> see Start() & IEnumerator

        // display entities
        displayEntities();
    }

    private void displayEntities()
    {
        /* position + display summons/enemy */
        float xPosEnemy = numEntitiesInt * stepSize;

        for (int index = 0; index < entities.Count; index++)
        {
            Destroy(entities[index]);
        }

        entities.Clear();

        // summons
        
        for (int i = 0; i < numEntitiesInt; i++)
        {
            Vector3 spawnPos = new Vector3(i * stepSize, 0.2f, 0f);
            GameObject spawnedObject = Instantiate(summon1, spawnPos, Quaternion.identity);
            entities.Add(spawnedObject);
        }

        // enemy
        enemy.transform.position = new Vector3(xPosEnemy, 0.22f, 0);
        
        
    }

    private void displayKeys(KeyCode key)
    {
        textInput.text = key.ToString();

        if (key == KeyCode.Y) textInput.text = "Z";
        if (key == KeyCode.Z) textInput.text = "Y";

    }

    IEnumerator decreaseEntities()
    {
        while (true)
        {
            numEntitiesInt--;
            //Debug.Log(numEntitiesInt);
            yield return new WaitForSeconds(1.0f);
        }
    }

    private void reloadScene()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }

}

