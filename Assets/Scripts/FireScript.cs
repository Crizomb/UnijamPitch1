using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireScript : MonoBehaviour
{

    [Header("Ice settings")]
    public float fire_temp = 100f;
    public float temp_zone_radius = 4f;

    [Header("Debug")]
    [SerializeField]
    private Temperature temperature;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject logic;
    [SerializeField]
    private Light halo1;
    [SerializeField]
    private Light halo2;
    [SerializeField]
    private bool is_in_temp_zone = false;

    void OnValidate()
    {
        logic = GameObject.Find("Logic");
        logic.TryGetComponent(out temperature);
        player = GameObject.Find("Player");
        transform.GetChild(0).gameObject.TryGetComponent(out halo1);
        transform.GetChild(1).gameObject.TryGetComponent(out halo2);

        if (halo1 is null || halo2 is null)
        {
            Debug.Log("Can't find one of the 2 halos");
        }
        else
        {
            halo1.range = temp_zone_radius;
            halo2.range = Mathf.Min(temp_zone_radius*fire_temp/150f, temp_zone_radius);
        }
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

    /*IEnumerator HaloAnimation()
    {

    }*/
}
