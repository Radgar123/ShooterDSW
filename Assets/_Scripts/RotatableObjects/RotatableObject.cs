using UnityEngine;

namespace _Scripts.RotatableObjects
{
    public abstract class RotatableObject : MonoBehaviour, IRotatable
    {
        public virtual void Rotate(Vector2 anchor)
        {
            Debug.LogWarning("You must override this method");
        }
    }
}