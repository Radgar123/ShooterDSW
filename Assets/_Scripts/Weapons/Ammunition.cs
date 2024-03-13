using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammunition : MonoBehaviour
{
   public int damage;
   public Rigidbody rigidbody;
    public int destroyTime;


    public void Start()
    {
        Destroy(gameObject, destroyTime);
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Cover"))
        {
            
            other.gameObject.GetComponent<EnemyHealth>().LoseHP(damage);
            
            if(other.gameObject.GetComponent<EnemyHealth>().health <= 0)
            {
                Destroy(other.gameObject);
            }
            Destroy(gameObject);
        }
    }
}

public class AmmunitionParam : ScriptableObject
{
   public float shootSpeed;
   public float shootDelay;
}



