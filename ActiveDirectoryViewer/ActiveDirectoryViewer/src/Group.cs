using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.DirectoryServices.AccountManagement;

namespace ActiveDirectoryViewer
{
    class Group
    {
        string Groupname= null; //Gruppenavn
        string SamAccountName = null; //Brukernavn, i dette tilfellet samme som GroupName
        string desc = null; //Beskrivelse
        string GroupScope = null; // 0= local, 1=global, 2= universal


        //constructor
        public Group(string GroupName, string description, string groupscope)
        {
            Groupname = GroupName;           
            desc = description;
            GroupScope = groupscope;
        }

        //lage ny gruppe
        public bool CreateGroup()
        {
            PrincipalContext ctx = new PrincipalContext(ContextType.Domain, "testdomene.local", "OU=Groups,OU=TEST,DC=testdomene,DC=local");

            GroupPrincipal group = GroupPrincipal.FindByIdentity(ctx, Groupname);
            if (group != null)
            {
                MessageBox.Show("Gruppen finnes allerede i domenet");
                return false;
            }

            GroupPrincipal grp = new GroupPrincipal(ctx);

            if (Groupname != null && Groupname.Length > 0)
                grp.Name = Groupname;

            if (desc != null && desc.Length > 0)
                grp.Description = desc;

            grp.SamAccountName = "g-" + Groupname;

            grp.GroupScope = (System.DirectoryServices.AccountManagement.GroupScope)Enum.Parse(typeof(GroupScope), GroupScope);

            try
            {
                grp.Save();
            }
            catch(Exception e)
            {
                MessageBox.Show("Kunne ikke opprette gruppen: " + e);
                grp.Dispose();
                return false;
            }
           

            grp.Dispose();

            return true;
        }


    }

    
}
