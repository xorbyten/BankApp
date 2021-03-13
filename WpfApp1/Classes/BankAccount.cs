using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace WpfApp1.Classes
{
    class BankAccount : INotifyPropertyChanged
    {
        public delegate void AccountHandler(object sender, CustomEvent e);
        public event AccountHandler NotifyEvent;
        public event PropertyChangedEventHandler PropertyChanged;

        int currentSum;       
        public int CurrentSum { 
            get {
                return currentSum;
            } 
            set {
                if(currentSum > 0)
                {
                    currentSum = value;
                } else
                {
                    MessageBox.Show("Сумма не может быть отрицательной.");
                }
            } 
        }

        public BankAccount(int _currentSum)
        {
            this.currentSum = _currentSum;
        }

        public void Add(int sum)
        {
            if(sum > 0)
            {
                currentSum += sum;
                OnPropertyChanged("CurrentSum");
                NotifyEvent?.Invoke(this, new CustomEvent($"Сумма увеличена на ", sum));
            } else
            {
                NotifyEvent?.Invoke(this, new CustomEvent("Нельзя добавить отрицательную сумму.", sum));
            }
        }

        public void Del(int sum)
        {
            if(sum != currentSum)
            {
                currentSum -= sum;
                OnPropertyChanged("CurrentSum");
                NotifyEvent?.Invoke(this, new CustomEvent($"У вас отобрали ", sum));
            } else
            {
                NotifyEvent?.Invoke(this, new CustomEvent($"Нельзя отбирать так много.", sum));
            }
        }

        protected void OnPropertyChanged(string PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
    }
}
