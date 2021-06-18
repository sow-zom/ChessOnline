using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ChessOnline
{
    /// <summary>
    /// Interaction logic for MatchRez.xaml
    /// </summary>
    public partial class MatchRez : Window
    {
        public MatchRez()
        {
            InitializeComponent();
        }
        public MatchRez(int Match_rez, int SM)
        {
            InitializeComponent();
            //MatchRez_Show();
            MatchRez_Show(Match_rez, SM);
        }

        void MatchRez_Show(int MatchRez, int SM)
        {
            if (SM == 2) {rez.Text = "ПАТ"; rez.Background = Brushes.Bisque; }
            else
            {
                switch (MatchRez)
                {
                    case 1: rez.Text = "Білі перемогли"; rez.Foreground = Brushes.White; rez.Background = Brushes.Black; ; break;
                    case 2: rez.Text = "Чорні перемогли"; rez.Foreground = Brushes.Black; rez.Background = Brushes.White; ; break;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MMenuWindow on = new MMenuWindow();
            MatchRez on2 = new MatchRez();
            this.Close();
            on.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow on = new MainWindow();
            MatchRez on2 = new MatchRez();
            this.Close();
            on.Show();
        }
    }
}
