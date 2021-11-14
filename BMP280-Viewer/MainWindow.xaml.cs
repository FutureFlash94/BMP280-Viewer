using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
//using Windows.Devices.SerialCommunication;
//using Windows.Devices.Enumeration;
//using Windows.Storage.Streams;
using System.IO.Ports;
using System.Threading;

namespace BMP280_Viewer
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer dispatcherTimer;
        static bool _continue;
        static SerialPort _serialPort;
        public MainWindow()
        {
            InitializeComponent();

            //  DispatcherTimer setup
            dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();

            string name;
            string message;
            StringComparer stringComparer = StringComparer.OrdinalIgnoreCase;
            Thread readThread = new Thread(Read);

            // Create a new SerialPort object with default settings.
            _serialPort = new SerialPort();

            // Allow the user to set the appropriate properties.
            _serialPort.BaudRate = 11520;
            _serialPort.Parity = Parity.None;
            _serialPort.DataBits = 8;
            _serialPort.StopBits = StopBits.One;
            _serialPort.Handshake = Handshake.None;

            // Set the read/write timeouts
            _serialPort.ReadTimeout = 500;
            _serialPort.WriteTimeout = 500;

            _serialPort.Open();
            _continue = true;
            readThread.Start();

            Console.Write("Name: ");
            name = Console.ReadLine();

            Console.WriteLine("Type QUIT to exit");

            while (_continue)
            {
                message = Console.ReadLine();

                if (stringComparer.Equals("quit", message))
                {
                    _continue = false;
                }
                else
                {
                    _serialPort.WriteLine(
                        String.Format("<{0}>: {1}", name, message));
                }
            }

            readThread.Join();
            _serialPort.Close();
        }
        public double GetRandomNumber(double minimum, double maximum)
        {
            Random random = new Random();
            return random.NextDouble() * (maximum - minimum) + minimum;
        }

        //  System.Windows.Threading.DispatcherTimer.Tick handler
        //
        //  Updates the current seconds display and calls
        //  InvalidateRequerySuggested on the CommandManager to force 
        //  the Command to raise the CanExecuteChanged event.
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            // Updating chart
            // Add Temp
            bm280Chart.Series[0].Values.Add(GetRandomNumber(10, 15));
            // Add Press
            bm280Chart.Series[1].Values.Add(GetRandomNumber(11, 16));

            // Forcing the CommandManager to raise the RequerySuggested event
            CommandManager.InvalidateRequerySuggested();
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Check for UART devices
            // TODO: refresh cbUARTDeviceList
        }

        private void cbUARTDeviceList_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            // UART device selected/unselected
            // TODO: save selected device name
        }
        private void btnConnect_Click(object sender, RoutedEventArgs e)
        {
            // Used to connect / disconnect to a UART port
            if (btnConnect.Name == "Connect")
            {
                btnConnect.Name = "Disconnect";
                _serialPort.PortName = "COM1";
            } else
            {
                btnConnect.Name = "Connect";
            }
            // TODO: after conecting, start communication
        }
        public static void Read()
        {
            while (_continue)
            {
                try
                {
                    string message = _serialPort.ReadLine();
                    Console.WriteLine(message);
                }
                catch (TimeoutException) { }
            }
        }
    }
}
