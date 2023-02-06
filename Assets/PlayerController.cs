using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float acceleration = 10;
    public GameObject bulletPrefab;
    // Start is called before the first frame update
    private Rigidbody rb;
    private Vector2 controlls;
    private Transform Gun;
    private bool fireButtonDown = false;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Gun = transform.Find("Gun");
    
    }

    // Update is called once per frame
    void Update()
    {
        float v, h;
        v = Input.GetAxis("Vertical");
        h = Input.GetAxis("Horizontal");
        //if(v != 0 && h != 0) 
        controlls = new Vector2(h, v);
        if(Mathf.Abs(transform.position.x) > 21)
        {
           Vector3 newPosition = new Vector3(transform.position.x * -1,
               0, transform.position.z);
           transform.position = newPosition;
        }
        if (Mathf.Abs(transform.position.z) > 12)
        {
            Vector3 newPosition = new Vector3(transform.position.x,
                0, transform.position.z * -1);
          transform.position = newPosition;
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            fireButtonDown = true;
        }


    }
     void FixedUpdate()
    {
        rb.AddForce(transform.forward * controlls.y * acceleration, ForceMode.Acceleration);
        rb.AddTorque(transform.up * controlls.x * acceleration, ForceMode.Acceleration);
        if (fireButtonDown)
        {
            GameObject bullet1 = Instantiate(bulletPrefab, Gun.position, Quaternion.identity);
            bullet1.transform.parent = null;
            bullet1.GetComponent<Rigidbody>().AddForce(bullet1.transform.forward, ForceMode.VelocityChange);
            Destroy(bullet1, 5);
           fireButtonDown= false;   
        }
    }
}

