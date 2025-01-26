using System;
using System.Collections.Generic;
using UnityEngine;

namespace Project._Screepts.Configs
{
    [CreateAssetMenu(fileName = "PlayerSprites", menuName = "ScriptableObjects/PlayerSprites")]
    public class AcitvePlayerItem : ScriptableObject
    {
        [SerializeField] private List<ShopItem> _sprites;
        [SerializeField] private Sprite _activeSprite;

        private void Awake()
        {
            _sprites.ForEach((item) => { item.InitItem(); });
        }

        public Sprite GetActiveSprite()
        {
            var itemIndex = PlayerPrefs.GetInt("ActiveItem", 0);
            return _sprites[itemIndex].Sprite;
        }

        public void PurcheisItem(int itemIndex)
        {
            _sprites[itemIndex].BuyItem();
        }
    }


    [Serializable]
    public struct ShopItem
    {
        public Sprite Sprite;
        public bool IsBuy;
        public int itemIndex;

        public void InitItem()
        {
            var reslut = PlayerPrefs.GetInt($"{itemIndex}", 0);
            if (reslut != 0)
            {
                IsBuy = true;
                return;
            }

            IsBuy = false;
        }

        public void BuyItem()
        {
            PlayerPrefs.SetInt($"{itemIndex}", 1);
            IsBuy = true;
        }
    }
}