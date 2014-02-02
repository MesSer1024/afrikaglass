using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Afrika;
using UnityEngine;

namespace Afrika
{
    class Country
    {
        private const int WAREHOUSE_SIZE = 165;
        public CountryID CountryID {
            get { return _countryID; }
        }
        public CountryComp View { get; set; }
        public bool isPurchased { get; private set; }
        public bool isSelected { get; set; }
        public int icecreams { get; set; }
        public int warehouseSize { get; private set; }

        private CountryID _countryID;
        private int _warehouseMultiplier = 0;

        private float _chanceToEatIcecream;
        private int _purchasePrice;

        public Country(CountryID countryID) {
            _countryID = countryID;
            icecreams = 0;
            warehouseSize = 0;

            switch (_countryID) {
                case CountryID.Country0_Ivorygal:
                    _purchasePrice = 75000;
                    _chanceToEatIcecream = GameData.SellChance;
                    break;
                case CountryID.Country1_Libgyptia:
                    _purchasePrice = 75001;
                    _chanceToEatIcecream = GameData.SellChance;
                    break;
                case CountryID.Country2_Congola:
                    _purchasePrice = 75002;
                    _chanceToEatIcecream = GameData.SellChance;
                    break;
                case CountryID.Country3_Kenyopia:
                    _purchasePrice = 75003;
                    _chanceToEatIcecream = GameData.SellChance;
                    break;
                case CountryID.Country4_Nambafrica:
                    _purchasePrice = 75004;
                    _chanceToEatIcecream = GameData.SellChance;
                    break;
                case CountryID.Country5_Madagascar:
                    _purchasePrice = 75005;
                    _chanceToEatIcecream = GameData.SellChance;
                    break;
                default:
                    _purchasePrice = int.MaxValue;
                    _chanceToEatIcecream = 0.0f;
                    break;
            }
        }

        public int getPurchasePrice() {
            return _purchasePrice;
        }

        public void purchase() {
            if (isPurchased)
                throw new Exception("Trying to purchase already purchased country : " + _countryID.ToString());

            isPurchased = true;
            increaseWarehouseLimit();
            Debug.Log("purchased country: " + _countryID.ToString());
        }

        public void increaseWarehouseLimit() {
            _warehouseMultiplier++;
            warehouseSize = WAREHOUSE_SIZE * _warehouseMultiplier;
        }

        public void update() {
            if (isPurchased) {
                if (icecreams > 0 && UnityEngine.Random.value < _chanceToEatIcecream) {
                    icecreams--;
                    MessageManager.QueueMessage(new IcecreamPurchasedMessage(_countryID));
                }
            }
        }
    }
}
