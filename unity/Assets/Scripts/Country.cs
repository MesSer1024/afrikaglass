using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Afrika;

namespace Assets.Scripts
{
    class Country
    {
        private const int WAREHOUSE_SIZE = 125;
        private int _warehouseMultiplier = 0;

        public bool isAvailable { get; private set; }
        public int icecreams { get; private set; }
        public int warehouseSize { get; private set; }

        private CountryClickedMessage.CountryID _countryID;

        public Country(CountryClickedMessage.CountryID countryID)
        {
            _countryID = countryID;
            icecreams = 0;
            warehouseSize = 0;
        }

        public int getPurchasePrice()
        {
            int price = int.MaxValue;
            switch (_countryID)
            {
                case CountryClickedMessage.CountryID.Country0_Ivorygal:
                    price = 75000;
                    break;
                case CountryClickedMessage.CountryID.Country1_Libgyptia:
                    price = 75001;
                    break;
                case CountryClickedMessage.CountryID.Country2_Congola:
                    price = 75002;
                    break;
                case CountryClickedMessage.CountryID.Country3_Kenyopia:
                    price = 75003;
                    break;
                case CountryClickedMessage.CountryID.Country4_Nambafrica:
                    price = 75004;
                    break;
                case CountryClickedMessage.CountryID.Country5_Madagascar:
                    price = 75005;
                    break;
            }
            return price;
        }

        public void purchase()
        {
            if (isAvailable) throw new Exception("Trying to purchase allready purchased country " + _countryID.ToString());

            isAvailable = true;
            increaseWarehouseLimit();
        }

        public void increaseWarehouseLimit()
        {
            _warehouseMultiplier++;
            warehouseSize = WAREHOUSE_SIZE * _warehouseMultiplier;
        }

        public CountryComp View { get; set; }
    }
}
