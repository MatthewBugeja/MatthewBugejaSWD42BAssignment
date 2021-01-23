using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour
{
    [SerializeField] int scoreValue = 5;

    private void OnTriggerEnter2D(Collider2D otherObject)
    {
        if (otherObject.gameObject.tag == "obstacle")
        {
            Destroy(otherObject.gameObject);
            FindObjectOfType<GameSession>().AddToScore(scoreValue);

            return;
        }

        Destroy(otherObject.gameObject);
    }
}