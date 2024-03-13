using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public int damage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<HealthManager>().TakeDamage(damage);
            Destroy(gameObject);
        }

        else if (other.gameObject.CompareTag("Cover"))
        {
            Destroy(gameObject);
            other.gameObject.GetComponent<EnemyHealth>().LoseHP(5);
        }
    }
}
