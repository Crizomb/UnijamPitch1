using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceScript : MonoBehaviour
{
    public GameObject player;
    public GameObject logic;
    public float ice_temp = -25f;

    private Temperature temperature;

    public float temp_zone_radius = 4f;

    bool is_in_temp_zone = false;

    // Start is called before the first frame update
    void Start()
    {
        temperature = logic.GetComponent<Temperature>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!(is_in_temp_zone) && isInTempZone())
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
