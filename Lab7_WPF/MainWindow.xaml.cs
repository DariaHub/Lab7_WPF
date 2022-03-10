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

namespace Lab7_WPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
        public MainWindow()
        {
            
            InitializeComponent();
        }


        private List<int> allWindowOpenNumbers = new List<int>();


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (allWindowOpenNumbers.Count == 5)
            {
                MessageBox.Show("Уже открыто 5 окон");
                return;
            }

            bool isPrevWindowsTotal = true;

            int windowNumber = 0;

            for (int i = 0; i < allWindowOpenNumbers.Count; i++)
            {
                int numberList = allWindowOpenNumbers[i];
                if (numberList != i + 1)
                {
                    allWindowOpenNumbers.Add(i + 1);
                    allWindowOpenNumbers.Sort();
                    windowNumber = i + 1;
                    isPrevWindowsTotal = false;
                    break;
                }
            }

            if (allWindowOpenNumbers.Count == 0)
            {
                allWindowOpenNumbers.Add(1);
            }
            else if (isPrevWindowsTotal)
            {
                allWindowOpenNumbers.Add(allWindowOpenNumbers.Count + 1);
            }

            if (windowNumber == 0)
            {
                windowNumber = allWindowOpenNumbers.Count;
            }

            NewWin newWindow = new NewWin($"Окно {windowNumber}", windowNumber);
            newWindow.Closed += NewWindow_Closed;
            newWindow.Show();
        }

        private void NewWindow_Closed(object sender, EventArgs e)
        {
            NewWin newWindow = (NewWin)sender;
            int windowNumber = int.Parse(newWindow.Title[newWindow.Title.Length - 1].ToString());
            Rect rect = new Rect(newWindow.Left, newWindow.Top, newWindow.Width, newWindow.Height);
            Properties.Settings.Default[$"windowPosition{windowNumber}"] = rect;
            Properties.Settings.Default.Save();

            for (int i = 0; i < allWindowOpenNumbers.Count; i++)
            {
                if (allWindowOpenNumbers[i] == windowNumber)
                {
                    allWindowOpenNumbers.RemoveAt(i);
                }
            }
            allWindowOpenNumbers.Sort();
        }
    }


}

