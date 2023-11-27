using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startVictory : MonoBehaviour
{
    [SerializeField] private VictoryScript victory;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            victory.Victory();
        }
    }
}
