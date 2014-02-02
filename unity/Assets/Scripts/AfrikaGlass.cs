using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Afrika
{
	class AfrikaGlass : IMessageListener
	{
        private GameMainView _view;
        private Dictionary<CountryID, Country> _countries;
        private bool _initialized;

        public AfrikaGlass(GameMainView view)
        {
            GameData.State = GameState.PickingCountry;

            _view = view;
            _countries = new Dictionary<CountryID, Country>();
            MessageManager.AddListener(this);

            GameData.Money = 100000;
        }

        public void init() {
            if (_initialized)
                return;
            _countries.Add(CountryID.Country0_Ivorygal, new Country(CountryID.Country0_Ivorygal));
            _countries.Add(CountryID.Country1_Libgyptia, new Country(CountryID.Country1_Libgyptia));
            _countries.Add(CountryID.Country2_Congola, new Country(CountryID.Country2_Congola));
            _countries.Add(CountryID.Country3_Kenyopia, new Country(CountryID.Country3_Kenyopia));
            _countries.Add(CountryID.Country4_Nambafrica, new Country(CountryID.Country4_Nambafrica));
            _countries.Add(CountryID.Country5_Madagascar, new Country(CountryID.Country5_Madagascar));


            var countryViews = GameObject.FindObjectsOfType<CountryComp>();
            if (countryViews.Length != 6)
                throw new Exception("Unable to find 6 country views... found:" + countryViews.Length);

            foreach (var c in countryViews) {
                _countries[c.countryId].View = c;

                c.Model = _countries[c.countryId];
            }
            _initialized = true;
        }

        public void onMessage(IMessage message)
        {
            Debug.Log("AfrikaGlass.onMessage" + message);

            if (message is CountryClickedMessage)
            {
                var msg = message as CountryClickedMessage;
                var country = _countries[msg.Country];
                if (!country.isPurchased) {
                    if (GameData.Money >= country.getPurchasePrice()) {
                        country.purchase();
                        GameData.State = GameState.Playing;
                        GameData.Money -= country.getPurchasePrice();

                        GameData.LastShipmentTimestamp = GameData.GameTime;
                        country.icecreams = country.warehouseSize;
                        selectCountry(msg.Country);
                    }
                } else {
                    if (!country.isSelected) {
                        selectCountry(country.CountryID);
                    }
                }
            }
            else if(message is IcecreamPurchasedMessage) {
                var msg = message as IcecreamPurchasedMessage;
                GameData.Money += GameData.SellPrice;
            } else if (message is WarehousePurchaseMessage) {
                var msg = message as WarehousePurchaseMessage;
                if (GameData.Money >= GameData.WarehouseCost) {
                    _countries[msg.countryId].increaseWarehouseLimit();
                    GameData.Money -= GameData.WarehouseCost;
                }
            }
        }

        private void selectCountry(CountryID id) {
            foreach (var c in _countries.Values) {
                c.isSelected = false;
            }
            _countries[id].isSelected = true;
            GameData.PickedCountry = _countries[id];
        }

        public void update(float time) {
            //update state
            GameData.GameTime = time;
            if (GameData.SecondsToArrival < 0) {
                GameData.LastShipmentTimestamp = GameData.GameTime;
                GameData.PickedCountry.icecreams = GameData.PickedCountry.warehouseSize;
            }

            //update game
            MessageManager.Update();
            foreach (var c in _countries.Values) {
                c.update();
            }
        }

    }
}
