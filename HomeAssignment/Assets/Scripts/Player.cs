using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float padding = 2f;
    [SerializeField] float health = 50f;

    float xMin, xMax, yMin, yMax;

    // Start is called before the first frame update
    void Start()
    {
        SetBoundaries();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    //method to be able to move the PlayerCar left and right
    private void Move()
    {
        //delatX will be updated with the input that will happen on the x-axis, left and right
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;

        //newXPos   = current x-position   + difference in X
        var newXPos = transform.position.x + deltaX;

        newXPos = Mathf.Clamp(newXPos, xMin, xMax);

        //the x-position will be updated according to the newXPos - whether left or right
        //Y position will remain the same
        transform.position = new Vector2(newXPos, transform.position.y);

    }

    private void SetBoundaries()
    {
        //get the main camera from Unity
        Camera gameCamera = Camera.main;

        //set the boundaries on the x-axis
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;

        //set the boundaries on the y-axis
        //NOT needed but done just in case of a bug where the PlayerCar could move up and down aswell
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;
    }

    private void OnTriggerEnter2D(Collider2D otherObject)
    {
        DamageDealer damageDealer = otherObject.gameObject.GetComponent<DamageDealer>();

        //if there is no damageDealer on Trigger end the method
        if (!damageDealer)
        {
            return;
        }

        ProcessHit(damageDealer);
    }

    private void ProcessHit(DamageDealer damageDealer)
    {
        health -= damageDealer.GetDamage();

        //destroy the bullet that hits the PlayerCar
        damageDealer.Hit();

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
