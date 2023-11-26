using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraFollow : MonoBehaviour
{
    public float FollowSpeed = 6f;
    public float yOffset = 1f;
    public float xtest = 1f;
    public float ytest = 0f;
    public float xmax = 100f;
    public Transform target;
    private Rigidbody2D targetRigidbody;

    private void Start()
    {
        targetRigidbody = target.GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        float newPosX = transform.position.x;
        float newPosY = transform.position.y;

        newPosY = (target.position.y);


        if (target.position.x > xtest && target.position.x < xmax)
            {
                newPosX = (target.position.x);
            }
        if (targetRigidbody != null && targetRigidbody.velocity.y == 0)
        {
            if (target.position.y > 2.2)
            {
                yOffset = -3f;
            }
            else
            {
                yOffset = 3f;
            }
        }
        
        
        Vector3 newPos = new Vector3(newPosX, newPosY + yOffset, -14f);
        transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed * Time.deltaTime);
        Debug.Log(newPos);
    }
}