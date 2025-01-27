using System.Collections.Generic;
using Project._Screepts.Configs;
using Project._Screepts.ShopScreen;
using UnityEngine;

namespace Project._Screepts.Screns
{
    public class ShopScreen : BaseScreen
    {
        [SerializeField] private AcitvePlayerItem _acitvePlayerItem;
        [SerializeField] private List<ItemShop> _shopItems;
        [SerializeField] private PlayerWallet _playerWallet;

        public override void Init()
        {
            base.Init();
            var shopItems = _acitvePlayerItem.GetItems();
            for (int i = 0; i < _shopItems.Count; i++)
            {
                _shopItems[i].SetData(shopItems[i], i, _playerWallet, _acitvePlayerItem);
            }
        }

        public void ShowMenuScreen()
        {
            AudioManager.PlayButtonClick();
            Dialog.ShowMenuScreen();
        }
    }
}