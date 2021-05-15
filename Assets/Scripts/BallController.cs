using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public static BallController instance;

    // [SerializeField] float speed = 0;
    [SerializeField] Vector3 velocity;
    [SerializeField] Vector3 angularVelocity;

    public bool isDestroy = false;
    private bool isMove = false;

    // public float force;
    // public float zFactor = 2f;
    // private Vector2 startSwipe;
    // private Vector2 endSwipe;

    [SerializeField] float drag;
    [SerializeField] float angularDrag;

    private Rigidbody rb;
    // private Camera _camera;

    void Awake()
    {
        instance = this;
        rb = GetComponent<Rigidbody>();
        rb.useGravity = true;
    }

    void Start()
    {
        // _camera = Camera.main;
    }

    void Update()
    {
        SetForce();
        ThrowBall();
        Movement();

        // ThrowBall_Test();
        drag = GameManager.instance.drag;
        angularDrag = GameManager.instance.angularDrag;

        rb.drag = rb.velocity.magnitude * drag;
        rb.angularDrag = rb.velocity.magnitude * angularDrag;
    }

    void SetForce()
    {
        // velocity.z = 0;
        // velocity.y = 0;
        // angularVelocity.x = 0;

        // if (Input.GetMouseButton(0) || Input.GetKey(KeyCode.Space))
        if (Input.GetKey(KeyCode.Space))
        {
            // velocity.x = (Input.mousePosition.x) * 0.01f;
            velocity.z += 0.25f;
            velocity.y += 0.25f;
            angularVelocity.x += 0.25f;
        }
    }

    void ThrowBall()
    {
        if (isMove == false)
        {
            // if (Input.GetMouseButtonUp(0) || Input.GetKeyUp(KeyCode.Space))
            if (Input.GetKeyUp(KeyCode.Space))
            {
                rb.velocity = velocity;
                rb.angularVelocity = angularVelocity;
                rb.AddForce(Vector3.Cross(rb.velocity, rb.angularVelocity) * Time.deltaTime);
                // rb.AddForce(rb.velocity);
                // rb.AddForce(rb.angularVelocity);
                isMove = true;
            }
        }
    }

    // void ThrowBall_Test()
    // {
    //     if (Input.GetMouseButtonDown(0))
    //     {
    //         startSwipe = Camera.main.ScreenToViewportPoint(Input.mousePosition);
    //     }

    //     if (Input.GetMouseButtonUp(0))
    //     {
    //         endSwipe = Camera.main.ScreenToViewportPoint(Input.mousePosition);

    //         Vector3 swipe = endSwipe - startSwipe;
    //         swipe.z = swipe.y / zFactor;

    //         rb.AddForce(swipe * force, ForceMode.Impulse);
    //     }
    // }

    void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 moveDir = new Vector3(horizontalInput * Time.deltaTime, 0, 0);
        transform.Translate(moveDir);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Bounds")
        {
            isDestroy = true;
        }
        if (other.gameObject.tag == "Can")
        {
            isDestroy = true;
        }
    }
}
