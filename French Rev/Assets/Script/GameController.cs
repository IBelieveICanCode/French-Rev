using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class GameController : MonoBehaviour
{ 


    public UnityEvent UIUpdate;

    public static GameController Instance;

    public UnityEvent GameOver;

    public Dude myDude;

    public MyHead myHead;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(this);
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        if(UIUpdate!=null)
            UIUpdate.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        if (UIUpdate != null)
            UIUpdate.Invoke();
    }




}
