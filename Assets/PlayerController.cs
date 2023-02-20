using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float acceleration = 10;
    public GameObject bulletPrefab;
    private Rigidbody rb;
    private Vector2 controlls;

    private Transform Gun;
    private bool fireButtonDown = false;

    private Camera1 cs;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Gun = transform.Find("Gun");
        cs = Camera.main.GetComponent<Camera1>();
    }

    // Update is called once per frame
    void Update()
    {
        float v, h;
        v = Input.GetAxis("Vertical");
        h = Input.GetAxis("Horizontal");
        //if(v != 0 && h != 0)
        controlls = new Vector2(h, v);

        float maxHorizontal = cs.worldWidth / 2;
        float maxVertical = cs.worldHeight / 2;

        if (Mathf.Abs(transform.position.x) > maxHorizontal)
        {
            Vector3 newPosition = new Vector3(transform.position.x * -0.95f,
                                              0,
                                              transform.position.z);
            transform.position = newPosition;
        }
        if (Mathf.Abs(transform.position.z) > maxVertical)
        {
            Vector3 newPosition = new Vector3(transform.position.x,
                                              0,
                                              transform.position.z * -0.95f);
            transform.position = newPosition;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            fireButtonDown = true;
        }
    }


    private void FixedUpdate()
    {
        rb.AddForce(transform.forward * controlls.y * acceleration, ForceMode.Acceleration);
        rb.AddTorque(transform.up * controlls.x * acceleration, ForceMode.Acceleration);

        if (fireButtonDown)
        {
            GameObject bullet1 = Instantiate(bulletPrefab, Gun.position, Quaternion.identity);
            bullet1.transform.parent = null;
            bullet1.GetComponent<Rigidbody>().AddForce(transform.forward * 20, ForceMode.VelocityChange);

            Destroy(bullet1, 5);
            fireButtonDown = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        GameObject other = collision.gameObject;
        if(other.CompareTag("Enemy"))
        {
            Time.timeScale = 0;
            GameObject gameOverScreen = GameObject.Find("Canvas").transform.Find("GameOverScreen").gameObject;
            gameOverScreen.SetActive(true);
            
            Destroy(other);
            Destroy(gameObject);
            
        }
    }

}

