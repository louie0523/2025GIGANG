using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    Animator animator;
    public float Power = -15f;
    public float Waittime = 10f;

    private void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(Move());
    }

    IEnumerator Move()
    {
        while(true)
        {
        animator.SetTrigger("Move");
        yield return new WaitForSeconds(Waittime);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player")) {
            collision.rigidbody.AddForce(100 * Power, 0, 0);
        }
    }
}
