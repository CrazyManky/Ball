using Project._Screepts.Configs;
using UnityEngine;

namespace Project._Screepts.Screns
{
    public class RecordScreen : BaseScreen
    {
        [SerializeField] private RectTransform _itemConteiner;
        [SerializeField] private RecordItem _itemPrefab;
        [SerializeField] private PlayerRecords _playerRecords;

        public override void Init()
        {
            base.Init();
            var items = _playerRecords.GetSortedItems();
            for (int i = 0; i < items.Count; i++)
            {
                var instance = Instantiate(_itemPrefab, _itemConteiner);
                instance.SetData(i, items[i]);
            }
        }


        public void ShowMenuScreen()
        {
            AudioManager.PlayButtonClick();
            Dialog.ShowMenuScreen();
        }
    }
}