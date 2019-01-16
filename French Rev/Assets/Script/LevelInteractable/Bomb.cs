using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    Rigidbody2D rb;


    [SerializeField]
    public float explosionForce;

    [SerializeField]
    private ParticleSystem particleBomb;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<MyHead>() != null)
        {
            //rb = collision.gameObject.GetComponent<Rigidbody2D>();
            //GameController.Instance.myHead.GetImpulse(direction, PlayerController.Instance.dashForce - 1);
            Instantiate(particleBomb, transform.position, Quaternion.identity);
            Destroy(gameObject);
         
            
        }
    }
    


}
