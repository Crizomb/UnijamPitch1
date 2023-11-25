using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Flag : MonoBehaviour
{
    private Animator animator;

    private void Start(){
        animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player"){
            animator.SetTrigger("FlagReached");
            StartCoroutine(WaitAnimation());
        }
    }

    private IEnumerator WaitAnimation(){
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }   
}