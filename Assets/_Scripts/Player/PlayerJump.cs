using System;
using UnityEngine;

namespace _Scripts.Player
{
    public class PlayerJump : MonoBehaviour, IJumpable
    {
        public void Jump(float jumpForce, bool useGrounded, Rigidbody rigidbody)
        {
            if (useGrounded)
            {
                rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
        }

        public bool IsGrounded(LayerMask groundMask, Collision other)
        {
            return true;
        }
    }
}