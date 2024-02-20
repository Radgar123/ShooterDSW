﻿using UnityEngine;

namespace _Scripts.RotatableObjects
{
    public class RotatableByInputs : RotatableObject
    {
        public override void Rotate(Vector2 anchor)
        {
            if (anchor == Vector2.zero) return;
            
            float angle = Mathf.Atan2(anchor.x, anchor.y) * Mathf.Rad2Deg;
            
            angle = Mathf.Round(angle / 45) * 45;
            transform.rotation = Quaternion.Euler(0, angle, 0);
        }
    }
}