using System.Collections.Generic;
using UnityEngine;

namespace Project._Screepts.GamePlayScreepts
{
    public class Trajectory
    {
        public List<Vector2> CalculateTrajectory(Vector2 startPosition, Vector2 initialVelocity, int points,
            float timeStep, float gravity)
        {
            var trajectoryPoints = new List<Vector2>();

            for (int i = 0; i < points; i++)
            {
                float t = i * timeStep;
                float x = startPosition.x + initialVelocity.x * t;
                float y = startPosition.y + initialVelocity.y * t + 0.5f * gravity * t * t;

                trajectoryPoints.Add(new Vector2(x, y));
            }

            return trajectoryPoints;
        }
    }
}