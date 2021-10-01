using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    public float runSpeed = 40f;

    public GameObject EscapeMenuCanvas;
    public GameObject DeathMenuCanvas;

    float horizontalMove = 0f;

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if(!DeathMenuCanvas.activeSelf && !EscapeMenuCanvas.activeSelf) 
            animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, false);
    }
}
