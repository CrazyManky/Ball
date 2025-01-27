using System;
using UnityEngine;

namespace Project._Screepts.Configs
{
    [CreateAssetMenu(fileName = "PlayerWallet", menuName = "Configs/PlayerWallet")]
    public class PlayerWallet : ScriptableObject
    {
        [SerializeField] private int _playerValue;


        public void Awake()
        {
            _playerValue = PlayerPrefs.GetInt("PlayerValue", 0);
        }

        public float Value => _playerValue;

        public void AddValue(int value)
        {
            _playerValue += value;
            SaveData();
        }

        public void Sale(int value)
        {
            _playerValue -= value;
            SaveData();
        }

        public void SaveData()
        {
            PlayerPrefs.SetInt("PlayerValue", _playerValue);
        }
    }
}