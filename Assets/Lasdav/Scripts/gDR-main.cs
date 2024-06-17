using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gDR_main : MonoBehaviour
{
    /* Vars */
    // private
    private int winCount = 12;
    private float stepSize = 1.25f;
    private int numEntitiesInt = 4;
    private int difficulty = 3;

    private KeyCode[] keys = new KeyCode[4];
    private bool lockKeys = false;
    private KeyCode randKey;

    //public
    public GameObject player = null;
    public GameObject summon1 = null;
    public GameObject enemy = null;

    public Image keysImg = null;
    public Sprite keyLeftSprite = null;
    public Sprite keyRightSprite = null;
    public Sprite keyUpSprite = null;
    public Sprite keyDownSprite = null;

    List<GameObject> entities = new List<GameObject>();

    public GameObject tmpWin;
    public GameObject tmpLose;


    // Start is called before the first frame update
    void Start()
    {
        // enemy Coroutine
        StartCoroutine(decreaseEntities());

        // setup keys
        keys[0] = KeyCode.LeftArrow;
        keys[1] = KeyCode.RightArrow;
        keys[2] = KeyCode.UpArrow;
        keys[3] = KeyCode.DownArrow;
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
            randKey = keys[Random.Range(0, 4)];
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
       switch (key)
        {
            case KeyCode.LeftArrow:
                keysImg.sprite = keyLeftSprite;
                break;
            case KeyCode.RightArrow:
                keysImg.sprite = keyRightSprite;
                break;
            case KeyCode.UpArrow:
                keysImg.sprite = keyUpSprite;
                break;
            case KeyCode.DownArrow:
                keysImg.sprite = keyDownSprite;
                break;
        }
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

