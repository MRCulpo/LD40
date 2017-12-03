using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{


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

    public float moveH;
    public float moveV;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        var isInputMoveH = Input.GetButton("Horizontal");
        var isInputMoveV = Input.GetButton("Vertical");

        if (!isInputMoveH && !isInputMoveV)
            rb2d.MovePosition(rb2d.position);

        //rb2d.velocity += new Vector2(Input.GetAxis("Horizontal") * speed, Input.GetAxis("Vertical") * speed );
        rb2d.MovePosition(new Vector2(rb2d.position.x + (Input.GetAxis("Horizontal") * speed), rb2d.position.y + (Input.GetAxis("Vertical") * speed)));


    }
}

