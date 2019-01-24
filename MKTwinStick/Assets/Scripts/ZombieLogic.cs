using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieLogic : MonoBehaviour
{
    public GameObject powerupObj;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Bullet(Clone)")
        {
            Death();
        }
    }

    void Death()
    {

        Destroy(GetComponent<Transform>().GetChild(8).gameObject); //destory the rig

        //There are a bunch of children body parts in this zombie. On death, i want these to go flying
        foreach (Transform child in transform)
        {
            Rigidbody gameObjectsRigidBody = child.gameObject.AddComponent<Rigidbody>(); // Add a rigidbody.
            BoxCollider gameObjectsBoxCollider = child.gameObject.AddComponent<BoxCollider>(); // Add a Collider.
            Destroy(child.gameObject, 1.0f);

        }
        transform.DetachChildren();

        //chance to drop powerup
        if (Random.value < 0.2f)
        {
            GameObject powerupHandler;
            powerupHandler = Instantiate(powerupObj, transform.position, transform.rotation) as GameObject;
        }

        Destroy(gameObject);

    }
}
