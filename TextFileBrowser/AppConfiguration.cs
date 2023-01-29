using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextFileBrowser
{
    // Metódy pre konfiguráciu a nastavenie parametrov aplikácie
    class AppConfiguration
    {
        // Získanie hodnoty z App.config na základe kľúča
        public string GetConfigValueByKey(string key)
        {
            string value = ConfigurationManager.AppSettings.Get(@key);
            return value;
        }
    }
}
