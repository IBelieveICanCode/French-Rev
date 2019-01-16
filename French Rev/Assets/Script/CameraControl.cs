using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
[RequireComponent (typeof(CinemachineVirtualCamera))]
public class CameraControl : MonoBehaviour
{
    public bool border = true;

    public float minX;
    public float maxX;

    public float minY;
    public float maxY;


    CinemachineVirtualCamera camera;
    // Start is called before the first frame update
    void Start()
    {
        camera = GetComponent<CinemachineVirtualCamera>();
     }

    // Update is called once per frame
    void Update()
    {
        //if (camera.m_Lens.OrthographicSize<6)
            //camera.m_Lens.OrthographicSize += 0.1f;
        if (border == true)
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, minX, maxX), Mathf.Clamp(transform.position.y, minY, maxY), transform.position.z);
        }
    }
}
