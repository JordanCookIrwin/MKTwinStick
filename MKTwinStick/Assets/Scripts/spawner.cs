using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{

    public GameObject zombieObj;
    public float spawnSpeed = 5;
    float spawnTimer = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //spawn a zombie every time the spawnTimer passes

        spawnTimer += Time.deltaTime;

        if (spawnTimer > spawnSpeed)
        {
            GameObject zombieHandler;
            zombieHandler = Instantiate(zombieObj, transform.position, transform.rotation) as GameObject;
            spawnTimer = 0;
        }
    }
}
