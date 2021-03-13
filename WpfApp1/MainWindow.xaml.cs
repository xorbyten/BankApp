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
    }
}
