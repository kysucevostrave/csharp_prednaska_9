using System;
using System.IO;
using System.IO.Pipes;

namespace csharp_prednaska_9
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Path.Combine("./", "..", "adresar/test", "a.jpg");

            string name = Path.GetFileName(path);
            string nameWithoutExt = Path.GetFileNameWithoutExtension(path);
            string ext = Path.GetExtension(path);



            //FileStream myStream = new FileStream("test.txt", FileMode.Create);
            /*FileStream myStream = new FileStream(
                "test.txt", 
                FileMode.Create, 
                FileAccess.Read,
                FileShare.Read, 
                1024
                );
            */
            //myStream.Lock(0,myStream.Length);
            //myStream.Unlock(0, myStream.Length);


            byte[] buffer = new byte[] { 65,66,67,68 };

            //------------------------------------------------------------
            /* using FileStream myStream = new FileStream(
                 "test.txt",
                 FileMode.Create
                 )

                 myStream.Write(buffer, 0, 1);

                 myStream.Flush();
                 myStream.Close();
            */
             //------------------------------------------------------------

             using (FileStream myStream = new FileStream(
                     "test.txt",
                     FileMode.Create
                     ))
             {
                 myStream.Write(buffer, 0, buffer.Length);

                myStream.Seek(1, SeekOrigin.Begin);

                myStream.WriteByte(69);

                 myStream.Flush();
                 //using vola za nas close aj dispose
             }


            //------------------------------------------------------------
            /*FileStream myStream = null;
            try
            {
                myStream = new FileStream(
                    "test.txt",
                    FileMode.Create
                    );
                myStream.Write(buffer, 0, 1);

                myStream.Flush();
                myStream.Close();
            }
            finally
            {

                if(myStream != null)
                {
                    myStream.Close();
                    myStream.Dispose();
                }
            }
           */

            byte[] buffer2 = new byte[2];


            using (FileStream myStream2 = new FileStream(
                    "test.txt",
                    FileMode.Open
                    ))
            {
                myStream2.Seek(1, SeekOrigin.Begin);
                myStream2.Read(buffer2, 0, 2);

                Console.WriteLine(buffer2[0]);
                Console.WriteLine(buffer2[1]);
                Console.WriteLine(myStream2.Position);

                
                //using vola za nas close aj dispose
            }

            using (FileStream myStream3 = new FileStream(
                    "test3.txt",
                    FileMode.Create
                    ))
            {
                using (StreamWriter sw = new StreamWriter(myStream3))
                {
                    sw.WriteLine("Ahoj");
                    sw.WriteLine("Jak se máš?");
                    sw.Write("Test..");
                    sw.Write("ABC");
                    sw.WriteLine(6);
                    sw.WriteLine(6.459);
                }
            }

            using (MemoryStream myStream7 = new MemoryStream()) // cita z RAMky
            {
                using (StreamWriter sw2 = new StreamWriter(myStream7)) 
                {
                    sw2.WriteLine("Test");
                }
                using (StreamReader sr2 = new StreamReader(myStream7))
                {
                    string l1 = sr2.ReadLine();
                    Console.WriteLine(); 
                }
            }



            using (FileStream myStream5 = new FileStream(
                    "test3.txt",
                    FileMode.Open
                    ))
            {
                using (StreamReader sr = new StreamReader(myStream5)) //da sa dat (myStream5, Encoding.UTF8)
                {
                    string l1 = sr.ReadLine();
                    string l2 = sr.ReadLine();
                    string l3 = sr.ReadLine();
                    Console.WriteLine(l1);
                    Console.WriteLine(l2);
                    Console.WriteLine(l3);
                }
            }


            using (FileStream myStream4 = new FileStream(
                    "test4.bin",
                    FileMode.Create
                    ))
            {
            using (BinaryWriter bw = new BinaryWriter(myStream4))
                {
                    bw.Write("Ahoj");
                    bw.Write(6);
                    bw.Write(6.166);
                }
            }
            
            using (FileStream myStream6 = new FileStream(
                    "test4.bin",
                    FileMode.Open
                    ))
            {
                using (BinaryReader br = new BinaryReader(myStream6))
                {
                    string txt = br.ReadString();
                    int num = br.ReadInt32();
                    double dou = br.ReadDouble();
                    Console.WriteLine();
                }
            }


            using NamedPipeServerStream ps = new NamedPipeServerStream("test");
            ps.WaitForConnection();
            ps.WriteByte(65);


            //TOTO dame do druheho projektu
            using NamedPipeClientStream stre = new NamedPipeClientStream("test");
            stre.Connect();
            int val = stre.ReadByte();
            //TOTO dame do druheho projektu

            Console.WriteLine("hello janousek");

        }
    }
}
