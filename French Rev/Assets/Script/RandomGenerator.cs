using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomGenerator : MonoBehaviour
{
    [SerializeField]
    List<GameObject> levelBasics;

    [SerializeField]
    int levelLength = 3;

    int groundLength = 40;

    Vector3 nextInstantiatePosition = Vector3.zero;
    float nextSpawnTriggerX;
    private void Awake()
    {
        Spawn();
    }

    private void Update()
    {
        if (GameController.Instance.myHead.PositionX() > nextSpawnTriggerX)
            Spawn();

    }

    void Spawn()
    {
        for (int i = 0; i < levelLength; i++)
        {
            int rand = Random.Range(0, levelBasics.Count);
            Instantiate(levelBasics[rand], nextInstantiatePosition, Quaternion.identity);
            nextInstantiatePosition += Vector3.right * groundLength;
        }
        nextSpawnTriggerX = nextInstantiatePosition.x - groundLength;
    }
}
