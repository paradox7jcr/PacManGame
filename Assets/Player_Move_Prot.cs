using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move_Prot : MonoBehaviour
{
    public int playerSpeed = 5;

    public bool facingRight = false;

    public bool facingUp = false;

    public float moveX;

    public float moveY;
	
	// Update is called once per frame
	void Update ()
	{
	    PlayerMove();
	}

    void PlayerMove()
    {
        moveX = Input.GetAxis("Horizontal");
        moveY = Input.GetAxis("Vertical");

        if (moveX < 0.0f)
        {
            //FlipPlayerX();
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-1*playerSpeed, 0.0f);
        }
        else if (moveX > 0.0f)
        {
            //FlipPlayerX();
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(playerSpeed, 0.0f);
        }
        if (moveY < 0.0f)
        {
            //FlipPlayerY();
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, -1*playerSpeed);
        }
        else if (moveY > 0.0f)
        {
            //FlipPlayerY();
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, playerSpeed);
        }

        
    }

    void FlipPlayerX()
    {
        facingRight = !facingRight;
    }

    void FlipPlayerY()
    {
        facingUp = !facingUp;
    }
}
