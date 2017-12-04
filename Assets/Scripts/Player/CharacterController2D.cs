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

    private Transform m_MyTransform;

    private Rigidbody2D rb2d;

    private Animator m_Animator;

    public float moveH;
    public float moveV;

    public Vector2 localScale;
    [SerializeField]
    bool isInputMoveH;
    [SerializeField]
    bool isInputMoveV;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        m_Animator = GetComponent<Animator>();
        m_MyTransform = GetComponent<Transform>();
        localScale = m_MyTransform.localScale;
    }

    void Update()
    {

        float Horizontal = Input.GetAxis("Horizontal");
        float Vertical = Input.GetAxis("Vertical");


        isInputMoveH = Horizontal < 0 || Horizontal > 0 ? true : false;
        isInputMoveV = Vertical < 0 || Vertical > 0 ? true : false; 

        if (!isInputMoveH && !isInputMoveV)
        {
            rb2d.MovePosition(rb2d.position);
            m_Animator.SetBool("Walk", false);
            m_Animator.SetBool("Idle", true);
        }

        //rb2d.velocity += new Vector2(Input.GetAxis("Horizontal") * speed, Input.GetAxis("Vertical") * speed );
        rb2d.MovePosition(new Vector2(rb2d.position.x + (Horizontal * speed), rb2d.position.y + (Vertical * speed)));

        if (isInputMoveH || isInputMoveV)
        {
            m_Animator.SetBool("Walk", true);
            m_Animator.SetBool("Idle", false);

            if ((Input.GetAxis("Horizontal") < 0))
            {
                m_MyTransform.localScale = new Vector2(-localScale.x, m_MyTransform.localScale.y);
            }
            else if((Input.GetAxis("Horizontal") > 0))
            {
                m_MyTransform.localScale = new Vector2(localScale.y, m_MyTransform.localScale.y);
            }
        }
    }
}

