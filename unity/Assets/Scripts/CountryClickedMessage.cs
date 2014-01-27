using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Afrika
{
	class CountryClickedMessage : IMessage
	{
        public enum CountryID
        {
            Country0_Ivorygal,
            Country1_Libgyptia,
            Country2_Congola,
            Country3_Kenyopia,
            Country4_Nambafrica,
            Country5_Madagascar,
            World,
        }

        public CountryID Country { get; private set; }

        public CountryClickedMessage(CountryID id) {
            Country = id;
        }

        public string getId() {
            return "CountryClickedMessage";
        }

    }
}
