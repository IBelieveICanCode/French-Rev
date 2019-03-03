using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MyHead : MonoBehaviour
{
    
    //public Transform club;


    public ParticleSystem blood;

    Rigidbody2D rb; 


    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();      
    }

    private void Update()
    {
        LooseSpeed();
        //print(rb.velocity.magnitude);
    }


    void OnTriggerEnter2D(Collider2D col)
      {
        if (col.tag == "Portal1")
            
            col.GetComponentInParent<Portals>().TranslateToPortal2();
        if (col.tag == "Portal2")
            
            col.GetComponentInParent<Portals>().TranslateToPortal1();
        if (col.tag == "Bomb")
            OnBombEnter(col.GetComponent<Bomb>().explosionForce);
        if (col.tag == "Spring")
            SpringHitHead(col.GetComponent<SpringPlatform>().springForce);
    }

    private void SpringHitHead(float springForce)
    {
        GetImpulse(Vector2.one, springForce);
    }

    void OnBombEnter(float force)
    {
        rb.velocity = new Vector2(rb.velocity.x, 0f);
        GetImpulse(Vector2.up, force);
    }

    public void TakeHead(float birdSpeed)
    {
        rb.simulated = !rb.simulated;
        if (rb.simulated)
            rb.velocity = new Vector2(birdSpeed + rb.velocity.x * (birdSpeed / Mathf.Abs(birdSpeed)), 0f);

    }

    public void setNewPosition(Vector3 newPosition)
    {
        transform.position = newPosition;
    }
        

    public void GetImpulse(Vector2 direction, float force)
    {
        rb.AddForce(direction * force, ForceMode2D.Impulse);
    }

    public string CalculateScore()
    {
        return Mathf.Round((transform.position.x * 10)).ToString();
    }

    public void LooseSpeed()
    {
        if (PlayerController.Instance.DashAvailable <=0 && rb.velocity.magnitude <= 2.5)
        {
            rb.velocity = rb.velocity * 0.9f;
            if (rb.velocity.magnitude < 0.1f && PlayerController.Instance.HeadFly)
            {
                GameController.Instance.GameOver.Invoke();
                enabled = false;
            }
        }       
    }

    public float PositionX()
    {
        return transform.position.x;
    }

    public void SimulationHead(bool state)
    {
        rb.simulated = state;
    }

}
