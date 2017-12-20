using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < args.Length; i++)
                Console.WriteLine(args[i]);

            // creates the memory mapped file
            MemoryMappedFile mmf = MemoryMappedFile.OpenExisting("mmf1");
            MemoryMappedViewStream mmvStream = mmf.CreateViewStream(0, int.Parse(args[0])); // stream used to read data

            BinaryFormatter formatter = new BinaryFormatter();

            // needed for deserialization
            byte[] buffer = new byte[int.Parse(args[0])];

            ClassLibrary2.LoginInfo test;

            // reads every second what's in the shared memory
            if (mmvStream.CanRead)
            {
                // stores everything into this buffer
                mmvStream.Read(buffer, 0, int.Parse(args[0]));

                // deserializes the buffer & prints the message
                test = (ClassLibrary2.LoginInfo)formatter.Deserialize(new MemoryStream(buffer));
                //Console.WriteLine("Nom:{0} Password:{1}", test.Nom, test.Password);
                RegistryKey Soft = Registry.LocalMachine.OpenSubKey("SOFTWARE", true);
                RegistryKey Log = Soft.CreateSubKey("MonLogiciel", true);
                Log.SetValue("UserName", test.Nom, RegistryValueKind.String);
            }

            //Console.ReadKey();
        }
    }
}
