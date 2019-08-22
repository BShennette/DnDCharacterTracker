using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace DnDCharacterTracker
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        string fName = "FName\nLName";
        string lName = "Class | Level";
        int HPCount = 0;
        int TempHPCount = 0;


        public UserControl1()
        {
            InitializeComponent();
            this.DataContext = this;

            this.FName.Text = fName;
            this.LName.Text = lName;
            this.HP.Text = HPCount.ToString();
            this.TempHP.Text = TempHPCount.ToString();
        }

        private void HPAdd(object sender, RoutedEventArgs e)
        {
            this.HP.Text = (++HPCount).ToString(); 
        }
        private void HPSubtract(object sender, RoutedEventArgs e)
        {
            if (int.Parse(HP.Text) > 0)
                this.HP.Text = (--HPCount).ToString();
        }
        private void TempHPAdd(object sender, RoutedEventArgs e)
        {
            this.TempHP.Text = (++TempHPCount).ToString();
        }
        private void TempHPSubtract(object sender, RoutedEventArgs e)
        {
            if(int.Parse(TempHP.Text) > 0)
                this.TempHP.Text = (--TempHPCount).ToString();
        }

        private void NumberInputValidation (object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void TextChanged(object sender, TextChangedEventArgs e)
        {
            if(((TextBox)e.Source).Name.Equals("HP"))
            {
                if(HP.Text == "")
                {
                    HP.Text = "0";
                }
                HPCount = int.Parse(HP.Text);
            }
            if(((TextBox)e.Source).Name.Equals("TempHP"))
            {
                if (TempHP.Text.Equals(""))
                {
                    TempHP.Text = "0";
                }
                TempHPCount = int.Parse(TempHP.Text);
            }
        }
    }
}
