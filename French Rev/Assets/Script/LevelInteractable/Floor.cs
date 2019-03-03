using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<MyHead>() != null && PlayerController.Instance.HeadFly)
        {
            MenuAudioController.Instance.PlaySound("ouch floor",true);
        }
    }
}
