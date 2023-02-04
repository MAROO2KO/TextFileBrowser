using Microsoft.Win32;
using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Threading;


namespace TextFileBrowser
{
    public partial class MainWindow : Window
    {
        public delegate void resultToResultBox(string result); // Callback pre zapisovanie výsledku do resultBox

        public MainWindow()
        {
            InitializeComponent();

            // Získa výšku okna (monitoru) a vráti {ScreenHeight} do TextFileBrowser.xaml
            DataBind ui = new DataBind();
            DataContext = ui.GetScreenHeight();
        }

        // Checkboxy
        // Ak sa zaškrtne checkbox Adresár
        private void checkFolder_Checked(object sender, RoutedEventArgs e)
        {
            checkRecurse.IsChecked = false;
            checkRecurse.IsEnabled = true;
            checkFile.IsChecked = false;
            chooseFileBtn.IsEnabled = true;
            searchBtn.IsEnabled = true;
        }

        // Ak sa odškrtne checkbox Adresár
        private void checkFolder_Unchecked(object sender, RoutedEventArgs e)
        {
            checkRecurse.IsChecked = false;
            checkRecurse.IsEnabled = false;
            if (checkFile.IsChecked == false)
            {
                chooseFileBtn.IsEnabled = false;
                searchBtn.IsEnabled = false;
            }
        }

        // Ak sa zaškrtne checkbox Súbor
        private void checkFile_Checked(object sender, RoutedEventArgs e)
        {
            checkFolder.IsChecked = false;
            checkRecurse.IsChecked = false;
            checkRecurse.IsEnabled = false;
            chooseFileBtn.IsEnabled = true;
            searchBtn.IsEnabled = true;
        }

        // Ak sa odškrtne checkbox Súbor
        private void checkFile_Unchecked(object sender, RoutedEventArgs e)
        {
            if (checkFolder.IsChecked == false)
            {
                chooseFileBtn.IsEnabled = false;
                searchBtn.IsEnabled = false;
            }
        }


        // Buttony
        // Výber adresáru na prehľadávanie, button Vybrať
        private void chooseFileBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Kontroly
                if (checkFile.IsChecked == false && checkFolder.IsChecked == false)
                {
                    throw new Exception("Zadefinujte typ hľadania - Súbor / Adresár !");
                }

                // Ak je zaškrtnutý checkbox Adresár
                if (checkFolder.IsChecked == true)
                {
                    CommonOpenFileDialog dialog = new CommonOpenFileDialog();
                    dialog.IsFolderPicker = true;
                    if (searchPath.Text == "")
                    {
                        dialog.InitialDirectory = "C:\\";
                    }
                    else
                    {
                        dialog.InitialDirectory = searchPath.Text;
                    }
                    if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
                    {
                        searchPath.Text = dialog.FileName;
                    }
                }
                // Ak je zaškrtnutý checkbox Súbor
                else
                {
                    OpenFileDialog dialog = new OpenFileDialog();
                    if (searchPath.Text == "")
                    {
                        dialog.InitialDirectory = "C:\\";
                    }
                    else
                    {
                        dialog.InitialDirectory = searchPath.Text;
                    }
                    dialog.DefaultExt = ".txt";
                    dialog.Filter = "Text files (*.txt, *.log)|*.txt;*.log";
                    Nullable<bool> result = dialog.ShowDialog();

                    if (result == true)
                    {
                        searchPath.Text = dialog.FileName;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "TextFileBrowser", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        

        // Spustenie prehľadávania, button Hľadať
        private void searchBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Kontroly
                if (checkFile.IsChecked == false && checkFolder.IsChecked == false)
                {
                    throw new Exception("Zadefinujte typ hľadania - Súbor / Adresár !");
                }
                
                // Ak hľadáme v adresári / podadresároch
                if (checkFolder.IsChecked == true)
                {
                    string path = searchPath.Text;
                    string key = searchKey.Text;
                    bool recurse;

                    // Ak aj podadresáre
                    if (checkRecurse.IsChecked == true)
                    {
                        recurse = true;
                    }
                    else
                    {
                        recurse = false;
                    }

                    Task.Factory.StartNew(() =>
                    {
                        uiElementsStartTask();
                        FileFolderBrowse search = new FileFolderBrowse();
                        search.BrowseFolder(path, key, recurse, this);
                        uiElementsEndTask();
                    });
                }
                // Ak iba v súbore
                else
                {
                    string path = searchPath.Text;
                    string key = searchKey.Text;

                    Task.Factory.StartNew(() =>
                    {
                        uiElementsStartTask();
                        FileFolderBrowse search = new FileFolderBrowse();
                        search.BrowseFile(path, key, this);
                        uiElementsEndTask();
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "TextFileBrowser", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Skopírovanie výsledku z resultBox do clipboardu, button Kopírovať
        private void copyBtn_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(resultBox.Text);
        }


        // UI control
        // Vypísanie výsledku do resultBox
        public void updateResultBox(string result)
        {
            resultBox.Text = result;
        }

        // Správanie UI elementov pri štarte úlohy
        private void uiElementsStartTask()
        {
            Dispatcher.Invoke(() => checkFolder.IsEnabled = false);
            Dispatcher.Invoke(() => checkRecurse.IsEnabled = false);
            Dispatcher.Invoke(() => checkFile.IsEnabled = false);
            Dispatcher.Invoke(() => chooseFileBtn.IsEnabled = false);
            Dispatcher.Invoke(() => searchBtn.IsEnabled = false);
            Dispatcher.Invoke(() => resultBox.Text = null);
        }

        // Správanie UI elementov pri ukončení úlohy
        private void uiElementsEndTask()
        {
            Dispatcher.Invoke(() => checkFolder.IsEnabled = true);
            Dispatcher.Invoke(() => checkFile.IsEnabled = true);
            Dispatcher.Invoke(() => chooseFileBtn.IsEnabled = true);
            Dispatcher.Invoke(() => searchBtn.IsEnabled = true);
            if(Dispatcher.Invoke(() => checkFolder.IsChecked == true))
            {
                Dispatcher.Invoke(() => checkRecurse.IsEnabled = true);
            }
        }
    }
}
