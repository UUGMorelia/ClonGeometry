using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public int currentDiamonds = 0;

    public int speed;

    public int forceJump = 5;

    bool canJump = false, doubleJump = false, executeDoubleJump = false, onGround;

    Rigidbody2D rbd2D;

    private static Player instance;
    public static Player Instance
    {
        get
        {
            if(instance == null)
            {
                Debug.LogError("player is Null");
            }
            return instance;
        }
    }

    // Use this for initialization
    void Awake ()
    {
        instance = this;

        rbd2D = GetComponent<Rigidbody2D>();
    }

    float nextAngle;
	// Update is called once per frame
	void Update ()
    {
        rbd2D.velocity = new Vector2(speed, rbd2D.velocity.y);

        for (int i = 0; i < Input.touchCount; i++)
        {
            Vector3 touchPosition = Camera.main.ScreenToViewportPoint(Input.touches[i].position);

            switch (Input.touches[i].phase)
            {
                case TouchPhase.Began:
                    if (touchPosition.x > 0.7 && touchPosition.y < 0.5)
                    {
                        //Debug.Log("Salto " + touchPosition);
                        if (onGround)
                            canJump = true;
                        else if(!executeDoubleJump)
                        {
                            doubleJump = true;
                            executeDoubleJump = true;                           
                        }
                    }     
                    break;
                case TouchPhase.Ended:
                              
                    break;
            }
        }
        
        if(transform.eulerAngles.z < nextAngle && !onGround)
        {
            transform.Rotate(Vector3.forward * 75 * Time.deltaTime);
        }
    }

    void FixedUpdate()
    {
        if (canJump && onGround)
        {
            rbd2D.AddForce(Vector2.up * forceJump, ForceMode2D.Impulse);
            nextAngle = transform.eulerAngles.z + 90f;
            Debug.Log(nextAngle);
            canJump = false;
            onGround = false;
        }
        else if(doubleJump && executeDoubleJump)
        {
            if(rbd2D.velocity.y > 0.1f)
                rbd2D.AddForce(Vector2.up * 5, ForceMode2D.Impulse);
            if(rbd2D.velocity.y <-0.1)
                rbd2D.AddForce(Vector2.up * 12, ForceMode2D.Impulse);

            nextAngle = transform.eulerAngles.z + 90f;
            Debug.Log(nextAngle);
            doubleJump = false;
        }

        if (rbd2D.velocity.y < -1f)
        {
            rbd2D.AddForce(Vector2.down * 5, ForceMode2D.Force);
            //Debug.Log("Cayendo");
        }
    }

    void OnCollisionEnter2D(Collision2D obj)
    {
        if(obj.gameObject.CompareTag("Ground"))
        {
            onGround = true;
            executeDoubleJump = false;
        }
    }
}
