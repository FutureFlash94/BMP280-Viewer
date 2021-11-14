using System;
using System.Windows;
using System.IO.Ports;
using System.Threading;
using System.Globalization;

namespace BMP280_Viewer
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static bool _continue;
        static SerialPort _serialPort = new SerialPort();
        Thread readThread;
        public MainWindow()
        {
            InitializeComponent();
            
            // Allow the user to set the appropriate properties.
            _serialPort.BaudRate = 11520;
            _serialPort.Parity = Parity.None;
            _serialPort.DataBits = 8;
            _serialPort.StopBits = StopBits.One;
            _serialPort.Handshake = Handshake.None;

            RefreshComDevices();
        }

        private void AddValuesToChart(double pressure, double temperature)
        {
            LiveCharts.SeriesCollection series = bm280Chart.Series;
            series[0].Values.Add(pressure);
            series[1].Values.Add(temperature);
        }
        
        private void RefreshComDevices()
        {
            // get a list of serial port names.
            string[] ports = SerialPort.GetPortNames();

            // refresh cbUARTDeviceList
            cbUARTDeviceList.Items.Clear();

            if (ports.Length > 0)
            {
                // Display each port name to the console.
                foreach (string port in ports)
                {
                    cbUARTDeviceList.Items.Add(port);
                }
                cbUARTDeviceList.SelectedItem = ports[0];
            }

        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            RefreshComDevices();
        }

        private void btnConnect_Click(object sender, RoutedEventArgs e)
        {
            string selectedPort = (string)cbUARTDeviceList.SelectedItem;
            if (selectedPort == null)
            {
                MessageBox.Show("No Port selected!");
                return;
            }
            
            if (btnConnect.Content.Equals("Connect"))
            {
                _serialPort.PortName = selectedPort;
                try
                {
                    _serialPort.Open();

                    btnConnect.Content = "Disconnect";
                    btnRefresh.IsEnabled = false;
                    cbUARTDeviceList.IsEnabled = false;

                    _continue = true;
                    readThread = new Thread(Read);
                    readThread.Start();
                }
                catch (UnauthorizedAccessException)
                {
                    MessageBox.Show("Cannot connect to " + selectedPort + "! UnauthorizedAccessException occured");
                }
            } else
            {
                _continue = false;
                _serialPort.Close();
                btnConnect.Content = "Connect";
                btnRefresh.IsEnabled = true;
                cbUARTDeviceList.IsEnabled = true;
            }
        }
        private void Read()
        {
            while (_continue)
            {
                try
                {
                    string message = _serialPort.ReadLine();
                    Console.WriteLine(message);

                    // get pressure and temperature from uart message and add it to the chart
                    if (message.Contains("P:") && message.Contains("T:"))
                    {
                        var startIndexP = message.IndexOf("P:", 0) + 2;
                        var startIndexSeparator = message.IndexOf("-", 0);
                        var startIndexT = message.IndexOf("T:", 0) + 2;

                        var stringP = message.Substring(startIndexP, startIndexSeparator - startIndexP);
                        var stringT = message.Substring(startIndexT, message.Length - startIndexT);

                        stringT = stringT.Replace(" ", "0");

                        Console.WriteLine("P: " + stringP);
                        Console.WriteLine("T: " + stringT);

                        try
                        {
                            AddValuesToChart(double.Parse(stringP, CultureInfo.InvariantCulture), double.Parse(stringT, CultureInfo.InvariantCulture));
                        }
                        catch(FormatException ex)
                        {
                            Console.WriteLine("FormatException in Read thread: " + ex.Message);
                        }
                    }
                }
                catch (Exception) { }
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _continue = false;
            _serialPort.Close();
            readThread.Abort();
        }
    }
}
