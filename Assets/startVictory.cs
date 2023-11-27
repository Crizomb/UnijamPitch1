using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startVictory : MonoBehaviour
{
    [SerializeField] private VictoryScript victory;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            animator.SetTrigger("FlagReached");
            StartCoroutine(WaitAndWin());
        }
    }

    private IEnumerator WaitAndWin()
    {
        yield return new WaitForSeconds(1f);
        victory.Victory();
    }
}
