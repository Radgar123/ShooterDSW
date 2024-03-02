using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWorm : MonoBehaviour
{
    public float speed = 3f; 
    public int damage = 10; 
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player"); 
    }

    private void Update()
    {
       
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
       
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<HealthManager>().TakeDamage(damage);

            Destroy(gameObject);
        }
    }
}
