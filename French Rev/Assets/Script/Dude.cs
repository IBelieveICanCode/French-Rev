using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dude : MonoBehaviour
{
    private Animator animator;

    private Rigidbody2D rb;



    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }



    public void SetAnimation(string name, bool animate)
    {
        animator.SetBool(name, animate);
    }


}
