using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private int dashAvailable;

    private bool canControl = true;

    private bool headFly = false;

    public bool HeadFly { get => headFly; set => headFly = value;}
    
    public int DashAvailable
    {
        get
        {
            return dashAvailable;
        }
        private set
        {
            dashAvailable = value;
        }
    }

    [SerializeField]
    private float hitForce = 5;

    [SerializeField]
    private float chargeTimer = 0;

    
    public float dashForce = 5;


    [SerializeField]
    private float dashTimer = 3;
    private float nextDashTime;
    //[SerializeField]
    //private float availableDashTimer;

    #region SingleTone
    public static PlayerController Instance;


    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(this);
        }
    }
    #endregion


    void Start()
    {
       // myHead.BouncyStartSetup();
    }

    // Update is called once per frame
    void Update()
    {
        if (canControl)
        {
            InputControl();
            InputDash();
        }
        //UpdateTimer();
    }

    void InputControl()
    {
        if (!headFly)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                if (chargeTimer < 1)
                    chargeTimer += Time.deltaTime;
                GameController.Instance.myDude.SetAnimation("Prepare", true);

            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                GameController.Instance.myDude.SetAnimation("Prepare", false);
                GameController.Instance.myDude.SetAnimation("Hit", true);
                GameController.Instance.myHead.GetImpulse(Vector2.one, hitForce * chargeTimer);
                chargeTimer = 0;
                headFly = !headFly;
                nextDashTime=Time.time;
            }
        }
    }

    void InputDash()
    {
        if (headFly)
        {
            if (Input.GetKeyDown(KeyCode.Space) && Time.time>nextDashTime && dashAvailable > 0)// availableDashTimer <= 0)
            {
                GameController.Instance.myHead.GetImpulse(new Vector2(0.3f, -1).normalized, dashForce);

                //availableDashTimer = dashTimer;
                nextDashTime = Time.time + dashTimer;
                changeDashAmount(-1);
               // GameController.Instance.UIUpdate.Invoke();
            }
        }
    }

    public void changeDashAmount(int amount)
    {
        DashAvailable += amount;
    }

    /* Нехорошо, ибо лишние вычисления в апдейте
    void UpdateTimer()
    {
        if (availableDashTimer > 0)
        {
            availableDashTimer -= Time.deltaTime;
        }
    }
    */
}
