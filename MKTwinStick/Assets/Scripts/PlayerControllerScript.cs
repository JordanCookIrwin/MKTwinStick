using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerScript : MonoBehaviour
{
    public float moveSpeed = 8f;
    public float shootSpeed = 1f;
    float shootTimer = 0;
    float powerTimer = 0;

    public Joystick joystickLeft;
    public Joystick joystickRight;
    bool joystickLeftInUse;
    bool joystickRightInUse;

    public GameObject body;
    public GameObject bulletObj;
    Vector3 moveVector;
    Vector3 lookVector;

    public Animator anim;
    AudioSource bulletSound;

    void Start()
    {
        Physics.IgnoreLayerCollision(8, 10); //ignore player bullets

        bulletSound = GetComponent<AudioSource>();
        anim = transform.GetChild(0).GetChild(0).GetComponent<Animator>(); //get the animator component from the model
    }

    void Update()
    {

        //check which joysticks are currently in use (being pushed in some direction)
        joystickLeftInUse = false;
        if (joystickLeft.Direction != Vector2.zero) { joystickLeftInUse = true; }

        joystickRightInUse = false;
        if (joystickRight.Direction != Vector2.zero) { joystickRightInUse = true; }


        //convert 2d joystick input into a Vector3
        moveVector = new Vector3(joystickLeft.Direction.x, 0f, joystickLeft.Direction.y);

        //If the right joystick is being used, convert that into a Vector3 lookVector
        if (joystickRightInUse)
        {
            lookVector = new Vector3(joystickRight.Direction.x, 0f, joystickRight.Direction.y);
        }
        //otherwise, we will take the moveVector as the lookVector
        else
        {
            lookVector = moveVector;
        }

        //apply the look and move vectors (rotation will only be applied to the child 'body' to stop the camera rotating)
        if (joystickLeftInUse || joystickRightInUse) {
            //this is to stop the character snapping back to looking north when neither joystick is being used
            body.transform.rotation = Quaternion.LookRotation(lookVector);
        }
        transform.Translate(moveVector * moveSpeed * Time.deltaTime, Space.World);

        //update timers
        shootTimer += Time.deltaTime;
        powerTimer += Time.deltaTime;

        //shoot bullets
        if (joystickRightInUse)
        {
            if (shootTimer > shootSpeed)
            {
                GameObject TempBulletHandler;
                TempBulletHandler = Instantiate(bulletObj, body.transform.position + Vector3.up * 1.5f, body.transform.rotation) as GameObject;
                Destroy(TempBulletHandler, 10.0f);
                shootTimer = 0;
                bulletSound.Play(0);
            }
        }

        //reset powerup
        if (powerTimer > 5f)
        {
            shootSpeed = 1f;
        }


        //Animation Controls
        if (joystickRightInUse)
        {
            anim.Play("Fire SniperRifle");
        }
        else if (joystickLeftInUse)
        {
            anim.Play("Run Rifle");
        }
        else
        {
            anim.Play("Idle");
        }


    }

    //machinegun powerup
    public void powerUpFunction()
    {
        shootSpeed = 0.2f;
        powerTimer = 0;
    }
}