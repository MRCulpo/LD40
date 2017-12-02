using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : MonoBehaviour {


    public float speed;             //Floating point variable to store the player's movement speed.

    //[SerializeField, Range(1, 10)]
    //private float ForceJump;

    [SerializeField]
    private float MaxMultiplierVelocity;
 //   [SerializeField]
	//private float FallMultiplier;
	//[SerializeField]
	//private float LowJumpMultiplier;

    private Rigidbody2D rb2d;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update ()
    {

        var isInputMoveH = Input.GetButton("Horizontal");
        var isInputMoveV = Input.GetButton("Vertical");
        var moveH = Input.GetAxis("Horizontal");
        var moveV = Input.GetAxis("Vertical");

        ///Jump Phisics

        {
            //if (rb2d.velocity.y < 0)
            //{
            //    rb2d.velocity += Vector2.up * Physics2D.gravity.y * (FallMultiplier - 1) * Time.deltaTime;
            //}
            //else if (rb2d.velocity.y > 0 && !Input.GetButton("Jump"))
            //{
            //    rb2d.velocity += Vector2.up * Physics2D.gravity.y * (LowJumpMultiplier - 1) * Time.deltaTime;
            //}

            //if (Input.GetButtonDown("Jump"))
            //{
            //    rb2d.velocity = Vector2.up * ForceJump;
            //}
        }

        ///Move Phisics

        {
            //if (rb2d.velocity.x != MaxMultiplierVelocity && isInputMove)
            rb2d.velocity = new Vector2(MaxMultiplierVelocity * moveH, MaxMultiplierVelocity * moveV);

            if (!isInputMoveH && !isInputMoveV)
                rb2d.velocity = new Vector2(0, 0);

            rb2d.velocity += new Vector2( moveH * speed * Time.deltaTime, moveV * speed * Time.deltaTime);
        }

    }
}

