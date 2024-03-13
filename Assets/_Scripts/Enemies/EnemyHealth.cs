using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private Vector3 originalPosition;
    public int health;
    public ParticleSystem explosionParticle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


   

    public void LoseHP(int damage)
    {
        health -= damage;
        Instantiate(explosionParticle,transform.position, transform.rotation);
    }

    public void ShakeObject(float shakeDuration, float shakeMagnitude)
    {
       
     
        Transform objectToShake = transform;

      
        originalPosition = objectToShake.localPosition;

        
        float shakeTimer = shakeDuration;
        while (shakeTimer > 0)
        {
        
            Vector3 shakeOffset = Random.insideUnitSphere * shakeMagnitude;

         
            objectToShake.localPosition = originalPosition + shakeOffset;

            shakeTimer -= Time.deltaTime;
        }

      
        objectToShake.localPosition = originalPosition;
    }
}
