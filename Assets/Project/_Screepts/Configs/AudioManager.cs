using UnityEngine;

namespace Project._Screepts.Configs
{
    public class AudioManager : MonoBehaviour, IService
    {
        [SerializeField] private SoundConfig _sounConfig;
        [SerializeField] private AudioSource _audioMenuMusick;
        [SerializeField] private AudioSource _audioGameMusick;
        [SerializeField] private AudioSource _buttonClick;

        private void Start() => _sounConfig.GetSaveValue();

        public void SetSound(bool value) => _sounConfig.SetVolume(value);
        
        public void PlayButtonClick() => _buttonClick.Play();
        

        public void PlayMenuMusick()
        {
            _audioGameMusick.Stop();
            _audioMenuMusick.Play();
        }

        public void PlayGame()
        {
            _audioMenuMusick.Stop();
            _audioGameMusick.Play();
        }
    }
}