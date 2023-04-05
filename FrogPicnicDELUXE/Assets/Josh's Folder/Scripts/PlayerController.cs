using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Camera cam;

    Rigidbody body;

    Animator anim;

    public Transform groundCheck;

    public LayerMask groundMask;

    Vector3 input;
    Vector3 vel;

    public float speed;
    public float jumpHeight = 4f;
    public float gravity = -9.81f;
    public float groundDistance;

    bool grounded;

    public GameObject[] hats;
    private int currentHatIndex = 0;

    private void Start()
    {
        body = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        cam = FindObjectOfType<Camera>();


        for (int i = 1; i < hats.Length; i++)
        {
            hats[i].SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        grounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (grounded && vel.y < 0)
        {
            vel.y = -2.0f;
        }

        input = new Vector3(-Input.GetAxisRaw("Vertical"), gravity * Time.deltaTime, Input.GetAxisRaw("Horizontal"));
        vel = input * speed;

        if (Input.GetButtonDown("Jump") && grounded)
        {
            vel.y = Mathf.Sqrt(jumpHeight * -2.0f * gravity);
        }

        Ray camRay = cam.ScreenPointToRay(Input.mousePosition);
        Plane ground = new Plane(Vector3.up, Vector3.zero);
        float length;

        if (ground.Raycast(camRay, out length))
        {
            Vector3 look = camRay.GetPoint(length);
            transform.LookAt(new Vector3(look.x, transform.position.y, look.z));
        }

        if (vel.x != 0.0f || vel.z != 0.0f)
        {
            anim.SetBool("moving", true);
        }
        else
        {
            anim.SetBool("moving", false);
        }


        if (Input.GetKeyDown(KeyCode.K))
        {
            hats[currentHatIndex].SetActive(false);
            currentHatIndex = (currentHatIndex + 1) % hats.Length;
            hats[currentHatIndex].SetActive(true);
        }
    }

    void FixedUpdate()
    {
        body.velocity = vel;
    }
}
