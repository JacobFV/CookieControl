using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Ports;
using System.Windows.Forms;

namespace CookieControl
{
    class serial
    {
        SerialPort serialPort = new SerialPort();
        string serialIn = "";
        public bool newVal = false;
        int numRecieves = 0;
        public bool loadSerial(string portName)
        {
            serialPort.BaudRate = 9600;
            serialPort.Parity = Parity.None;
            serialPort.StopBits = StopBits.One;
            serialPort.DataBits = 8;
            serialPort.Handshake = Handshake.None;

            serialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
            /*
            const int maxPorts = 64;
            for (int portNum = 0; portNum <= maxPorts; portNum++)
            {
                try
                {
                    serialPort.PortName = "COM" + portNum;
                    serialPort.Open();
                    portNum = 63;
                }
                catch
                {
                    if(portNum==maxPorts)
                    {
                        MessageBox.Show("No Cookie Cutter Found");
                    }
                }
            }*/
            serialPort.PortName = portName;
            try
            {
                serialPort.Open();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void write(string text)
        {
            serialPort.Write(text);
        }

        public void log(
            double startX,
            double startY,
            double endX,
            double endY)
        {
            writeNumberArray("c", new double[10]{
                startX,startY,
                endX,endY,
                1,0,0,1,0,0
            });
        }
        public void log(
            double startX,
            double startY,
            double endX,
            double endY,
            double a,
            double b,
            double c,
            double d,
            double e,
            double f,
            double ang1,
            double ang2)
        {
            writeNumberArray("c", new double[12]{
                startX,startY,
                endX,endY,
                a,b,c,d,e,f,
                ang1,ang2
            });
        }
        public void log(
            double startX,
            double startY,
            double endX,
            double endY,
            double a,
            double b,
            double c,
            double d,
            double e,
            double f,
            double hx1,
            double hy1,
            double hx2,
            double hy2)
        {
            writeNumberArray("c", new double[14]{
                startX,startY,
                endX,endY,
                a,b,c,d,e,f,
                hx1,hy1,
                hx2,hy2
            });
        }

        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort serialInPort = (SerialPort)sender;
            serialIn = serialInPort.ReadExisting();
            Console.Write(serialIn);
            if (serialIn.Contains(':'))
            {
                newVal = true;
                numRecieves++;
            }
        }
        private void writeNumberArray(string prefix, double[] values)
        {
            string finalString = prefix;
            foreach (double val in values)
            {
                finalString += " " + val.ToString();
            }
            serialPort.Write(finalString);
        }
        public void closeSerial()
        {
            serialPort.Close();
        }
    }
}
