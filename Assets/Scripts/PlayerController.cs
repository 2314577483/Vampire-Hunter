using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    private Rigidbody2D rigidbody2d;
    private Vector2 lastMotionVector; 
    private Vector2 motionVector;
    private Animator anim;
    private bool isMoving;

    void Awake()
    {
        anim = GetComponent<Animator>();
        rigidbody2d = GetComponent<Rigidbody2D>();
        rigidbody2d.gravityScale = 0; // ensure no gravity, our game is 2D
        gameObject.tag = "Player";
    }

    private void Update()
    {
        // get 2d components, construct vector
        float horiz = Input.GetAxisRaw("Horizontal");
        float vert = Input.GetAxisRaw("Vertical");
        motionVector = new Vector2(horiz, vert);

        // update animator
        anim.SetFloat("horizontal", horiz);

        // for anims: ignore vertical if moving horizontally
        if (horiz != 0) 
            anim.SetFloat("vertical", 0.0f);
        else 
            anim.SetFloat("vertical", vert);
            
        isMoving = horiz != 0 || vert != 0;
        anim.SetBool("isMoving", isMoving);

        // if player is moving, then save the vector and update animator
        if (isMoving)
        {
            lastMotionVector = new Vector2(horiz, vert).normalized;

            anim.SetFloat("lastHorizontal", horiz);
            anim.SetFloat("lastVertical", vert);
        }

        Move();
    }

    private void Move()
    {
        // set object's velocity
        rigidbody2d.velocity = motionVector * speed;
    }
}