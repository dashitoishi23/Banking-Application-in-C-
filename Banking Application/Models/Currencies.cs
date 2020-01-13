using System;
using System.Collections.Generic;
using System.Text;

namespace Banking_Application
{
    class Currencies
    {
        public string Name;
        public int ExchangeRate;
        public bool IsDefault;

        public Currencies(string Name, int ExchangeRate, bool IsDefault)
        {
            this.Name = Name;
            this.ExchangeRate = ExchangeRate;
            this.IsDefault = IsDefault;
        }

    }
}
