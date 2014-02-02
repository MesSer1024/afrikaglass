using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Afrika {
    class IcecreamPurchasedMessage : IMessage {
        public CountryID PlaceSold { get; private set; }

        public IcecreamPurchasedMessage(CountryID _countryID) {
            PlaceSold = _countryID;
        }
        public string getId() {
            return "";
        }
    }
}
