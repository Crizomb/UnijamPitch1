using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceScript : MonoBehaviour
{

    [Header("Ice settings")]
    public float ice_temp = -25f;
    public float temp_zone_radius = 4f;

    [Header("Debug")]
    [SerializeField]
    private Temperature temperature;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject logic;
    [SerializeField]
    private Light halo;
    [SerializeField]
    private bool is_in_temp_zone = false;


    void OnValidate()
    {
        logic = GameObject.Find("Logic");

        if (logic == null)
            Debug.LogError("Can't find the 'Logic' game object");
        else
            logic.TryGetComponent(out temperature);


        player = GameObject.Find("Player");

        if (player == null)
            Debug.LogError("Can't find the 'Player' game object");


        transform.GetChild(0).gameObject.TryGetComponent(out halo);


        if(halo is null)
        {
            Debug.Log("Can't find the halo");
        }
        else
        {
            halo.range = temp_zone_radius;
        }


    }

    // Update is called once per frame
    void Update()
    {
        if (!is_in_temp_zone && isInTempZone())
        {
            is_in_temp_zone = true;
            temperature.enterNewTempZone(ice_temp);
        }
        else if (is_in_temp_zone && !(isInTempZone()))
        {
            is_in_temp_zone = false;
            temperature.leaveTempZone();
        }
    }

    bool isInTempZone()
    {
        float distance = Vector3.Distance(player.transform.position, transform.position);
        if (distance <= temp_zone_radius)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
