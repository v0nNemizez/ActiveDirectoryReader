using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.DirectoryServices.AccountManagement;

namespace ActiveDirectoryViewer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        string user = null;

        private void Kjor_Click(object sender, RoutedEventArgs e)
        {
            user = username.Text;

            try
            {

                PrincipalContext ctx = new PrincipalContext(ContextType.Domain, "skogumdata.no");
                UserPrincipal principal = new UserPrincipal(ctx);
                PrincipalSearcher searcher = new PrincipalSearcher(principal);

                foreach (UserPrincipal result in searcher.FindAll())
                    if (result.SamAccountName == user)
                    {
                        textblock.Text = result.DisplayName + "   " + result.SamAccountName;
                    }
                        

                searcher.Dispose();
                       
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex);
            }

           



            
        }

        

    }

    
}
