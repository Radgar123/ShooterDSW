using UnityEngine;

namespace _Scripts.Player
{
    public class PlayerMovement : MonoBehaviour, IMovable
    {
        public void Move(float speed)
        {
            throw new System.NotImplementedException();
        }

        public void Move(float speed, Vector2 direction)
        {
            if (direction != Vector2.zero)
            {
                Vector3 moveDirection = new Vector3(direction.x, 0, direction.y);
                transform.position += moveDirection * speed * Time.deltaTime;
            }
        }
    }
}