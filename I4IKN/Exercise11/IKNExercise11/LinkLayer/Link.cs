using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkLayer
{
    public class Link
    {
        /// <summary>
        /// The DELIMITE for slip protocol.
        /// </summary>
        const byte DELIMITER = (byte)'A';
        /// <summary>
        /// The buffer for link.
        /// </summary>
        private byte[] _buffer;
        /// <summary>
        /// The serial port.
        /// </summary>
        private SerialPort _serialPort;

        /// <summary>
        /// Initializes a new instance of the <see cref="link"/> class.
        /// </summary>
        public Link(int BUFSIZE, string APP)
        {
            // Create a new SerialPort object with default settings.
            #if DEBUG
            if (APP.Equals("FILE_SERVER"))
            {
                _serialPort = new SerialPort("/dev/ttySn0", 115200, Parity.None, 8, StopBits.One);
            }
            else
            {
                _serialPort = new SerialPort("/dev/ttySn1", 115200, Parity.None, 8, StopBits.One);
            }
            #else
				serialPort = new SerialPort("/dev/ttyS1",115200,Parity.None,8,StopBits.One);
            #endif
            if (!_serialPort.IsOpen)
                _serialPort.Open();

            _buffer = new byte[(BUFSIZE * 2)];

            // Uncomment the next line to use timeout
            //serialPort.ReadTimeout = 500;

            _serialPort.DiscardInBuffer();
            _serialPort.DiscardOutBuffer();
        }

        /// <summary>
        /// Send the specified buf and size.
        /// </summary>
        /// <param name='buf'>
        /// Buffer.
        /// </param>
        /// <param name='size'>
        /// Size.
        /// </param>
        public void Send(byte[] buf, int size)
        {
            // TO DO Your own code
            // Data to write list initializer
            var sendList = new List<byte> {DELIMITER};

            // For each byte, add BC if A and BD if B.
            for (int i = 0; i < size; i++)
            {
                switch (buf[i])
                {
                    case (byte)'A':
                        sendList.Add((byte)'B');
                        sendList.Add((byte)'C');
                        break;
                    case (byte)'B':
                        sendList.Add((byte)'B');
                        sendList.Add((byte)'D');
                        break;
                    default:
                        sendList.Add(buf[i]);
                        break;
                }
            }
            // Add the delimiter to the end, and write to serialport
            sendList.Add(DELIMITER);
            _serialPort.Write(sendList.ToArray(), 0, sendList.Count);
        }

        public int Receive(ref byte[] buf)
        {
            // TO DO Your own code
            int read = _serialPort.Read(_buffer, 0, _buffer.Length);
            int index = 0;

            //Check for delimiter
            if (_buffer[0] != DELIMITER)
                return -1;

            //Check for Delimiter, B (and in that case check for BC or BD), and handle default.
            for (int i = 1; i < read; i++)
            {
                switch (_buffer[i])
                {
                    // If B, check for BC or BD
                    case (byte)'B':
                        if (_buffer[i + 1] == 'C')
                        {
                            buf[index++] = (byte) 'A';
                            //Iterate one forward as the next one is a C
                            i++;
                            break;
                        }
                        else
                        {
                            buf[index++] = (byte) 'B';
                            //Iterate one forward as the next one is a D
                            i++;
                            break;
                        }
                    case DELIMITER:
                        break;
                    default:
                        buf[index++] = _buffer[i];
                        break;
                }
            }

            return index;
        }
    }
}
