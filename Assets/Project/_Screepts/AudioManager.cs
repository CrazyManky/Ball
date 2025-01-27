using Project._Screepts.Configs;
using UnityEngine;

namespace Project._Screepts
{
    public class AudioManager : MonoBehaviour, IService
    {
        [SerializeField] private SoundConfig _soundConfig;
        [SerializeField] private AudioSource _buttonClickListener;
        [SerializeField] private AudioSource _gameSound;
        [SerializeField] private AudioSource _menuMusic;

        public void PlayButtonClick()
        {
            _buttonClickListener.Play();
        }

        public void PlayGame()
        {
            _gameSound.Play();
        }

        public void PlayMenu()
        {
            _menuMusic.Play();
        }

        private void Update()
        {
            if (!_soundConfig.SoundActive)
            {
                _buttonClickListener.volume = 0f;
                _gameSound.volume = 0f;
            }
            else
            {
                _buttonClickListener.volume = 0.1f;
                _gameSound.volume = 0.1f;
            }
        }
    }
}