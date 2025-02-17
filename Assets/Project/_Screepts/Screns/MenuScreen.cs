using UnityEngine;

namespace Project._Screepts.Screns
{
    public class MenuScreen : BaseScreen
    {
        [SerializeField] private FactsScreen _factsScreen;

        public void ShowSettingsScreen()
        {
            Dialog.ShowSettingsScreen();
        }

        public void ShowShopScreen()
        {
            Dialog.ShowShopScreen();
        }

        public void ShowGameScreen()
        {
            Dialog.ShowGameScreen();
        }

        public void ShowRecordScreen()
        {
            Dialog.ShowRecordScreen();
        }

        public void ShowFactScreen()
        {
            Instantiate(_factsScreen, transform);
        }
    }
}