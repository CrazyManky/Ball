using System;
using Project._Screepts.Configs;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Project._Screepts.ShopScreen
{
    public class ItemShop : MonoBehaviour
    {
        [SerializeField] private Image _lock;
        [SerializeField] private Image _item;
        [SerializeField] private Button _buttonBuy;
        
        private ShopItem _shopItem;
        public event Action<int> OnClick;
        private int _itemIndex;

        public void SetData(ShopItem data, int index)
        {
            _shopItem = data;
            _item.sprite = data.Sprite;
            if (data.IsBuy)
            {
                _lock.gameObject.SetActive(false);
                _buttonBuy.gameObject.SetActive(false);
            }
        }

        public void BuyItem()
        {
            if (_shopItem.IsBuy)
            {
                OnClick?.Invoke(_itemIndex);   
            }
            
        }
        
        
    }
}