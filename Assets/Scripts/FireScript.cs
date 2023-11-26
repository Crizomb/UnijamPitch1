using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FireScript : MonoBehaviour
{

    [Header("Fire settings")]
    public float fire_temp = 80f;
    public float temp_zone_radius = 4f;

    [Header("Animation settings")]
    public float speed = 100f;
    public float depth = 0.5f;

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

    [SerializeField]
    private float timer;

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
            halo1.range = temp_zone_radius*2;
            halo2.range = Mathf.Min(temp_zone_radius*fire_temp/150f, temp_zone_radius)*2;
        }
    }

    void Start()
    {
        StartCoroutine("HaloAnimation");
    }

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

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x-temp_zone_radius,transform.position.y,0));
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

    IEnumerator HaloAnimation()
    {
        timer = 0;
        for (; ; )
        {
            timer += Time.deltaTime;
            halo2.range = (depth*temp_zone_radius*(Mathf.Sin(Mathf.PI*timer*speed)+1)/2)*2;
            yield return null;
        }
    }
}
