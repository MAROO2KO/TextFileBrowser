using MS.WindowsAPICodePack.Internal;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace TextFileBrowser
{
    // Konfigurácia a nastavenie parametrov aplikácie
    class AppConfiguration
    {
        // Získanie hodnoty z App.config na základe kľúča
        public string GetConfigValueByKey(string key)
        {
            string value = ConfigurationManager.AppSettings.Get(@key);
            return value;
        }

        // Zobrazenie hodnoty v resultBox v UI
        public void ResultBoxLog(string s, MainWindow mw)
        {
            mw.Dispatcher.BeginInvoke(new MainWindow.resultToResultBox(mw.updateResultBox), DispatcherPriority.Render, new object[] { s }); ;
        }
    }
}
