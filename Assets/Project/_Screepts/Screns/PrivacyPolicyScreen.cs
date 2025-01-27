using System;
using Services;
using UnityEngine;

namespace Project._Screepts.Screns
{
    public class PrivacyPolicyScreen : MonoBehaviour
    {
        private AudioManager _audioManager;

        private void Start()
        {
            _audioManager = ServiceLocator.Instance.GetService<AudioManager>();
        }

        public void Close()
        {
            _audioManager.PlayButtonClick();
            Destroy(gameObject);
        }
    }
}