﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    
    walk,
    attack,
    interact
    
}


public class PlayerMovement : MonoBehaviour
{

    public PlayerState currentState;
    public float speed; //How fast the player is moving
    private Rigidbody2D myRigidBody; //player rigidbody
    private Vector3 change; //how much the player's position changes
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {

        currentState = PlayerState.walk;
        animator = GetComponent<Animator>();
        myRigidBody = GetComponent<Rigidbody2D>();
        animator.SetFloat("moveX", 0);
        animator.SetFloat("moveY", -1);
    }

    // Update is called once per frame
    void Update()
    {
        change = Vector3.zero; //reset how much the player has changed every frame
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        if(Input.GetButtonDown("Attack") && currentState != PlayerState.attack)
        {

            StartCoroutine(AttackCo());

        }

        else if (currentState == PlayerState.walk)
        {

            UpdateAnimationAndMove();

        }
            
    }

    private IEnumerator AttackCo()
    {

        animator.SetBool("attacking", true);
        currentState = PlayerState.attack;
        yield return null;
        animator.SetBool("attacking", false);
        yield return new WaitForSeconds(.33f);
        currentState = PlayerState.walk;

    }

    void UpdateAnimationAndMove()
    {
        if (change != Vector3.zero)
        {

            MoveCharacter();
            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y);
            animator.SetBool("moving", true);

        }

        else
        {

            animator.SetBool("moving", false);

        }


    }

    void MoveCharacter()
    {

        change.Normalize();
        myRigidBody.MovePosition(transform.position + change * speed * Time.deltaTime); //player movement

    }

}
