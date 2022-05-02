using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Lab_9
{
    public class Commands
    {
        public static RoutedUICommand Visible { get; set; }

        static Commands()
        {
            Visible = new RoutedUICommand("Visible", "name", typeof(MainWindow));
        }
    }
}
