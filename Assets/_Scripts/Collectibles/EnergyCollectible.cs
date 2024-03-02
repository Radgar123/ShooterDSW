using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyCollectible : MonoBehaviour
{
    public int energyRestore;
    // Start is called before the first frame update


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<HealthManager>().Heal(energyRestore);
        }
    }
}
