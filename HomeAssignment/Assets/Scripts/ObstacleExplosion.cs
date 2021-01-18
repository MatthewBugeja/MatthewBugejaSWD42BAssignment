using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleExplosion : MonoBehaviour
{
    [SerializeField] GameObject deathVFX;
    [SerializeField] float explosionDuration;

    public void Explosion()
    {
        //create explosion
        GameObject explosion = Instantiate(deathVFX, transform.position, Quaternion.identity);
        //destroy explosion after 1 second
        Destroy(explosion, 1f);
    }
}
