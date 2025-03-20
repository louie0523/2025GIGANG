using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    Animator animator;
    public float Power = -15f;
    public float Waittime = 10f;

    public enum TrapType
    {
        Push,
        Spike,
    }

    public TrapType type;

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
            if(type == TrapType.Spike )
            {
                Debug.Log(type.ToString());
            }

            yield return new WaitForSeconds(Waittime);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player")) {
            if(type == TrapType.Push)
            {
                collision.rigidbody.AddForce(100 * Power, 0, 0);
            } 
        }
    }
}
