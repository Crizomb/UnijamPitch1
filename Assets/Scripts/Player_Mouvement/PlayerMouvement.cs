using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
// Needs a RigidBody2D, otherwise add it automatically

public abstract class PlayerMouvement : MonoBehaviour
{

    [Header("State properties")]

    [Tooltip("PlayerSpeed")]
    public int speed;
    [Tooltip("Jump height")]
    public int jumpHeight;


    [Header("Collision checks")]

    [SerializeField]
    protected int raycastPrecision = 4;
    [SerializeField]
    protected Transform collisionLeftCheck1;
    [SerializeField]
    protected Transform collisionLeftCheck2;
    [SerializeField]
    protected Transform collisionRightCheck1;
    [SerializeField]
    protected Transform collisionRightCheck2;

    
    protected Rigidbody2D rg;

    void OnValidate()   // Assignation d�s que l'�diteur s'update (changement de valeur de quelque chose)
    {
        bool gotComponent = TryGetComponent(out rg);

        if (!gotComponent)
            Debug.LogError("Erreur pas de component RG2D pour "+gameObject+" !");
    }


    void Update()
    {
        // Developpement ONLY, this should be dealt by the InputManager

        if (Input.GetKey("d"))
            InputRight();

        if (Input.GetKey("q"))
            InputLeft();

        if (Input.GetKeyDown("z"))
            InputUp();

        if (Input.GetKeyDown("s"))
            InputDown();
    }


    public void InputLeft()
    {
        //Debug.Log("Going left");
        Vector2 direction = new Vector2 (-1, 0);
        rg.AddForce(direction*speed);
    }

    public void InputRight()
    {
        //Debug.Log("Going right");
        Vector2 direction = new Vector2(1, 0);
        rg.AddForce(direction*speed);
    }

    public abstract void InputUp(); // Depends on the state of the player

    public abstract void InputDown(); // Depends on the state of the player

    public bool IsPlayerGrounded()
    {
        bool isGrounded = rg.velocity.y < 0.1 && rg.velocity.y > -0.1;

        if (isGrounded)
        {
            isGrounded = false;
            for(float i = 1f; i<raycastPrecision; i++)
            {
                isGrounded |= Physics2D.Raycast(Vector2.Lerp(collisionLeftCheck2.position, collisionRightCheck1.position, i / raycastPrecision), Vector2.down, 0.1f);
            }
        }

        return isGrounded;
    }

    public int IsPlayerWalled()
    {
        int isWalled = 0;

        // Do raycasts

        // Check Left Collision

        for (float i = 0f; i <= raycastPrecision; i++)
        {
            RaycastHit2D raycast = Physics2D.Raycast(Vector2.Lerp(collisionLeftCheck1.position, collisionLeftCheck2.position, i / raycastPrecision), Vector2.left, 0.1f);

            //Debug.Log(raycast.collider);

            if(raycast)
            {
                isWalled = -1;
                break;
            }
        }


        // Check Right Collision

        for (float i = 0f; i <= raycastPrecision; i++)
        {
            if(Physics2D.Raycast(Vector2.Lerp(collisionRightCheck1.position, collisionRightCheck2.position, i / raycastPrecision), Vector2.right, 0.1f))
            {
                isWalled = 1;
                break;
            }
        }


        return isWalled;
    }
}