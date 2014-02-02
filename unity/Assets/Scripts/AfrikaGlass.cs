using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts;

namespace Afrika
{
	class AfrikaGlass : IMessageListener
	{
        enum GameState
        {
            Frontend,
            Paused,
            PickingCountry,
            Playing,
        }

        private GameMainView _view;
        private Dictionary<CountryClickedMessage.CountryID, Country> _countries;
        private int _money;
        private int _moneyCounter;
        private GameState _state;

        public AfrikaGlass(GameMainView view)
        {
            _state = GameState.PickingCountry;
            _view = view;
            _countries = new Dictionary<CountryClickedMessage.CountryID, Country>();
            MessageManager.AddListener(this);

            _money = 100000;
            _moneyCounter = _money;
            _countries.Add(CountryClickedMessage.CountryID.Country0_Ivorygal, new Country(CountryClickedMessage.CountryID.Country0_Ivorygal));
            _countries.Add(CountryClickedMessage.CountryID.Country1_Libgyptia, new Country(CountryClickedMessage.CountryID.Country1_Libgyptia));
            _countries.Add(CountryClickedMessage.CountryID.Country2_Congola, new Country(CountryClickedMessage.CountryID.Country2_Congola));
            _countries.Add(CountryClickedMessage.CountryID.Country3_Kenyopia, new Country(CountryClickedMessage.CountryID.Country3_Kenyopia));
            _countries.Add(CountryClickedMessage.CountryID.Country4_Nambafrica, new Country(CountryClickedMessage.CountryID.Country4_Nambafrica));
            _countries.Add(CountryClickedMessage.CountryID.Country5_Madagascar, new Country(CountryClickedMessage.CountryID.Country5_Madagascar));

            var countryViews = _view.GetComponents<CountryComp>();
            if (countryViews.Length != 6) throw new Exception("Unable to find 6 country views...");

            foreach(var c in countryViews)
            {
                _countries[c.countryId].View = c;
            }
        }

        public void onMessage(IMessage message)
        {
            if (message is CountryClickedMessage)
            {
                var msg = message as CountryClickedMessage;
                if (_state == GameState.PickingCountry)
                {
                    var country = _countries[msg.Country];
                    country.purchase();
                }
            }
        }
    }
}
