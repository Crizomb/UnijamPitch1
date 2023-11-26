using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ventilateur : MonoBehaviour
{

    private float force;
    [SerializeField] private float force_solid = 5f;
    [SerializeField] private float force_liquid = 10f;
    [SerializeField] private float force_gas = 15f;


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

        PlayerState playerState = gameObject.GetComponentInParent<PlayerState>();
        State state = playerState.getState();
        if (state == State.Solid)
        {
            force = force_solid;
        }
        else if (state == State.Liquid)
        {
            force = force_liquid;
        }
        else if (state == State.Gas)
        {
            force = force_gas;
        }
        Debug.Log(force);
        Vector2 ventilator_direction = transform.rotation * Vector2.up;
        Debug.Log(ventilator_direction);
        Debug.Log(ventilator_direction);
        collision.attachedRigidbody.AddForce(ventilator_direction * force);
        
    }

}
