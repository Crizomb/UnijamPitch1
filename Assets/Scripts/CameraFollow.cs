using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float FollowSpeed = 2f;
    public float yOffset = 1f;
    public float xtest = 1f;
    public float ytest = 5f;
    public float xmax = 100f;
    public Transform target;

    // Update is called once per frame
    void Update()
    {
        float newPosX = transform.position.x;
        float newPosY = transform.position.y;


        if (target.position.x > xtest && target.position.x < xmax) {
            newPosX = (target.position.x);
        }

        if (target.position.y > ytest) {
            newPosY = (target.position.y + yOffset); 
        }

        Vector3 newPos = new Vector3(newPosX, newPosY, -10f);
        transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed * Time.deltaTime);
    }
}