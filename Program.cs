using System;

namespace ThreadHomework
{
    class Program
    {
        static int[] elements;

        static string FilePath = @"C:\Users\Noutbuk Savdosi\Desktop\G3_Ibroximov_Sardorbek_3_Modul\element111.txt"; // Fayl nomi

        static void WriteToFile()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(FilePath))
                {
                    foreach (var element in elements)
                    {
                        writer.WriteLine(element);
                    }

                }
                Console.WriteLine("Filega Muvafaqqiyatli Nusxa kochirildi!!!");
            }
            catch (Exception ex)
            {

                Console.WriteLine("Xatolik yuz beri !!! " + ex.Message);
            }
        }

        static void ReadToFile()
        {
            try
            {
                using (StreamReader streamReader = new StreamReader(FilePath))
                {
                    string line;
                    Console.WriteLine("Fayldagi Elementlar: ");
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine("Xatollik yuz berdi !!!" + ex.Message);
            }
        }
        static void Main(string[] args)
        {
            elements = new[] { 1, 2, 11, 22, 33, 44, 55, 66, 77, 88, 99, 111 };
            Thread writeThread = new Thread(WriteToFile);
            writeThread.Start();
            writeThread.Join();

            Thread readThread = new Thread(ReadToFile);
            readThread.Start();
            Console.ReadKey();

        }
    }
}
