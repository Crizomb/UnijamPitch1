using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarreauScript : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    private PlayerState playerStateScript;

    private Rigidbody2D rbBarreau;
    // Start is called before the first frame update
    void Start()
    {
        playerStateScript = player.GetComponent<PlayerState>();
        rbBarreau = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        State state = playerStateScript.getState();
        if (state == State.Solid)
        {
            // set active rb
            rbBarreau.simulated = true;
        }
        else
        {
            // unactive rb
            rbBarreau.simulated = false;
        }
    }
}
