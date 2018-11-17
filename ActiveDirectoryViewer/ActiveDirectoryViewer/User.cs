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


    private bool Create()
        {
            PrincipalContext ctx = new PrincipalContext(ContextType.Domain, "testdomene.local");

             UserPrincipal usr = UserPrincipal.FindByIdentity(ctx, username);
            if (usr != null)
            {
                
                return false;
            }

            UserPrincipal userPrincipal = new UserPrincipal(ctx);
            if (lastName != null && lastName.Length > 0)
                userPrincipal.Surname = lastName;

            return true;

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
