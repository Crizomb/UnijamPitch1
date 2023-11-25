using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLiquid : PlayerMouvement
{
    [Header("State related properties")]
    public int wallJumpBonus;


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
        else
        {
            int wall = IsPlayerWalled();

            if(wall!=0)
            {
                //Debug.Log("Wall Jump!");
                Vector2 direction = new Vector2(-0.9f*wall, 1);
                rg.AddForce(direction * (jumpHeight+wallJumpBonus), ForceMode2D.Impulse);
            }
        }
    }
}
