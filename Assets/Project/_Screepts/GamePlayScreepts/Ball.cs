using UnityEngine;

namespace Project._Screepts.GamePlayScreepts
{
    public class Ball
    {
        public Vector2 Position { get; private set; }
        public Vector2 Velocity { get; private set; }

        public Ball(Vector2 startPosition)
        {
            Position = startPosition;
            Velocity = Vector2.zero;
        }

        public void ApplyForce(Vector2 force)
        {
            Velocity = force;
        }

        public void UpdatePosition(float deltaTime, float gravity)
        {
            Velocity += new Vector2(0, gravity * deltaTime);
            Position += Velocity * deltaTime;
        }

        public void Reset(Vector2 startPosition)
        {
            Position = startPosition;
            Velocity = Vector2.zero;
        }
    }
}