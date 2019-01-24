using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer : MonoBehaviour
{

    //follow the player character (this is for the zombies)

    GameObject Player;
    public float movementSpeed = 4;
    
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Body");
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Player.transform);
        transform.position += transform.forward * movementSpeed * Time.deltaTime;
    }
}
