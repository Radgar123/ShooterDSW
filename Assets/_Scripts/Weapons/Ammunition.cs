using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammunition : MonoBehaviour
{
   public Rigidbody rigidbody;
}

public class AmmunitionParam : ScriptableObject
{
   public float shootSpeed;
   public float shootDelay;
}
