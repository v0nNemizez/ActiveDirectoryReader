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
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;

namespace ActiveDirectoryViewer
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            
        }




        

   

        private void createuser_OnClick(object sender, RoutedEventArgs e)
        {
            User usr = new User(username.Text, fname.Text, lname.Text);
            if(usr.Create() == true)
            MessageBox.Show("Brukeren er opprettet");

        }
    }
}
