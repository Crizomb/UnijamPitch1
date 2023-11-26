using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraFollow : MonoBehaviour
{
    public float FollowSpeed = 4f;
    public float yOffset = 1f;
    public float xtest = -3f;
    public float ytest = 0f;
    public float xmax = 100f;
    public Transform target;
    private PlayerState playerState;

    private void OnValidate()
    {
        GameObject.Find("Player").TryGetComponent(out playerState);
    }


    void Update()
    {
        float newPosX = transform.position.x;
        float newPosY = transform.position.y;

        newPosY = (target.position.y);

        if (target.position.x > xtest)
            {
                newPosX = (target.position.x);
            }


        if (playerState.IsPlayerGrounded())
        {
            if (target.position.y > 2)
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

    }
}