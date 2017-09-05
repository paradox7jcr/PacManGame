using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move_Prot : MonoBehaviour
{
    public int playerSpeed = 5;

    public bool facingRight = false;
    public bool facingUp = false;
    public bool facingDown = false;
    public bool facingLeft = false;

    public float moveX;

    public float moveY;

    public Sprite spriteRight;
    public Sprite spriteLeft;
    public Sprite spriteUp;
    public Sprite spriteDown;

    private SpriteRenderer spriteRenderer;

    // Update is called once per frame
    void Update ()
	{
        PlayerMove();
        ChangePlayerSprite();
    }

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); // we are accessing the SpriteRenderer that is attached to the Gameobject
        if (spriteRenderer.sprite == null) // if the sprite on spriteRenderer is null then
            spriteRenderer.sprite = spriteRight; // set the sprite to sprite1
    }

    void PlayerMove()
    {
        moveX = Input.GetAxis("Horizontal");
        moveY = Input.GetAxis("Vertical");

        if (moveX < 0.0f)
        {
            TurnPlayer(1);
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-1*playerSpeed, 0.0f);
        }
        else if (moveX > 0.0f)
        {
            TurnPlayer(0);
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(playerSpeed, 0.0f);
        }
        if (moveY < 0.0f)
        {
            TurnPlayer(2);
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, -1*playerSpeed);
        }
        else if (moveY > 0.0f)
        {
            TurnPlayer(3);
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, playerSpeed);
        }

        
    }

void ChangePlayerSprite()
    {
        if (facingRight)
           spriteRenderer.sprite = spriteRight;
        else if(facingLeft)
            spriteRenderer.sprite = spriteLeft;
        else if (facingUp)
            spriteRenderer.sprite = spriteUp;
        else
            spriteRenderer.sprite = spriteDown;
    }

    void TurnPlayer(int x)
    {
        if (x == 0)
        {
            facingRight = true;
            facingLeft = false;
            facingDown = false;
            facingUp = false;
        }
        else if (x == 1)
        {
            facingRight = false;
            facingLeft = true;
            facingDown = false;
            facingUp = false;
        }
        else if (x == 2)
        {
            facingRight = false;
            facingLeft = false;
            facingDown = true;
            facingUp = false;
        }
        else
        {
            facingRight = false;
            facingLeft = false;
            facingDown = false;
            facingUp = true;
        }
    }
}
