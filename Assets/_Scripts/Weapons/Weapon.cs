using UnityEngine;

namespace _Scripts.Weapons
{
    [System.Serializable]
    public struct Weapon
    {
        public GameObject _activeObject;
        public WeaponParam weaponParam;
        public AmmunitionParam AmmunitionParam;
    }

    public class WeaponParam : ScriptableObject
    {
        
    }
}