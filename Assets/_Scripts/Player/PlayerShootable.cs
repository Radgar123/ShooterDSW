using _Scripts.GlobalInterfaces;
using UnityEngine;

namespace _Scripts.Player
{
    public class PlayerShootable : MonoBehaviour, IShootable
    {
        public void Shoot(Ammunition ammunition, float shootSpeed, Transform shootPivot)
        {
            GameObject tempAmmo = Instantiate(ammunition.gameObject, shootPivot.position, shootPivot.rotation);
            tempAmmo.transform.parent = null; 
            
            Rigidbody rb = tempAmmo.GetComponent<Rigidbody>();
            rb.AddForce(shootPivot.forward * shootSpeed, ForceMode.VelocityChange);
        }
    }
}