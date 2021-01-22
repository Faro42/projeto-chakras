using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoves : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    Vector2 movimento;
    public Animator animator;
    public bool atacando;

    void Update()
    {
        //recebe e processa os inputs
        movimento.x = Input.GetAxisRaw("Horizontal");
        movimento.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movimento.x);
        animator.SetFloat("Vertical", movimento.y);
        animator.SetFloat("speed", movimento.sqrMagnitude);

        if (Input.GetMouseButton(0))
        {
            atacando = true;
            animator.SetFloat("Horizontal", 0);
            animator.SetFloat("Vertical", 0);
            animator.SetFloat("speed", 0);
        }

        if (Input.GetMouseButtonUp(0))
        {
            atacando = false;
            animator.SetFloat("Horizontal", movimento.x);
            animator.SetFloat("Vertical", movimento.y);
            animator.SetFloat("speed", movimento.sqrMagnitude);
        }

    }

    private void FixedUpdate() 
    {
        if (!atacando)
        {
            //processa todos os movimentos baseados em física
            rb.MovePosition(rb.position + movimento * moveSpeed * Time.fixedDeltaTime); 
        }
           
    }

}
