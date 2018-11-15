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
            PopulateDropDown();
        }


    private void PopulateDropDown()
        {
            string[] OU = null;

            DirectoryEntry entry = new DirectoryEntry("LDAP://testdomene.local");
            DirectorySearcher Searcher = new DirectorySearcher(entry);
            Searcher.Filter = ("(objectClass=organizationalUnit)");
            Searcher.SizeLimit = int.MaxValue;
            Searcher.PageSize = int.MaxValue;

            foreach (SearchResult each in Searcher.FindAll())
            {
                OU = each.GetDirectoryEntry();
                comboboxOU.ItemsSource
            }

            Searcher.Dispose();
            entry.Dispose();

        }
    }
}
