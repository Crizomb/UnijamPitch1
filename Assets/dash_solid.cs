using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class dash_solid : MonoBehaviour
{
    public PlayerState playerState;
    public float dashSpeed = 10f;
    public float dashDuration = 0.5f;
    public float timeBetweenDashes = 0.3f; // Adjust this value based on your desired double-tap speed
    public float cooldownDuration = 2f;
    private float lastDashTime;
    private KeyCode lastKeyPressed;
    private float lastKeyPressTime;

    private bool isDashing = false;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        // if (playerState.getState() == State.Solid)
        if (Time.time - lastDashTime >= cooldownDuration)
        {
            {
                if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.Q))
                {
                    if (Time.time - lastKeyPressTime < cooldownDuration && lastKeyPressed == (Input.GetKey(KeyCode.D) ? KeyCode.D : KeyCode.Q))
                    {
                        // Perform dash
                        Dash(Input.GetKey(KeyCode.D) ? Vector2.right : Vector2.left);
                        isDashing = true;
                        lastDashTime = Time.time; // Update the last dash time
                    }
                    else
                    {
                        // Update the last key press time and key pressed
                        lastKeyPressTime = Time.time;
                        lastKeyPressed = Input.GetKey(KeyCode.D) ? KeyCode.D : KeyCode.Q;
                    }
                }
            }

            void Dash(Vector2 direction)
            {
                if (!isDashing)
                {
                    isDashing = true;
                    StartCoroutine(DashCoroutine(direction));
                }
            }

            IEnumerator DashCoroutine(Vector2 direction)
            {
                float startTime = Time.time;

                while (Time.time < startTime + dashDuration)
                {
                    // Move the player in the specified direction
                    transform.Translate(direction * dashSpeed * Time.deltaTime);

                    yield return null;
                }

                isDashing = false;
            }
        }
    }
}