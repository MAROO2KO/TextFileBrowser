using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TextFileBrowser
{
    // Metódy pre získavannie obsahu pre UI - DataContext
    class DataBind
    {
        // Výška okna (monitoru) - využíva metóda GetScreenHeight()
        public double ScreenHeight { get; set; }

        // Vráti hodnotu {ScreenHeight} do SearchTextFiles.xaml
        public DataBind GetScreenHeight()
        {
            DataBind screenHeight = new DataBind()
            {
                ScreenHeight = SystemParameters.PrimaryScreenHeight * 0.98
            };
            return screenHeight;
        }
    }
}
