using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraFollow : MonoBehaviour
{
    public float FollowSpeed = 4f;
    private float yOffset;
    public float xOffset = 0f;
    public float yOffsethaut = -3f;
    public float yOffsetbas = 2f;
    public float xtest = 3f;
    public float ytrigger = 0f;
    public Transform target;
    private PlayerState playerState;

    private void OnValidate()
    {
        GameObject.Find("Player").TryGetComponent(out playerState);
        target = playerState.transform;
    }


    void Update()
    {
        float newPosX = target.position.x;
        float newPosY = target.position.y;


        /*if (target.position.x > xtest)
            {
                newPosX = (target.position.x);
            }*

        /*if (target.position.y - transform.position.y > 1)
        {
            newPosY = target.position.y;
            Debug.Log("newpos");
        }*/

        if (playerState.IsPlayerGrounded())
        {
            if (target.position.y > ytrigger)
            {
                yOffset = yOffsethaut;
                Debug.Log("-1");
            }
            else
            {
                yOffset = yOffsetbas;
                Debug.Log("+1");
            }
        }
        
        
        Vector3 newPos = new Vector3(newPosX + xOffset, newPosY + yOffset, -14f);
        transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed * Time.deltaTime);

    }
}