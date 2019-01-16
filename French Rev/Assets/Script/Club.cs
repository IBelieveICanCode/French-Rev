using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Club : MonoBehaviour
{
    private Quaternion startingRotation;

    [SerializeField]
    float speed = 5;

    float force = 2;

    public KeyCode hitThisButton;

    public float chargeTimer = 0;


    //new
    [Header("New")]
    [SerializeField]
    float maxDeg = 45;
    [SerializeField]
    float w = 1;
    bool hitted = false;
    [SerializeField]
    float resetSpeed;

    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        startingRotation = transform.rotation;
        rb = GetComponent<Rigidbody2D>();
    }
    float t;
    // Update is called once per frame
    void Update()
    {
        //ControlKeys();
        if (!hitted)
        {
            if (Input.GetKeyDown(hitThisButton)) {
                t = Time.time;
            }
            if (Input.GetKey(hitThisButton))
            {
                float z = -Mathf.Abs(maxDeg * Mathf.Sin(w * (Time.time-t)));
                transform.eulerAngles = new Vector3(0f, 0f, z);
               
            }

            else if (Input.GetKeyUp(hitThisButton))
            {
                hitted = !hitted;
                StartCoroutine(Hit(transform.rotation.z));
            }
        }
    }

    IEnumerator Hit(float ourAngle)
    {
        float z =2* ourAngle*180/Mathf.PI;
        while (z <= 0 - 0.01)
        {
            print(z);
            z += resetSpeed;
            transform.eulerAngles = new Vector3(0f, 0f, z);
            // transform.rotation = Quaternion.Lerp(transform.rotation,, Time.deltaTime * speed);
            yield return new WaitForSeconds(0.01f);
        }
        print("ended");
    }

    void ControlKeys()
    {
        if (Input.GetKey(hitThisButton))
        {
            chargeTimer += Time.deltaTime;
            StartCoroutine(Rotate(-45));
        }
        if ((Input.GetKeyUp(hitThisButton)) && (chargeTimer > 2))
        {
            //rb.transform.rotation = Quaternion.AngleAxis(45, Vector3.forward);
            StartCoroutine(Rotate(45));
            chargeTimer = 0;
        }
        if ((Input.GetKeyUp(hitThisButton)) && (chargeTimer < 2))
        {
            chargeTimer = 0;
        }
    }

    IEnumerator Rotate(float rotationAmount)
    {
        Quaternion finalRotation = Quaternion.Euler(0, 0, rotationAmount) * startingRotation;

        while (this.transform.rotation != finalRotation)
        {
            this.transform.rotation = Quaternion.Lerp(this.transform.rotation, finalRotation, Time.deltaTime * speed);
            yield return 0;
        }
    }

    void OnCollisionEnter2D(Collision2D head)
    {
        //    if (head.gameObject.GetComponent<MyHead>() != null)
        //    {
        //        head.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(5,5) * force, ForceMode2D.Impulse);
        //    }
    }


}