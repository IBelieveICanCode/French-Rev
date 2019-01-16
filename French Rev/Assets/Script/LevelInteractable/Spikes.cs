using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    private void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<MyHead>() != null)
        {
            collision.gameObject.GetComponent<Rigidbody2D>().simulated = false;

            collision.transform.SetParent(transform);

            Instantiate(GameController.Instance.myHead.blood, new Vector2(collision.transform.position.x, collision.transform.position.y) , Quaternion.identity);

            GameController.Instance.GameOver.Invoke();
        }
    }
}
