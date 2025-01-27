using Services;
using UnityEngine;

namespace Project._Screepts.Screns
{
    public class GamePlayScreen : BaseScreen
    {
        private GameUI _gameUI;

        public override void Init()
        {
            base.Init();
            _gameUI = ServiceLocator.Instance.GetService<GameUI>();
            _gameUI.Init();
        }

        public override void Сlose()
        {
            _gameUI.Close();
            base.Сlose();
        }
    }
}