using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.DirectoryServices;
using System.Windows;
using System.DirectoryServices.AccountManagement;

namespace ActiveDirectoryViewer
{
    public class User 
    {
        string username = null;
        string firstname = null;
        string lastname = null;
        string description = null;
        

        public User(string user, string fname, string lname)
        {
            username = user;
            firstname = fname;
            lastname = lname;
            
        }  
        
        public User (string user)
        {
            username = user;
        }


    public bool CreateUser()
        {
            PrincipalContext ctx = new PrincipalContext(ContextType.Domain, "testdomene.local", "OU=Users,OU=TEST,DC=testdomene,DC=local");
            

            UserPrincipal usr = UserPrincipal.FindByIdentity(ctx, username);
            if (usr != null)
            {
                MessageBox.Show("Brukernavn finnes allerede i domenet");
                return false;
            }

            UserPrincipal userPrincipal = new UserPrincipal(ctx);
            if (lastname != null && lastname.Length > 0)
                userPrincipal.Surname = lastname;

            if (firstname != null && firstname.Length > 0)
                userPrincipal.GivenName = firstname;

            if (username != null && username.Length > 0)
                userPrincipal.SamAccountName = username;

            if (description != null && description.Length > 0)
                userPrincipal.Description = username;

            userPrincipal.DisplayName = firstname + lastname;

            string pwd = "test1234";
            userPrincipal.SetPassword(pwd);

            userPrincipal.Enabled = false;
            userPrincipal.ExpirePasswordNow();

            try
            {
                userPrincipal.Save();
            }
            catch (Exception e)
            {
                MessageBox.Show("Kunne ikke lagre objektet." + e + "");
                return false;
            }

            
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
                    else
                    {
                        username = null;
                        return "Finner ikke bruker";
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
