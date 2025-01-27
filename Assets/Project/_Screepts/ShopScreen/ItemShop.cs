using System;
using Project._Screepts.Configs;
using Services;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Project._Screepts.ShopScreen
{
    public class ItemShop : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private Image _lock;
        [SerializeField] private Image _item;
        [SerializeField] private Button _buttonBuy;
        
        private AudioManager _audioManager;
        private AcitvePlayerItem _acitvePlayerItem;
        private PlayerWallet _playerWallet;
        private ShopItem _shopItem;
        private int _price = 50;
        public event Action<int> OnClick;
        private int _itemIndex;

        public void OnEnable()
        {
            _buttonBuy.onClick.AddListener(BuyItem);
        }

        private void Awake()
        {
            _audioManager = ServiceLocator.Instance.GetService<AudioManager>();
        }

        public void SetData(ShopItem data, int index, PlayerWallet wallet, AcitvePlayerItem acitvePlayerItem)
        {
            _playerWallet = wallet;
            _acitvePlayerItem = acitvePlayerItem;
            _shopItem = data;
            _item.sprite = data.Sprite;
            OnClick += _acitvePlayerItem.PurcheisItem;
            if (data.IsBuy)
            {
                _lock.gameObject.SetActive(false);
                _buttonBuy.gameObject.SetActive(false);
            }
        }

        public void BuyItem()
        {
            if (_shopItem.IsBuy && _playerWallet.Value >= _price)
            {
                _lock.gameObject.SetActive(false);
                _buttonBuy.gameObject.SetActive(false);
                _playerWallet.Sale(_price);
                _audioManager.PlayButtonClick();
                OnClick?.Invoke(_itemIndex);
            }
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (_shopItem.IsBuy)
            {
                _audioManager.PlayButtonClick();
                OnClick?.Invoke(_itemIndex);
            }
        }

        private void OnDisable()
        {
            OnClick -= _acitvePlayerItem.PurcheisItem;
            _buttonBuy.onClick.RemoveListener(BuyItem);
        }
    }
}