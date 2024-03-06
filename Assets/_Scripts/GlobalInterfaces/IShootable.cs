using UnityEngine;

namespace _Scripts.GlobalInterfaces
{
    public interface IShootable
    {
        public void Shoot(Ammunition amunition, float shootSpeed, Transform shootPivot);
    }
}