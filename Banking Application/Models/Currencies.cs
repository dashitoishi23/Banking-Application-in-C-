using System;
using System.Collections.Generic;
using System.Text;

namespace Banking_Application
{
    class Currencies
    {
        public string Name { get; set; }
        public int ExchangeRate { get; set; }
        public bool IsDefault { get; set; }

        public Currencies(string Name, int ExchangeRate, bool IsDefault)
        {
            this.Name = Name;
            this.ExchangeRate = ExchangeRate;
            this.IsDefault = IsDefault;
        }

    }
}
