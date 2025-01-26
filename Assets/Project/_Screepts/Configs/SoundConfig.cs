using UnityEngine;

namespace Project._Screepts.Configs
{
    [CreateAssetMenu(fileName = "SoundConfig", menuName = "SoundConfig")]
    public class SoundConfig : ScriptableObject
    {
        public bool SoundActive { get; private set; }

        public void SetVolume(bool value)
        {
            SoundActive = value;
            PlayerPrefs.SetInt("Sound", value ? 1 : 0);
        }

        public void GetSaveValue() => SoundActive = PlayerPrefs.GetInt("Sound", 0) == 1;
        
    }
}