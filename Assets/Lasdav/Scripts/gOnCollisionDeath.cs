using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gOnCollisionDeath : MonoBehaviour
{
    public GameObject player;
    Vector3 startPos;
    public AudioSource aSrc;

    // Start is called before the first frame update
    void Start()
    {
        startPos = player.transform.position;

        //DontDestroyOnLoad(aSrc);
        //aSrc.UnPause();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("#---#-YOU LOSE-#---#");
        Invoke("Reset", 1f);
    }

    private void Reset()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        player.transform.position = startPos;
        player.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
}
