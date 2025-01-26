using Project._Screepts.Configs;
using UnityEngine;

namespace Project._Screepts.Screns
{
    public class ShopScreen : BaseScreen
    {
        [SerializeField] private AcitvePlayerItem _acitvePlayerItem;
        //[SerializeField] private 
        public void ShowMenuScreen()
        {
            Dialog.ShowMenuScreen();
        }
    }
}