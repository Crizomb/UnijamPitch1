using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colision_manager : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.GetComponent<PlayerState>().getState());
        if (collision.gameObject.GetComponent<PlayerState>().getState()!= State.Solid)
        {
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        }
        else
        {
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerState>().getState() != State.Solid)
        {
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
}
