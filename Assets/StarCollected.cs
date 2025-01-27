using Project._Screepts.Configs;
using Project._Screepts.GamePlayScreepts;
using UnityEngine;

public class StarCollected : MonoBehaviour
{
    [SerializeField] private PlayerWallet _playerWallet;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<BallController>(out BallController ballController))
        {
            _playerWallet.AddValue(1);
            Destroy(gameObject);
        }
    }
}