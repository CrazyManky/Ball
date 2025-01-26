using System;

namespace Project._Screepts.GamePlayScreepts
{
    public class GameManager
    {
        public int BallsRemaining { get; private set; }
        public int Score { get; private set; }

        public event Action<int> OnScoreChanged;
        public event Action<int> OnBallsChanged;

        public GameManager(int initialBalls)
        {
            BallsRemaining = initialBalls;
        }

        public void AddScore(int points)
        {
            Score += points;
            OnScoreChanged?.Invoke(Score);
        }

        public void UseBall()
        {
            BallsRemaining--;
            OnBallsChanged?.Invoke(BallsRemaining);
        }

        public bool IsGameOver()
        {
            return BallsRemaining <= 0;
        }
    }
}