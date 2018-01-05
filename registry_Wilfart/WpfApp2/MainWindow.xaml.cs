using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
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
using Microsoft.Win32;
using System.Security.Principal;
using System.Reflection;
using System.Diagnostics;
using System.ComponentModel;
using System.IO.MemoryMappedFiles;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace WpfApp2
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }

        //[PrincipalPermission(SecurityAction.Demand, Role = @"BUILTIN\Administrators")]
        public void PrivAccess(int size)
        {
            WindowsPrincipal pricipal = new WindowsPrincipal(WindowsIdentity.GetCurrent());
            bool hasAdministrativeRight = pricipal.IsInRole(WindowsBuiltInRole.Administrator);
            if (!hasAdministrativeRight)
            {
                // relaunch the application with admin rights
                ProcessStartInfo processInfo = new ProcessStartInfo();
                processInfo.Verb = "runas";

                // remplaaçable par traitement de dossier : System.Reflection.Assembly.GetExecutingAssembly().Location
                processInfo.FileName = @"C:\Users\Emmanuel\Documents\Visual Studio 2017\Projects\WpfApp1\ConsoleApp1\bin\Debug\ConsoleApp1.exe";
                processInfo.Arguments = size.ToString();
                try
                {
                    Process.Start(processInfo);
                 }
                catch (Win32Exception)
                {
                    // This will be thrown if the user cancels the prompt
                }

                return;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RegistryKey Soft = Registry.LocalMachine.OpenSubKey("SOFTWARE",true);
            RegistryKey Log = Soft.CreateSubKey("MonLogiciel", true);
            Log.SetValue("UserName", data.Text, RegistryValueKind.String);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            RegistryKey Soft = Registry.CurrentUser.OpenSubKey("SOFTWARE", true);
            RegistryKey Log = Soft.CreateSubKey("MonLogiciel", true);
            MessageBox.Show(Log.GetValue("UserName", "wilfart").ToString());
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

            // this is what we want to write to the memory mapped file
            //Message message1 = new Message();
            //message1.title = "test";
            //message1.content = "hello world";

            ClassLibrary2.LoginInfo test = new ClassLibrary2.LoginInfo();
            test.Nom = data.Text;
            test.Password = data.Text;

            // serialize the variable 'message1' and write it to the memory mapped file
            BinaryFormatter formatter = new BinaryFormatter();

            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            byte[] Array;
            bf.Serialize(ms, test);
            Array = ms.ToArray();

            // la taille permet de dynamiser la taille du buffer et de l'envoyer en arguments pour
            // le récupérer de l'app console qui récupèrera la même taille de buffer
            // quelque soit la taile de classe qui peut désormais évoluter.
            int size = Array.Length;
            // creates the memory mapped file which allows 'Reading' and 'Writing'
            MemoryMappedFile mmf = MemoryMappedFile.CreateOrOpen("mmf1", size, MemoryMappedFileAccess.ReadWrite);

            // creates a stream for this process, which allows it to write data from offset 0 to 1024 (whole memory)
            MemoryMappedViewStream mmvStream = mmf.CreateViewStream(0, size);


            formatter.Serialize(mmvStream, test);
            mmvStream.Seek(0, SeekOrigin.Begin); // sets the current position back to the beginning of the stream
            PrivAccess(size);
        }
    }
}
