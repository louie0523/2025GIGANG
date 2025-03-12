using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    Rigidbody rb;
    Animator animator;

    bool Walk = false;

    public float speed = 4f;

    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        animator = this.transform.Find("플레이어").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Rotation();
    }

    void Move()
    {
        Walk = false;
        if(Input.GetKey(KeyCode.W))
        {
            this.transform.Translate(0, 0, speed * Time.deltaTime);
            Walk = true;
        } else if(Input.GetKey(KeyCode.S))
        {
            this.transform.Translate(0, 0, -speed * Time.deltaTime);
            Walk = true;
        }
        if(Input.GetKey(KeyCode.D))
        {
            this.transform.Translate(-speed * Time.deltaTime, 0, 0);
            Walk = true;
        } else if(Input.GetKey(KeyCode.A))
        {
            this.transform.Translate(speed * Time.deltaTime, 0, 0);
            Walk = true;
        }

        if(Walk)
        {
            animator.SetBool("Walk", true);
        } else
        {
            animator.SetBool("Walk", false);
        }
    }

    void Rotation()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        Plane plane = new Plane(Vector3.up, Vector3.zero);

        float rayLength;
        if (plane.Raycast(ray, out rayLength))
        {
            Vector3 mousePoint = ray.GetPoint(rayLength);

            this.transform.LookAt(new Vector3(mousePoint.x, this.transform.position.y, mousePoint.z));
        }
    }
}
