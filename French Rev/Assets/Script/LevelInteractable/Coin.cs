using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
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
        transform.position = new Vector3(transform.position.x, startPosition.y + amplitude * Mathf.Cos(w * Time.time), transform.position.z);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<MyHead>() != null)
        {
            MenuAudioController.Instance.PlaySound("Coin",false);
            PlayerController.Instance.changeDashAmount(+1);
            Destroy(gameObject);
        }
    }
}
