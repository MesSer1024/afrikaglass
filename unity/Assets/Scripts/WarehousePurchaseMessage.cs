using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Afrika {
    class WarehousePurchaseMessage : IMessage {
        public CountryID countryId { get; private set; }

        public WarehousePurchaseMessage(CountryID countryId) {
            this.countryId = countryId;
        }

        public string getId() {
            return "";
        }
    }
}
