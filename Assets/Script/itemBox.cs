using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemBox : MonoBehaviour
{
    Animator animator;
    bool isPlayerTouch = false;
    bool isBoxOpen = false;


    private void Start()
    {
        animator = this.GetComponent<Animator>();
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            isPlayerTouch = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            isPlayerTouch = false;
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F) && isPlayerTouch && !isBoxOpen)
        {
            Inventorys.Instance.TestGetItem();
            isBoxOpen = true;
            animator.SetTrigger("Open");
        } 
    }
}
