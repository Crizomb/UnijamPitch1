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
    public float speed;
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

    [Space]

    [Header("Debug variables")]

    [SerializeField]
    protected float collisionDistance;
    [SerializeField]
    public bool isGrounded;
    [SerializeField]
    protected int isWalled;


    [Space]

    [SerializeField]
    protected Animator animator;
    [SerializeField]
    protected Rigidbody2D rg;
    [SerializeField]
    protected new SpriteRenderer renderer;
    [SerializeField]
    protected GameObject player;
    [SerializeField]
    protected GameObject sprite;
    [SerializeField]
    protected float offset;

    protected float currentOffsetX;

    private bool bufferJump;
    private int lastDirection;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawLine(collisionRightCheck2.position, collisionRightCheck2.position + Vector3.right * collisionDistance);
    }


    void OnValidate()   // Assignation dès que l'éditeur s'update (changement de valeur de quelque chose)
    {
        bool gotComponent1 = TryGetComponent(out rg);

        sprite = transform.GetChild(0).gameObject;

        bool gotComponent2 = sprite.TryGetComponent(out animator);
        bool gotComponent3 = sprite.TryGetComponent(out renderer);

        player = GameObject.Find("Player");

        if (!(gotComponent1 && gotComponent2 && gotComponent3))
            Debug.LogError("Erreur components manquants pour "+gameObject+" !");
    }

    void Update()
    {
        if (Input.GetKeyDown("z"))
        {
            bufferJump = true;
        }
        sprite.transform.localPosition = new Vector3(currentOffsetX,0,0);
    }

    void Start()
    {
        lastDirection = 0;
    }

    protected virtual void FixedUpdate()
    {
        IsPlayerGrounded();
        isWalled = IsPlayerWalled();


        int speedTemp = 0;

        if (Input.GetKey("d") && (isWalled != 1 || !isGrounded))
        {
            InputRight();
            speedTemp = 1;
            //Debug.Log("Input right");
        }

        if (Input.GetKey("q") && (isWalled != -1 || !isGrounded))
        {
            InputLeft();
            speedTemp = -1;
            //Debug.Log("Input left");
        }

        if (bufferJump)
        {
            InputUp();
            bufferJump = false;
        }

        /*if (Input.GetKeyDown("s"))
            InputDown();*/

        animator.SetBool("isJumping", rg.velocity.y < -0.01f || rg.velocity.y > 0.01f);
        animator.SetFloat("speed", Mathf.Abs(speedTemp));

        if (speedTemp < 0){
            renderer.flipX = true;
            lastDirection = speedTemp;
        }
        else if(speedTemp == 0)
        {
            renderer.flipX = lastDirection == -1;
        }
        else
        {
            renderer.flipX = false;
            lastDirection = speedTemp;
        }

        
        int yVel = 1;

        if (rg.velocity.y < 0)
            yVel = -1;

        animator.SetInteger("verticalDirection", yVel);

        Vector3 tempPos = transform.position;
        player.transform.position = transform.position;
        transform.position = tempPos;

    }

    public virtual void InputLeft()
    {
        //Debug.Log("Going left");
        Vector3 direction = new Vector2(-1, 0);
        //rg.AddForce(direction*speed);
        transform.position += direction*speed/60;
    }

    public virtual void InputRight()
    {
        //Debug.Log("Going right");
        Vector3 direction = new Vector2(1, 0);
        //rg.AddForce(direction*speed);
        transform.position += direction*speed/60;
    }

    public abstract void InputUp(); // Depends on the state of the player

    public abstract void InputDown(); // Depends on the state of the player


    public void IsPlayerGrounded()
    {
        bool isG = rg.velocity.y < 0.1 && rg.velocity.y > -0.1;

        if (isG)
        {
            isG = false;
            for(float i = 1f; i<raycastPrecision; i++)
            {
                isG = Physics2D.Raycast(Vector2.Lerp(collisionLeftCheck2.position, collisionRightCheck2.position, i / raycastPrecision), Vector2.down, collisionDistance);
                if (isG)
                    break;
            }
        }

        isGrounded = isG;
    }

    public int IsPlayerWalled()
    {
        int isWalled = 0;

        // Do raycasts

        // Check Left Collision

        for (float i = 0f; i <= raycastPrecision; i++)
        {
            RaycastHit2D raycast = Physics2D.Raycast(Vector2.Lerp(collisionLeftCheck1.position, collisionLeftCheck2.position, i / raycastPrecision), Vector2.left, collisionDistance);

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
            if(Physics2D.Raycast(Vector2.Lerp(collisionRightCheck1.position, collisionRightCheck2.position, i / raycastPrecision), Vector2.right, collisionDistance))
            {
                isWalled = 1;
                break;
            }
        }


        return isWalled;
    }
}
