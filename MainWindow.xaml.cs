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

namespace RadAlexandra_Laborator2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DoughnutMachine myDoughnutMachine;
        private int mRaisedGlazed;
        private int mRaisedSugar;
        private int mFilledLemon;
        private int mFilledChocolate;
        private int mFilledVanilla;
        

        public MainWindow() 
        {

            InitializeComponent();
        }

        private void IblVanillaFilled1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void frmMain_Loaded(object sender, RoutedEventArgs e)
        {
            myDoughnutMachine = new DoughnutMachine();
            myDoughnutMachine.DoughnutComplete += new
        DoughnutMachine.DoughnutCompleteDelegate(DoughnutCompleteHandler);

        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void glazedMenuItem_Click(object sender, RoutedEventArgs e)
        {
            glazedMenuItem.IsChecked = true;
            sugarMenuItem.IsChecked = false;
            myDoughnutMachine.MakeDoughnuts(DoughnutType.Glazed);
        }

        private void sugarMenuItem_Click(object sender, RoutedEventArgs e)
        {
            glazedMenuItem.IsChecked = false;
            sugarMenuItem.IsChecked = true;
            myDoughnutMachine.MakeDoughnuts(DoughnutType.Sugar);
        }

        private void lemonMenuItem_Click(object sender, RoutedEventArgs e)
        {
            lemonMenuItem.IsChecked = true;
            chocolateMenuItem.IsChecked = false;
            vanillaMenuItem.IsChecked = false;
            myDoughnutMachine.MakeDoughnuts(DoughnutType.Lemon);
        }

        private void chocolateMenuItem_Click(object sender, RoutedEventArgs e)
        {
            lemonMenuItem.IsChecked = false;
            chocolateMenuItem.IsChecked = true;
            vanillaMenuItem.IsChecked = false;
            myDoughnutMachine.MakeDoughnuts(DoughnutType.Chocolate);
        }

        private void vanillaMenuItem_Click(object sender, RoutedEventArgs e)
        {
            lemonMenuItem.IsChecked = false;
            chocolateMenuItem.IsChecked = false;
            vanillaMenuItem.IsChecked = true;
            myDoughnutMachine.MakeDoughnuts(DoughnutType.Vanilla);
        }



        private void mnuStop_Click_1(object sender, RoutedEventArgs e)
        {
            myDoughnutMachine.Enabled = false;
        }

        private void DoughnutCompleteHandler()
        {
            switch (myDoughnutMachine.Flavor)
            {
                case DoughnutType.Glazed:
                    mRaisedGlazed++;
                    txtGlazedRaised.Text = mRaisedGlazed.ToString();
                    break;

                case DoughnutType.Sugar:
                    mRaisedSugar++;
                    txtSugarRaised.Text = mRaisedSugar.ToString();
                    break;
                    // ...
            }
        }
        private void txtQuantity_KeyPress(object sender, KeyEventArgs e)
        {
            if (!(e.Key >= Key.D0 && e.Key <= Key.D9))
            {
                MessageBox.Show("Numai cifre se pot introduce!", "Input Error", MessageBoxButton.OK,
               MessageBoxImage.Error);
            }
        }

    }
}
