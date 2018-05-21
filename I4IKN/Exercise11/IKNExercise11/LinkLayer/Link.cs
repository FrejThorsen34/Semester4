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
        private byte[] buffer;
        /// <summary>
        /// The serial port.
        /// </summary>
        SerialPort serialPort;

        /// <summary>
        /// Initializes a new instance of the <see cref="link"/> class.
        /// </summary>
        public Link(int BUFSIZE, string APP)
        {
            // Create a new SerialPort object with default settings.
            #if DEBUG
            if (APP.Equals("FILE_SERVER"))
            {
                serialPort = new SerialPort("/dev/ttyS1", 115200, Parity.None, 8, StopBits.One);
            }
            else
            {
                serialPort = new SerialPort("/dev/ttyS1", 115200, Parity.None, 8, StopBits.One);
            }
            #else
				serialPort = new SerialPort("/dev/ttyS1",115200,Parity.None,8,StopBits.One);
            #endif
            if (!serialPort.IsOpen)
                serialPort.Open();

            buffer = new byte[(BUFSIZE * 2)];

            // Uncomment the next line to use timeout
            //serialPort.ReadTimeout = 500;

            serialPort.DiscardInBuffer();
            serialPort.DiscardOutBuffer();
        }

        public void send(byte[] buf, int size)
        {
            // TO DO Your own code
            //padding for extra chars, min 2 for Frame start/end
            int padding = 2;

            //Adds padding foreach A and B char in the buffer
            for (int i = 0; i < size; i++)
            {
                if (buf[i] == Convert.ToByte('A') || buf[i] == Convert.ToByte('B'))
                {
                    padding++;
                }
            }

            buffer[0] = Convert.ToByte('A');
            buffer[size + padding - 1] = Convert.ToByte('A');

            //offset
            int offset = 1;

            for (int i = 0; i < size; i++)
            {
                if (buf[i] != Convert.ToByte('A') && buf[i] != Convert.ToByte('B'))
                {
                    buffer[i + offset] = buf[i];
                }
                else if (buf[i] == Convert.ToByte('A'))
                {
                    buffer[i + offset] = Convert.ToByte('B');
                    buffer[i + offset + 1] = Convert.ToByte('C');
                    offset++;
                }
                else if (buf[i] == Convert.ToByte('B'))
                {
                    buffer[i + offset] = Convert.ToByte('B');
                    buffer[i + offset + 1] = Convert.ToByte('D');
                    offset++;
                }
                else
                {
                    throw new Exception("Error in converting send message in Link-layer");
                }

                serialPort.Write(buffer, 0, size + padding);

            }

        }

        public int receive(ref byte[] buf)
        {
            // TO DO Your own code
            int bytesRead = 0;
            byte readByte = 0;

            while (readByte != Convert.ToByte('A'))
            {
                readByte = Convert.ToByte(serialPort.ReadByte());
            }

            do
            {
                readByte = Convert.ToByte(serialPort.ReadByte());
                buffer[bytesRead] = readByte;
                bytesRead++;


            } while (readByte != Convert.ToByte('A'));

            int offset = 0;

            for (int i = 0; i < bytesRead - 1; i++)
            {
                if (buffer[i + offset] != Convert.ToByte('B') && buffer[i + offset + 1] != Convert.ToByte('C') ||
                    buffer[i + offset + 1] == Convert.ToByte('D'))
                {
                    buf[i] = buffer[i + offset];
                }
                else if (buffer[i + offset] == Convert.ToByte('B') && buffer[i + offset + 1] == Convert.ToByte('C'))
                {
                    buf[i] = Convert.ToByte('A');
                    offset++;
                }
                else if (buffer[i + offset] == Convert.ToByte('B') && buffer[i + offset + 1] == Convert.ToByte('D'))
                {
                    buf[i] = Convert.ToByte('B');
                    offset++;
                }
                else
                {
                    throw new Exception("Error in converting received message in Link-layer");
                }
            }

            return bytesRead - offset - 1;
        }
    }
}
