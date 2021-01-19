using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleExplosion : MonoBehaviour
{
    [SerializeField] GameObject deathVFX;
    [SerializeField] float explosionDuration;
    [SerializeField] AudioClip obstacleDestroySound;
    [SerializeField] [Range(0, 1)] float obstacleDestroySoundVolume = 0.75f;

    public void Explosion()
    {
        //create explosion
        GameObject explosion = Instantiate(deathVFX, transform.position, Quaternion.identity);
        //destroy explosion after 1 second
        Destroy(explosion, 1f);

        //create the obstaceDestroySound, at the Main Camera position, with the obstacleDestroySoundVolume
        AudioSource.PlayClipAtPoint(obstacleDestroySound, Camera.main.transform.position, obstacleDestroySoundVolume);
    }
}
