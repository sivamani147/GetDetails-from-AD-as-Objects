using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            //(&(objectCategory = group)(cn = myCustomGroup))
            /*UserPrincipal user = UserPrincipal.Current;

            if (user != null)
            {
                foreach(var one in user.GetGroups().ToArray())
                Console.WriteLine(one); // or whatever you mean by "login name"
            }
            
            Regex rx = new Regex(@"pasalapudi",
                RegexOptions.Compiled | RegexOptions.IgnoreCase);
            var context = new PrincipalContext(ContextType.Domain, "corp");
            using (var searcher = new PrincipalSearcher())
            {
                var groupName = "dlinhyderabadall1";
                var sp = new GroupPrincipal(context, groupName);
                searcher.QueryFilter = sp;
                var group = searcher.FindOne() as GroupPrincipal;

                if (group == null)
                    Console.WriteLine("Invalid Group Name: {0}", groupName);

                foreach (var f in group.GetMembers())
                {
                    var principal = f as UserPrincipal;


                    if (principal == null || string.IsNullOrEmpty(principal.DisplayName))
                        continue;
                    if(rx.IsMatch(principal.DisplayName))
                    Console.WriteLine("{0}", principal.Name);
                }
            }*/

            DirectorySearcher searcher1 = new DirectorySearcher("LDAP://DC=company,DC=com")
            {
                Filter = string.Format("(&(objectCategory=person)(objectClass=user)(cn={0}))", "spasalap")
            };
            SearchResult results1;
            results1 = searcher1.FindOne();
            DirectoryEntry directoryEntry = results1.GetDirectoryEntry();
            foreach(string one in directoryEntry.Properties.PropertyNames)
            {
                Console.WriteLine(one +" "+ directoryEntry.Properties[one].Value);
            }
        }
    }
}
