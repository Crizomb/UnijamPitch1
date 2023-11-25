using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public enum State
{
    Solid,
    Liquid,
    Gas
}


public class PlayerState : MonoBehaviour
{
    public GameObject logic;
    public float solid_liquid_temp = 0;
    public float liquid_gas_temp = 100;
    private State state;


    private Temperature temperature;

    public State getState()
    {
        return state;
    }


    // Start is called before the first frame update
    void Start()
    {
        temperature = logic.GetComponent<Temperature>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(temperature.slimeTemp);
        checkStateChange();
    }

    void checkStateChange()
    {
        
        if (temperature.slimeTemp >= liquid_gas_temp)
        {
            if (state == State.Liquid)
            {
                liquid_to_gas();
            }
        }
        if (temperature.slimeTemp < liquid_gas_temp)
        {
            if (state == State.Gas)
            {
                gas_to_liquid();
            }
        }
        if (temperature.slimeTemp >= solid_liquid_temp)
        {
            if (state == State.Solid)
            {
                solide_to_liquid();
            }
        }
        if (temperature.slimeTemp < solid_liquid_temp)
        {
            if (state == State.Liquid)
            {
                liquid_to_solid();
            }
        }
        
    }



    void solide_to_liquid()
    {
        this.state = State.Liquid;

    }

    void liquid_to_solid()
    {
        this.state = State.Solid;
    }

    void liquid_to_gas()
    {
        this.state = State.Gas;
    }

    void gas_to_liquid()
    {
        this.state = State.Liquid;
    }

}
