using System;
using System.IO;
using System.Linq;
using System.Text;

namespace Lab4_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string first, second;
            int a, b;
            int multiplication;
            int sum = 0;
            int good_data = 0;

            for (int i = 10; i < 30; i++)
            {
                string path = @"C:\Users\Maxim\Desktop\Lab 4 files\txtfiles\" + i + ".txt";
                try
                {
                    StreamReader streamreader = new StreamReader(path);
                    first = streamreader.ReadLine();
                    a = Convert.ToInt32(first);
                    Console.WriteLine($"First : {first} ,{a} ");
                    second = streamreader.ReadLine();
                    b = Convert.ToInt32(second);
                    Console.WriteLine($"Second : {second} ,{b} ");

                    checked
                    {
                        multiplication = a * b;
                    }

                    Console.WriteLine($"The numbers in file the file {i}.txt:{first}{second}");
                    Console.WriteLine($"The Multiplication of these two numbers: {multiplication}");
                    Console.WriteLine();

                    sum += multiplication;
                    good_data++;
                    streamreader.Dispose();

                }
                catch (System.IO.FileNotFoundException)
                {
                    using (StreamWriter no_file = new StreamWriter(@"C:\Users\Maxim\Desktop\Lab 4 files\txtwritefiles\no_file.txt", false, System.Text.Encoding.Default))
                    {
                        no_file.WriteLine(i + ".txt");
                    }
                }
                catch (System.FormatException)
                {
                    using (StreamWriter bad_data = new StreamWriter(@"C:\Users\Maxim\Desktop\Lab 4 files\txtwritefiles\bad_data.txt", false, System.Text.Encoding.Default))
                    {
                        bad_data.WriteLine(i + ".txt");
                    }
                }
                catch (System.OverflowException)
                {

                    using (StreamWriter overflow = new StreamWriter(@"C:\Users\Maxim\Desktop\Lab 4 files\txtwritefiles\overflow.txt", false, System.Text.Encoding.Default))
                    {
                        overflow.WriteLine(i + ".txt");
                    }
                }

            }
            Console.WriteLine("The arithmetic mean equals: {0}", sum / (double)good_data);
            Console.ReadKey();
        }

    }
}
