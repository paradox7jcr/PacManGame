using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move_Prot : MonoBehaviour
{
    public int playerSpeed = 10;

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

        if (moveX < 0.0f && facingRight == false)
        {
            FlipPlayerX();
        }
        else if (moveX > 0.0f && facingRight == true)
        {
            FlipPlayerX();
        }
        else if (moveY < 0.0f && facingUp == false)
        {
            FlipPlayerY();
        }
        else if (moveY > 0.0f && facingUp == true)
        {
            FlipPlayerY();
        }

        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2 (moveX * playerSpeed, moveY * playerSpeed);
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
