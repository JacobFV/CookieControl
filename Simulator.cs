﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;

namespace CookieControl
{
    class Simulator
    {
        void makeSimulation(string filename)
        {
            try
            {

                // Delete the file if it exists. 
                if (File.Exists(filename))
                {
                    // Note that no lock is put on the 
                    // file and the possibility exists 
                    // that another process could do 
                    // something with it between 
                    // the calls to Exists and Delete.
                    File.Delete(filename);
                }

                // Create the file. 
                using (FileStream fs = File.Create(filename))
                {
                    Byte[] info = new UTF8Encoding(true).GetBytes("This is some text in the file.");
                    // Add some information to the file.
                    fs.Write(info, 0, info.Length);
                }

                // Open the stream and read it back. 
                using (StreamReader sr = File.OpenText(filename))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(s);
                    }
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
