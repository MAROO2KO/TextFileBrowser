using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Threading;
using System.Windows;


namespace TextFileBrowser
{
    // Metódy na prehľadávanie adresárov a súborov
    class FileFolderBrowse
    {
        // Prehľadávanie adresára / podadresárov
        public void BrowseFolder(string path, string key, bool recurse, MainWindow mw)
        {
            try
            {
                string result;

                // Kontroly                                              
                if (!Directory.Exists(path))
                {
                    throw new Exception("Adresár na prehľadávanie súborov neexistuje !");
                }

                if (key == "")
                {
                    throw new Exception("Hľadaný výraz nesmie byť prázdny !");
                }

                // Idem hľadať textové súbory
                string[] mainFiles;
                // Ak chcem hľadať aj podadresáre
                if (recurse)
                {
                    mainFiles = Directory.GetFileSystemEntries(path, "*.txt", SearchOption.AllDirectories);
                }
                // Ak iba v hlavnom adresári
                else
                {
                    mainFiles = Directory.GetFiles(path, "*.txt");
                }

                // Najskôr kontroly vstupných súborov / počet .txt nesmie byť 0
                if (mainFiles.Length == 0)
                {
                    throw new Exception("V adresári sa nenachádza žiadny textový súbor !");
                }

                // Sem ukladáme názvy súborov, kde sa nachádza hľadaný výraz
                List<string> fCont = new List<string>();

                // Prehľadaávanie vstupných súborov
                foreach (string file in mainFiles)
                {
                    // Aktualizácia stavu v resultBox UI
                    string fil = Path.GetFileName(file);
                    result = "Prehľadávam súbor " + file;
                    mw.Dispatcher.BeginInvoke(new MainWindow.resultToResultBox(mw.updateResultBox), DispatcherPriority.Render, new object[] { result }); ;
                    // Proces hľadania
                    string content = File.ReadAllText(file);
                    if (content.Contains(key))
                    {
                        fCont.Add(file);
                    }
                    //Thread.Sleep(1000);
                }

                // Výsledok
                if (fCont.Count == 0)
                {
                    result = "Hľadaný výraz " + "\"" + key + "\"" + " sa nenachádza v žiadnom súbore";
                }
                else
                {
                    string fInfo = string.Empty;
                    foreach (string f in fCont)
                    {
                        fInfo += Environment.NewLine + f;
                    }
                    result = "Hľadaný výraz " + "\"" + key + "\"" + " sa nachádza v súboroch:" + Environment.NewLine + fInfo;
                }
                Thread.Sleep(5000);
                // Zobrazenie výsledku v resultBox v UI
                mw.Dispatcher.BeginInvoke(new MainWindow.resultToResultBox(mw.updateResultBox), DispatcherPriority.Render, new object[] { result });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SearchTextFiles", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Prehľadávanie súboru
        public void BrowseFile(string path, string key, MainWindow mw)
        {
            try
            {
                string result;

                // Kontroly
                if (!File.Exists(path))
                {
                    throw new Exception("Súbor na prehľadávanie neexistuje !");
                }

                string[] allowExtensions = {".txt",".TXT",".log",".LOG"};
                string ext = Path.GetExtension(path);
                if (!allowExtensions.Contains(ext))
                { 
                    throw new Exception("Vstupný súbor môže mať iba textový formát !");
                }

                if (key == "")
                {
                    throw new Exception("Hľadaný výraz nesmie byť prázdny !");
                }

                // Prehľadávanie vstupného súboru
                // Aktualizácia stavu v resultBox UI
                string file = Path.GetFileName(path);
                result = "Prehľadávam súbor " + file;
                mw.Dispatcher.BeginInvoke(new MainWindow.resultToResultBox(mw.updateResultBox), DispatcherPriority.Render, new object[] { result }); ;
                // Proces hľadania
                string content = File.ReadAllText(path);
                if (content.Contains(key))
                {
                    result = "Hľadaný výraz " + "\"" + key + "\"" + " sa nachádza v súbore " + file;
                }
                else
                {
                    result = "Hľadaný výraz " + "\"" + key + "\"" + " sa nenachádza v súbore " + file;
                }
                Thread.Sleep(5000);
                // Zobrazenie výsledku v resultBox v UI
                mw.Dispatcher.BeginInvoke(new MainWindow.resultToResultBox(mw.updateResultBox), DispatcherPriority.Render, new object[] { result }); ;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SearchTextFiles", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
