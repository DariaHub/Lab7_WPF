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
using System.Windows.Shapes;

namespace Lab7_WPF
{
    /// <summary>
    /// Логика взаимодействия для NewWin.xaml
    /// </summary>
    public partial class NewWin : Window
    {
        private int windowNumber;

        public NewWin()
        {
            InitializeComponent();
        }

        public NewWin(string Title, int windowNumber)
        {
            InitializeComponent();
            this.windowNumber = windowNumber;
            this.Title = Title;
            Rect position = (Rect)Properties.Settings.Default[$"windowPosition{this.windowNumber}"];

            this.Left = position.Left;
            this.Top = position.Top;

            this.Width = position.Width;
            this.Height = position.Height;
        }
    }
}
