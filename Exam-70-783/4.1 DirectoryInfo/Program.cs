using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;
using System.IO;
using System.Security.AccessControl;

namespace _4._1_DirectoryInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(@"C:\");

            Debug.WriteLine("Directories in C drive:");
            foreach(DirectoryInfo di in directoryInfo.GetDirectories())
            {
                Debug.WriteLine(di.Name);
            }
            //Criar diretorios
            var directory = Directory.CreateDirectory(@"C:\Temp2\Directory");

            var directoryCreate = new DirectoryInfo(@"C:\Temp2\DirectoryInfo");
            directoryCreate.Create();

            //Deletar
            /*if (Directory.Exists(@"C:\Temp2\Directory"))
            {
                Console.WriteLine("Deletando pasta 'C:\\Temp2\\Directory'");
                Directory.Delete(@"C:\Temp2\Directory");
            }

            if (directoryCreate.Exists)
            {
                directoryCreate.Delete();
            }*/
            System.Security.Principal.SecurityIdentifier sid = new System.Security.Principal.SecurityIdentifier(System.Security.Principal.WellKnownSidType.WorldSid, null);
            System.Security.Principal.NTAccount acct = sid.Translate(typeof(System.Security.Principal.NTAccount)) as System.Security.Principal.NTAccount;
            string strEveryoneAccount = acct.ToString();
            //Controle de acesso as pastas
            //No caso abaixo não permitir a deleção de uma determinada pasta por um determinado usuario
            DirectorySecurity directorySecurity = directoryInfo.GetAccessControl();
            directorySecurity.AddAccessRule(new FileSystemAccessRule(@"DESKTOP\FulanoX", FileSystemRights.Delete, AccessControlType.Deny));

            directoryCreate.SetAccessControl(directorySecurity);


            Console.ReadLine();
        }
    }
}
