using System.Collections.Generic;
using UnityEngine;


namespace Project._Screepts.Configs
{
    [CreateAssetMenu(fileName = "LevelsConfig", menuName = "Configs/LevelsConfig")]
    public class LevelsConfig : ScriptableObject
    {
        [SerializeField] private List<Level> _levels;
        [SerializeField] private BackgroundConfig _backgroundConfig;

        public Level GetLevel()
        {
            if (_backgroundConfig.LevelIndex >= _levels.Count)
            {
                return _levels[Random.Range(0, _levels.Count)];
            }

            return _levels[_backgroundConfig.LevelIndex];
        }
    }
}