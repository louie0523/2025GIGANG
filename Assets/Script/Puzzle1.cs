using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle1 : MonoBehaviour
{
    Animator animator;
    public string tagName;
    public bool Clear = false;
    bool isFirst = false;

    public enum TypePuzzle
    {
        Box,
        Door,
    }

    public TypePuzzle typeP;

    private void Start()
    {
        animator = this.GetComponent<Animator>();
        if(typeP == TypePuzzle.Box)
        {
            animator.enabled = false;
        }
    }

    private void Update()
    {
        if (GameManager.Instance.StagePuzzleInt[0] >= 2 && typeP == TypePuzzle.Door && !isFirst)
        {
            isFirst = true;
            animator.SetTrigger("DoorOpen");
        }
    }



    
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag(tagName) && !Clear && typeP == TypePuzzle.Box)
        {
            Clear = true;
            GameManager.Instance.StagePuzzleInt[0]++;
            animator.enabled = true;
            animator.SetTrigger("Hap" + gameObject.name);
        }
    }
}
