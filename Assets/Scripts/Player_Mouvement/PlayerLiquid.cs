using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLiquid : PlayerMouvement
{
    [Header("State related properties")]
    public int wallJumpBonus;
    public int wallJumpAngle;


    protected override void FixedUpdate()
    {
        UpdateAnimationWalling();

        base.FixedUpdate();
    }


    public override void InputLeft()
    {
        if (isWalled == -1 && !isGrounded)
        {
            rg.velocity = Vector3.zero;
            UpdateAnimationWalling(true,-1);
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
            UpdateAnimationWalling(true,1);
        }
        else
        {
            base.InputRight();
        }
    }


    private void UpdateAnimationWalling(bool isWalling = false, int facing = 1)
    {
        animator.SetBool("wallAttach", isWalling);
        if(isWalling)
        {
            currentOffsetX = offset*(facing/Mathf.Abs(facing));
        }
        else
        {
            currentOffsetX = 0;
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
