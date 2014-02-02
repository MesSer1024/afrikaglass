using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Afrika
{
    public enum GameState {
        Frontend,
        Paused,
        PickingCountry,
        Playing,
    }

    public enum CountryID {
        Country0_Ivorygal,
        Country1_Libgyptia,
        Country2_Congola,
        Country3_Kenyopia,
        Country4_Nambafrica,
        Country5_Madagascar,
        World,
    }

    public static class GameData
	{

        public static float GameTime { get; set; }
        public static GameState State { get; set; }
        public static int Money { get; set; }
        public static float SecondsToArrival {
            get {
                if (State == GameState.PickingCountry)
                    return ShipmentTime;
                var arrival = LastShipmentTimestamp + ShipmentTime;
                return arrival - GameTime;
            }
        }
        public static float LastShipmentTimestamp { get; set; }

        internal static Country PickedCountry { get; set; }

        public static int SellPrice { get; set; }

        public static float SellChance { get; set; }

        public static int WarehouseCost { get; set; }

        public static int ShipmentTime { get; set; }
    }
}
