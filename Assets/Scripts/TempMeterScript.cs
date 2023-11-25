using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TempMeterScript : MonoBehaviour
{
    public Temperature temperature;
    private float yFactor = 0.1f;

    private GameObject roomTempGauge;
    private Vector3 initTempPos;
    // Start is called before the first frame update
    void Start()
    {
        // get the temperature script from the logic object
        temperature = GameObject.Find("Logic").GetComponent<Temperature>();
        // get the room temperature gauge as the tag RoomTempGauge
        roomTempGauge = GameObject.FindGameObjectWithTag("RoomTempGauge");

        
        initTempPos = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        float yScale = yFactor * temperature.slimeTemp;
        transform.localScale = new Vector3(transform.localScale.x, yScale, transform.localScale.z);

        // Scale agrandit le thermometre vers le haut et vers le bas, donc il faut le deplacer vers le haut pour compenser
        transform.localPosition = new Vector3(transform.localPosition.x, initTempPos.y+yScale/2, transform.localPosition.z);
       
    }
}
