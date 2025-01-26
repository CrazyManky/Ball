using UnityEngine;

namespace Project._Screepts.Configs
{
    [CreateAssetMenu(fileName = "PlayerWallet", menuName = "Configs/PlayerWallet")]
    public class PlayerWallet : ScriptableObject
    {
        [SerializeField] private float _playerValue;

        public float Value => _playerValue;

        public void AddValue(float value) => _playerValue += value;
    }
}