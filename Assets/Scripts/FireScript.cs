using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireScript : MonoBehaviour
{
    public GameObject player;
    public GameObject logic;
    public float fire_temp = 100;

    private Temperature temperature;

    public float temp_zone_radius = 3f;

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
            temperature.enterNewTempZone(fire_temp);
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
