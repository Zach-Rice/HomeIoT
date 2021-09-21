using System.IO.Ports;
using System.Threading.Tasks;
using System.Threading;
using System;



public class ReadSerialPortService
{
    public string serialValue { get; set; }

    public ReadSerialPortService()
    {
        SerialPort t = new SerialPort("COM8", 9600);

        t.DataReceived += new SerialDataReceivedEventHandler(DataRecievedHandler);
        try
        {
            if (!t.IsOpen)
            {
                t.Open();
            }
        }
        catch(Exception)
        {
            serialValue = "0";
        }


    }
    private void DataRecievedHandler(object sender, SerialDataReceivedEventArgs e)
    {
        SerialPort sp = (SerialPort)sender;
        string data = sp.ReadLine();
        serialValue = data.ToString();
    }

    public Task<string> GetValue()
    {
        return Task.FromResult(serialValue);
    }
}

