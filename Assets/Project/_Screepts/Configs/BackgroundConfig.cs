using System.Collections.Generic;
using UnityEngine;

namespace Project._Screepts.Configs
{
    [CreateAssetMenu(fileName = "BackgroundConfig", menuName = "Configs/BackgroundConfig")]
    public class BackgroundConfig : ScriptableObject
    {
        [SerializeField] private List<Sprite> _sprites;
        [SerializeField] private int _levelIndex;

        public int LevelIndex => _levelIndex;
        
        private void Start()
        {
            _levelIndex = PlayerPrefs.GetInt("LevelIndex", _levelIndex);
        }

        public Sprite GetSprites()
        {
            if (_levelIndex >= _sprites.Count)
            {
                _levelIndex = Random.Range(0, _sprites.Count);
                return _sprites[_levelIndex];
            }
            return _sprites[_levelIndex];
        }

        public void LevelCompleted()
        {
            _levelIndex++;
            PlayerPrefs.SetInt("LevelIndex", _levelIndex);
        }
    }
}