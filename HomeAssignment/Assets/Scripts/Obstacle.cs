using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] float shotCounter;
    [SerializeField] float minTimeBetweenShots = 0.2f;
    [SerializeField] float maxTimeBetweenShots = 3f;
    [SerializeField] GameObject obstacleBulletPrefab;
    [SerializeField] float obstacleBulletSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
    }

    // Update is called once per frame
    void Update()
    {
        CountDownAndShoot();
    }

    private void CountDownAndShoot()
    {
        //every frame reduces the amount of time that the frame takes to run
        shotCounter -= Time.deltaTime;
        

        if (shotCounter <= 0f)
        {
            ObstacleFire();

            //reset the shotCounter after every fire
            shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        }
    }

    private void ObstacleFire()
    {
        GameObject obstacleBullet = Instantiate(obstacleBulletPrefab, transform.position, Quaternion.identity);

        //the obstacle bullet needs to fire downwards, therefore -obstacleBulletSpeed
        obstacleBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -obstacleBulletSpeed);
    }
}