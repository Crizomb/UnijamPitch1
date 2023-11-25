using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSolid : PlayerMouvement
{
    public override void InputDown()
    {
       /* if(rg.velocity.y < 0)
        {
            rg.velocity = new Vector2(0,-1);
        }*/
    }

    public override void InputUp()
    {
        if (IsPlayerGrounded())
        {
            //Debug.Log("Jump!");
            Vector2 direction = new Vector2(0, 1);
            rg.AddForce(direction * jumpHeight, ForceMode2D.Impulse);
        }
    }
}
