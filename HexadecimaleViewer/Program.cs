using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

public class HexadecimalViewer
{
    public static void Main(string[] args)
    {
        const int SIZE_BUFFER = 16;
        Console.Write("Introduceti numele file-ului sau directia catre acesta : ");
        string fileName = Console.ReadLine(); ;

        using (FileStream file = File.OpenRead(fileName))
        {
            byte[] data = new byte[SIZE_BUFFER];

            int amount;
            int c = 0;
            string line = string.Empty;

            do
            {
                Console.Write(ToHex(file.Position, 8));
                Console.Write("  ");

                amount = file.Read(data, 0, SIZE_BUFFER);

                for (int i = 0; i < amount; i++)
                {
                    Console.Write(ToHex(data[i], 2) + " ");

                    if (data[i] < 32)
                    {
                        line += ".";
                    }
                    else
                    {
                        line += (char)data[i];
                    }
                }


                if (amount < SIZE_BUFFER)
                {
                    for (int i = amount; i < SIZE_BUFFER; i++)
                    {
                        Console.Write("   ");
                    }
                }

                Console.WriteLine(line);
                line = "";

                c++;
                if (c == 24)
                {
                    Console.ReadLine();
                    c = 0;
                }
            }
            while (amount == SIZE_BUFFER);
        }
    }

    public static string ToHex(long n, int digits)
    {
        string hex = Convert.ToString(n, 16);
        while (hex.Length < digits)
        {
            hex = "0" + hex;
        }
        return hex;
    }
}