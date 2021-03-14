using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1.Classes;
using Microsoft.Win32;
using System.Threading;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BankAccount bankAccount;

        string text;
        int sum;
        public MainWindow()
        {
            InitializeComponent();
            SaveProgramProperties();
            LoadProgramProperties();
            bankAccount = new BankAccount(50);
            this.DataContext = bankAccount;
            bankAccount.NotifyEvent += new BankAccount.AccountHandler(DisplayMessage);
        }

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            text = tx_add.Text;
            sum = Convert.ToInt32(text);
            bankAccount.Add(sum);
        }

        public void btn_del_Click(object sender, RoutedEventArgs e)
        {
            text = tx_add.Text;
            sum = Convert.ToInt32(text);
            bankAccount.Del(sum);
        }

        private void DisplayMessage(object sender, CustomEvent e)
        {
            MessageBox.Show(e.message + e.sum);
        }

        private void SaveProgramProperties()
        {
            RegistryKey registryKey = Registry.CurrentUser;

            registryKey.CreateSubKey("Software");
            registryKey.CreateSubKey("BankAppExample");

            registryKey.SetValue("WinState", (int)WindowState);

            if(WindowState == WindowState.Normal)
            {
                registryKey.SetValue("width", Width);
                registryKey.SetValue("height", Height);
                registryKey.SetValue("left", Left);
                registryKey.SetValue("top", Top);
            }
        }

        private void LoadProgramProperties()
        {
            RegistryKey registryKey = Registry.CurrentUser;

            registryKey.CreateSubKey("Software");
            registryKey.CreateSubKey("BankAppExample");

            Width = Convert.ToDouble(registryKey.GetValue("width", Width));
            Height = Convert.ToDouble(registryKey.GetValue("height", Height));
            Left = Convert.ToDouble(registryKey.GetValue("left", Left));
            Top = Convert.ToDouble(registryKey.GetValue("top", Top));

            WindowState = (WindowState)registryKey.GetValue("WinState", WindowState.Normal);

            /*new Thread(() => {
                Thread.CurrentThread.IsBackground = true;

                string[] options = registryKey.GetValueNames();
                foreach (var i in options)
                    tx_registry_options.Text = i;
            }).Start();*/

            registryKey.Close();
        }
    }
}
