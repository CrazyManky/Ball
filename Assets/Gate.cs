using System;
using Project._Screepts.Configs;
using Project._Screepts.GamePlayScreepts;
using UnityEngine;

public class Gate : MonoBehaviour
{
    [SerializeField] private BackgroundConfig _levels;

    public event Action OnGoal;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<BallController>(out var ballController))
        {
            _levels.LevelCompleted();
            OnGoal?.Invoke();
            Destroy(ballController.gameObject);
        }
    }
}