using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLiquid : PlayerMouvement
{
    [Header("State related properties")]
    public int wallJumpBonus;
    public int wallJumpAngle;


    public override void InputLeft()
    {
        if (isWalled == -1 && !isGrounded)
        {
            rg.velocity = Vector3.zero;
            animator.SetBool("wallAttach", true);
        }
        else
        {
            base.InputLeft();
        }
    }
    public override void InputRight()
    {
        if (isWalled == 1 && !isGrounded)
        {
            rg.velocity = Vector3.zero;
            animator.SetBool("wallAttach", true);
        }
        else
        {
            base.InputRight();
        }
    }


    public override void InputDown()
    {
       /* if(rg.velocity.y < 0)
        {
            rg.velocity = new Vector2(0,-1);
        }*/
    }

    public override void InputUp()
    {
        if (isGrounded)
        {
            //Debug.Log("Jump!");
            Vector2 direction = new Vector2(0, 1);
            rg.AddForce(direction * jumpHeight, ForceMode2D.Impulse);
            SoundSingleton.Instance.PlayLiquidJump();
        }
        else
        {
            int wall = isWalled;

            if(wall!=0)
            {
                //Debug.Log("Wall Jump!");
                Vector2 direction = new Vector2(-wall/Mathf.Tan(wallJumpAngle), 1);
                rg.AddForce(direction * (jumpHeight+wallJumpBonus), ForceMode2D.Impulse);
            }
        }
    }
}
