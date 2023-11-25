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

    [Header("Player states")]

    public GameObject solidState;
    public GameObject liquidState;
    public GameObject gasState;

    [Space]

    [SerializeField]
    private State state;

    [Space]

    private Temperature temperature;
    private PlayerGaz gasScript;
    private PlayerLiquid liquidScript;
    private PlayerSolid solidScript;

    public State getState()
    {

        return state;
    }


    void OnValidate()
    {
        gasState.TryGetComponent(out gasScript);
        liquidState.TryGetComponent(out liquidScript);
        solidState.TryGetComponent(out solidScript);
    }

    // Start is called before the first frame update
    void Start()
    {
        temperature = logic.GetComponent<Temperature>();
    }

    // Update is called once per frame
    void Update()
    {
        checkStateChange();
    }

    public bool IsPlayerGrounded()
    {
        switch(state)
        {
            case State.Solid:
                return solidScript.isGrounded;

            case State.Liquid:
                return liquidScript.isGrounded;

            case State.Gas:
                return gasScript.isGrounded;
        }

        return false;
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
        state = State.Liquid;

        solidState.SetActive(false);
        liquidState.SetActive(true);
    }

    void liquid_to_solid()
    {
        state = State.Solid;

        liquidState.SetActive(false);
        solidState.SetActive(true);
    }

    void liquid_to_gas()
    {
        state = State.Gas;

        liquidState.SetActive(false);
        gasState.SetActive(true);
    }

    void gas_to_liquid()
    {
        state = State.Liquid;

        gasState.SetActive(false);
        liquidState.SetActive(true);
    }

}
