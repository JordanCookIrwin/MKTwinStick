using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickup : MonoBehaviour
{
    public float spinSpeed = 20f;
    public float floatSpeed = 5f;
    public float floatHeight = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        //spin and float (just to look nice)
        Vector3 pos = transform.position;
        float newY = Mathf.Sin(Time.time * floatSpeed) * floatHeight + 1.5f;
        transform.position = new Vector3(pos.x, newY, pos.z);
        
        transform.Rotate(Vector3.up, spinSpeed * Time.deltaTime);
    }

    //powerup pickup
    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.transform.parent.GetComponent<PlayerControllerScript>().powerUpFunction();
            Destroy(gameObject);
        }
    }

}
