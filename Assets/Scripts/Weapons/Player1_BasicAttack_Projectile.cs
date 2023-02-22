using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))] // required to know the player's current and last vectors
public class Player1_BasicAttack_Projectile : Projectile
{
    private GameObject player;
    private Animator animator;

    float offset = 0;

    void Start() {
        speed = 12;
        lifeTime = 0.3f;
        hits = 99;

        player = GameObject.FindWithTag("Player");
        animator = GetComponent<Animator>();
    }

    new void Move(float deltaTime, float horizontalVector) {
        transform.position = player.transform.position;

        // flip direction if facing left
        if (horizontalVector < 0) transform.eulerAngles = new Vector3(0, 180, 0);
        else transform.eulerAngles = new Vector3(0, 0, 0);
    }

    new void Update() {
        // get most up to date horizontal vector
        float horiz = Input.GetAxis("Horizontal");

        Move(Time.deltaTime, horiz);
        base.Update();
    }
}
