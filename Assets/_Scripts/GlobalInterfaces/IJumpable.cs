
using UnityEngine;

public interface IJumpable
{
    public void Jump(float jumpForce, bool useGrounded, Rigidbody rigidbody);
    public bool IsGrounded(LayerMask groundMask, Collision other);
}