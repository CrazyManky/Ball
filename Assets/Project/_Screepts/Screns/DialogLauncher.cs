using Services;
using UnityEngine;

namespace Project._Screepts.Screns
{
    public class DialogLauncher : MonoBehaviour, IService
    {
        [SerializeField] private MenuScreen _menuScreen;
        [SerializeField] private SettingsScreen _settingsScreen;
        [SerializeField] private ShopScreen _shopScreen;
        [SerializeField] private RecordScreen _recordScreen;

        //[SerializeField] private GameScreen _gameScreen;
        //[SerializeField] private AudioManager _audioManager;
        
        
        private BaseScreen _activeScreen;


        private void Awake()
        {
            ServiceLocator.Init();
            ServiceLocator.Instance.AddService(this);
        }

        private void Start() => ShowMenuScreen();

        public void ShowMenuScreen()
        {
            // _audioManager.PlayMenuMusick();
            ShowScreen(_menuScreen);
        }

        public void ShowRecordScreen() => ShowScreen(_recordScreen);
        public void ShowSettingsScreen() => ShowScreen(_settingsScreen);
        public void ShowShopScreen() => ShowScreen(_shopScreen);

        //
        // public void ShowGameScreen()
        // {
        //     _audioManager.PlayGame();
        //     ShowScreen(_gameScreen);
        // }
        //
        private void ShowScreen(BaseScreen screen)
        {
            _activeScreen?.Сlose();
            var instanceScreen = Instantiate(screen, transform);
            instanceScreen.Init();
            _activeScreen = instanceScreen;
        }
    }
}