using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public enum MovingDirection {X, Y}
    public MovingDirection direction;

    [SerializeField]
    private float w;

    [SerializeField]
    private float amplitude;

    Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (direction == MovingDirection.Y)
            transform.position = new Vector3(transform.position.x, startPosition.y + amplitude * Mathf.Cos(w * Time.time), transform.position.z);   
        else if (direction == MovingDirection.X)
            transform.position = new Vector3 ( startPosition.x + amplitude * Mathf.Cos(w * Time.time), transform.position.y, transform.position.z);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<MyHead>() != null)
        {
            MenuAudioController.Instance.PlaySound("ouch floor", true);
        }
    }
}
