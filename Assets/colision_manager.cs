using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colision_manager : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.GetComponentInParent<PlayerState>().getState() != State.Solid);
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Player") {
            if (collision.gameObject.GetComponentInParent<PlayerState>().getState() != State.Solid)
            {
                Debug.Log("ok");
                GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            }
            else
            {
                GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (collision.gameObject.GetComponentInParent<PlayerState>().getState() != State.Solid)
            {
                GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            }
        }
    }
    
    
    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
}
