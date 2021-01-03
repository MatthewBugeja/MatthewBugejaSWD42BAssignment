using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] int damage = 1;

    //the damage received
    public int GetDamage()
    {
        return damage;
    }

    //destroy the object
    public void Hit()
    {
        Destroy(gameObject);
    }
}
