using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ventilateur : MonoBehaviour
{

    private float force;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        // colliding with player and getting state
        GameObject gameObject = collision.gameObject;

        PlayerState playerState = gameObject.GetComponent<PlayerState>();
        State state = playerState.getState();
        if (state == State.Solid)
        {
            force = 100f;
        }
        else if (state == State.Liquid)
        {
            force = 500f;
        }
        else if (state == State.Gas)
        {
            force = 1000f;
        }
        Debug.Log(force);
        Vector2 ventilator_direction = transform.rotation * Vector2.up;
        Debug.Log(ventilator_direction);
        collision.attachedRigidbody.AddForce(ventilator_direction * force);
        
    }

}
