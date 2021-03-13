using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Classes
{
    class CustomEvent
    {
        public string message;
        public string Message { get; private set; }
        public int sum;
        public int Sum { get; private set; }

        public CustomEvent(string _message, int _sum)
        {
            this.message = _message;
            this.sum = _sum;
        }
    }
}
