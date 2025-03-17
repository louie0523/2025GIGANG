using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    Animator animator;
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
}
