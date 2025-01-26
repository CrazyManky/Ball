using Project._Screepts.Configs;
using UnityEngine;

namespace Project._Screepts.Screns
{
    public class SettingsScreen : BaseScreen
    {
        [SerializeField] private SoundConfig _audioManager;
        [SerializeField] private PrivacyPolicyScreen _privacyPolicyScreen;

        public void DisableSound()
        {
            _audioManager.SetVolume(false);
        }

        public void ShopPrivacyPolicy()
        {
            Instantiate(_privacyPolicyScreen, transform);
        }

        public void EnableSound()
        {
            _audioManager.SetVolume(true);
        }

        public void BackToMenu()
        {
            Dialog.ShowMenuScreen();
        }
    }
}