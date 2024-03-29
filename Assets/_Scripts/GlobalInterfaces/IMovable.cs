using UnityEngine;

public interface IMovable
{
    public void Move(float speed);
    public void Move(float speed, Vector2 values);
}