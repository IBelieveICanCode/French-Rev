using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{

    void FixedUpdate()
    {
        transform.position = new Vector2(GameController.Instance.myHead.PositionX(), transform.position.y);
    }
}
