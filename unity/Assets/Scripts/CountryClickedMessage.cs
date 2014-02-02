using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Afrika
{
	public class CountryClickedMessage : IMessage
	{
        public CountryID Country { get; private set; }

        public CountryClickedMessage(CountryID id) {
            Country = id;
        }

        public string getId() {
            return "CountryClickedMessage";
        }

    }
}
