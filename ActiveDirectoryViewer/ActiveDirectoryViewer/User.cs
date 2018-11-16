using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;


namespace ActiveDirectoryViewer
{
    public class User
    {
        string username = null;
        string firstname = null;
        string lastname = null;
        string description = null;

     public User(string user, string fname, string lname, string des)
        {
            username = user;
            firstname = fname;
            lastname = lname;
            description = des;
        }  
        
        public User (string user)
        {
            username = user;
        }


    private void Create()
        {


                
        }

    public string Search()
        {
            try
            {

                PrincipalContext ctx = new PrincipalContext(ContextType.Domain, "testdomene.local");
                UserPrincipal principal = new UserPrincipal(ctx);
                PrincipalSearcher searcher = new PrincipalSearcher(principal);

                foreach (UserPrincipal result in searcher.FindAll())
                    if (result.SamAccountName == username)
                    {
                        return result.DisplayName + "   " + result.SamAccountName;
                    }


                searcher.Dispose();
            }
            catch (Exception ex)
            {
               return "Error:" + ex;
            }


            return null;
        }

    

       

         




    }
}
