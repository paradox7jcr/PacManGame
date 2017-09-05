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

    public float moveXPad;
    public float moveYPad;
    public float moveXStick;
    public float moveYStick;
	
    public Sprite spriteRight;
    public Sprite spriteLeft;
    public Sprite spriteUp;
    public Sprite spriteDown;

    private SpriteRenderer spriteRenderer;

    // Update is called once per frame
    void Update ()
	{
        PlayerMove();
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
		
		//Used for PS4 d-pad and leftStick controls
        //TODO: Figure out how to deal with conflicting controls in
        //a less clunky way than adding extra variables
		moveXPad = Input.GetAxis("DPAD_X");
        moveYPad = Input.GetAxis("DPAD_Y");
        moveXStick = Input.GetAxis("Horizontal_Stick");
        moveYStick = Input.GetAxis("Vertical_Stick");

        if (moveX < 0.0f || moveXPad < 0.0f || moveXStick < 0.0f)
        {
            TurnPlayer("left");
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-1*playerSpeed, 0.0f);
        }
        else if (moveX > 0.0f || moveXPad > 0.0f || moveXStick > 0.0f)
        {
            TurnPlayer("right");
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(playerSpeed, 0.0f);
        }
        if (moveY < 0.0f || moveYPad < 0.0f || moveYStick < 0.0f)
        {
            TurnPlayer("down");
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, -1*playerSpeed);
        }
        else if (moveY > 0.0f || moveYPad > 0.0f || moveYStick > 0.0f)
        {
            TurnPlayer("up");
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, playerSpeed);
        }

        
    }

    void TurnPlayer(string direction)
    {
        this.facingRight = false;
        this.facingLeft = false;
        this.facingUp = false;
        this.facingDown = false;

        switch (direction)
        {
            case "left":
                spriteRenderer.sprite = spriteLeft;
                break;
            case "right":
                spriteRenderer.sprite = spriteRight;
                break;
            case "down":
                spriteRenderer.sprite = spriteDown;
                break;
            case "up":
                spriteRenderer.sprite = spriteUp;
                break;
            default: break;
        }
    }
}
