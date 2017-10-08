using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SortVisuals
{
    class Program
    {
        static string filepath = "C:\\Users\\zfern\\Documents\\Sort Stuff\\Bubble\\";
        static int counter = 0;

        static void Main(string[] args)
        {
            // Create the new array of arrays and populate it with delicious integers
            int[][] square = new int[360][];
            for (int i = 0; i < 360; i++)
            {
                square[i] = new int[360];
                for (int j = 0; j < 360; j++)
                {
                    square[i][j] = j;
                }
            }

            // Make a random variable! Randomness is essential to un-sort-y-ness.
            Random rand = new Random();

            // Shuffle the numbers and mix them together!!
            for (int i = 0; i < 360; i++)
            {
                for (int j = 0; j < 360; j++)
                {
                    // Pick two random numbers in the same array and swap them.
                    Swap(square[i], rand.Next(360), rand.Next(360));
                }
            }

            // Call the sort method and let it do the rest.
            Sort(square);

        }

        static void Sort(int[][] array)
        {
            // Do the sorting stuff in here.

            // This is each passthrough of the sort
            for (int i = 0; i < 360; i++)
            {
                // This is for one passthrough
                for (int j = 0; j < 359; j++)
                {
                    // This is for each row
                    for (int k = 0; k < 359; k++)
                    {
                        // The actual bubble sort bit
                        if (array[k][j] > array[k][j + 1])
                            Swap(array[k], j, j + 1);
                    }
                }
                Screenshot(array);
            }
        }

        static void Screenshot (int[][] array)
        {
            counter++;
            StreamWriter writer = new StreamWriter(filepath + "frame " + counter + ".ppm");

            // Write the header
            writer.WriteLine("P3");
            writer.WriteLine("360 360");
            writer.WriteLine("255");
            
            // Loop through the array and write out the values for each pixel.

            for (int i = 0; i < 360; i++)
            {
                for (int j = 0; j < 360; j++)
                {
                    // write out the converted RGB string of the value at row i and column j.
                    writer.WriteLine(Convert(array[i][j]));
                }
            }

            // Don't forget to close the writer.
            writer.Close();
        }

        static string Convert (int hue)
        {
            string s;
            int mod = (hue % 60) * 255 / 60;

            if (hue < 60)
                s = "255 " + mod + " 0";
            else if (hue < 120)
                s = (255 - mod) + " 255 0";
            else if (hue < 180)
                s = "0 255 " + mod;
            else if (hue < 240)
                s = "0 " + (255 - mod) + " 255";
            else if (hue < 300)
                s = mod + " 0 255";
            else
                s = "255 0 " + (255 - mod);

            return s;
        }

        static void Swap(int[] array, int a, int b)
        {
            int temp = array[a];
            array[a] = array[b];
            array[b] = temp;
        }
    }
}
