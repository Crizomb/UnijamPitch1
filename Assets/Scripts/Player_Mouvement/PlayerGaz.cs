using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGaz : PlayerMouvement
{
    public override void InputDown()
    {
       rg.AddForce(new Vector2(0, -1) * 100, ForceMode2D.Impulse);
    }

    public override void InputUp()
    {
        if (isGrounded)
        {
            //Debug.Log("Jump!");
            Vector2 direction = new Vector2(0, 1);
            rg.AddForce(direction * jumpHeight, ForceMode2D.Impulse);
        }
    }

}
