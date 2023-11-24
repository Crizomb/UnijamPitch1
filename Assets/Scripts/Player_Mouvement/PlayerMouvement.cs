using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerMouvement : MonoBehaviour
{

    [Tooltip("PlayerSpeed")]
    public int speed;

    public void InputLeft()
    {
        // Go left
    }
    public void InputRight()
    {
        // Go Right
    }

    public abstract void InputUp(); // Depends on the state of the player

    public abstract void InputDown(); // Depends on the state of the player

}
