using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using LinkLayer;

namespace TransportLayer
{
    /// <summary>
	/// Transport.
	/// </summary>
	public class Transport
    {
        /// <summary>
        /// The link.
        /// </summary>
        private Link _link;
        /// <summary>
        /// The 1' complements checksum.
        /// </summary>
        private Checksum _checksum;
        /// <summary>
        /// The buffer.
        /// </summary>
        private byte[] _buffer;
        /// <summary>
        /// The seq no.
        /// </summary>
        private byte _seqNo;
        /// <summary>
        /// The old_seq no.
        /// </summary>
        private byte _old_seqNo;
        /// <summary>
        /// The error count.
        /// </summary>
        private int _errorCount;
        /// <summary>
        /// The DEFAULT_SEQNO.
        /// </summary>
        private const int DEFAULT_SEQNO = 2;
        /// <summary>
        /// The data received. True = received data in receiveAck, False = not received data in receiveAck
        /// </summary>
        private bool _dataReceived;
        /// <summary>
        /// The number of bytes received.
        /// </summary>
        private int _bytesRead;


        /// <summary>
        /// Initializes a new instance of the <see cref="Transport"/> class.
        /// </summary>
        public Transport(int BUFSIZE, string APP)
        {
            _link = new Link(BUFSIZE + (int)TransSize.ACKSIZE, APP);
            _checksum = new Checksum();
            _buffer = new byte[BUFSIZE + (int)TransSize.ACKSIZE];
            _seqNo = 0;
            _old_seqNo = DEFAULT_SEQNO;
            _errorCount = 0;
            _dataReceived = false;
        }

        /// <summary>
        /// Receives the ack.
        /// </summary>
        /// <returns>
        /// The ack.
        /// </returns>
        private byte ReceiveAck()
        {
            byte[] buf = new byte[(int)TransSize.ACKSIZE];
            int size = _link.Receive(ref buf);
            if (size != (int) TransSize.ACKSIZE) return DEFAULT_SEQNO;
            if (!_checksum.checkChecksum(buf, (int) TransSize.ACKSIZE) || buf[(int) TransCHKSUM.SEQNO] != _seqNo ||
                buf[(int) TransCHKSUM.TYPE] != (int) TransType.ACK)
            {
                return DEFAULT_SEQNO;
            }
            return _seqNo;
        }

        /// <summary>
        /// Set _seqNo to next _seqNo to send
        /// </summary>
        private void nextSeqNo()
        {
            _seqNo = (byte) ((_seqNo + 1) % 2);
        }

        /// <summary>
        /// Sends the ack.
        /// </summary>
        /// <param name='ackType'>
        /// Ack type.
        /// </param>
        private void SendAck(bool ackType)
        {
            byte[] ackBuf = new byte[(int)TransSize.ACKSIZE];
            ackBuf[(int)TransCHKSUM.SEQNO] = (byte)
                (ackType ? (byte)_buffer[(int)TransCHKSUM.SEQNO] : (byte)(_buffer[(int)TransCHKSUM.SEQNO] + 1) % 2);
            ackBuf[(int)TransCHKSUM.TYPE] = (byte)(int)TransType.ACK;
            _checksum.calcChecksum(ref ackBuf, (int)TransSize.ACKSIZE);
            _link.Send(ackBuf, (int)TransSize.ACKSIZE);
        }

        /// <summary>
        /// Send the specified buffer and size.
        /// </summary>
        /// <param name='buffer'>
        /// Buffer.
        /// </param>
        /// <param name='size'>
        /// Size.
        /// </param>
        public void Send(byte[] buf, int size)
        {
            // TO DO Your own code
            do
            {
                // Reset the buffer
                for (int i = 0; i < _buffer.Length; i++)
                {
                    _buffer[i] = 0;
                }

                //Set type and seq
                _buffer[(int) TransCHKSUM.TYPE] = (int) TransType.DATA;
                _buffer[(int) TransCHKSUM.SEQNO] = _seqNo;
                Array.Copy(buf, 0, _buffer, 4, size);

                _checksum.calcChecksum(ref _buffer, _buffer.Length);
                byte temp = _seqNo;

                try
                {
                    //Send
                    _link.Send(_buffer, size + 4);

                    //Receive acknowledge
                    ReceiveAck();

                    //If the acks aren't identical, then the package wasnt received correctly
                    if (temp != _seqNo)
                    {
                        Console.WriteLine("Error in receiving!");
                    }
                    else
                    {
                        Console.WriteLine("Success in receiving!");
                        break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }

                _errorCount++;

            } while (_errorCount < 10); //10 Attempts

            if (_errorCount == 10)
            {
                Console.WriteLine("10 errors occured!");
                Environment.Exit(1);
            }

            //Update
            nextSeqNo();
            _errorCount = 0;           
        }

        /// <summary>
        /// Receive the specified buffer.
        /// </summary>
        /// <param name='buffer'>
        /// Buffer.
        /// </param>
        public int Receive(ref byte[] buf)
        {
            // TO DO Your own code

            // Reset the buffer
            for (int i = 0; i < _buffer.Length; i++)
            {
                _buffer[i] = 0;
            }

            while (true)
            {
                _bytesRead = 0;

                //The while loop for receiving
                while (true)
                {
                    try
                    {
                        _bytesRead = _link.Receive(ref _buffer);
                        if (_bytesRead == -1) // send NACK if -1 is received (buffer[0] != delimiter)
                            SendAck(false);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        throw;
                    }

                    //Stay in this while loop, untill we've received something
                    if (_bytesRead != 0 && _bytesRead != -1)
                        break;
                }
                
                //Check the reception
                if (_checksum.checkChecksum(_buffer, _bytesRead))
                {
                    Console.WriteLine("Data received successfully!");

                    //Update
                    _seqNo = _buffer[(int) TransCHKSUM.SEQNO];
                    Array.Copy(_buffer, (int)TransSize.ACKSIZE, buf, 0, _bytesRead - (int)TransSize.ACKSIZE);

                    //Check for identical packages
                    if (_seqNo == _old_seqNo)
                    {
                        //logic
                        Console.WriteLine("Identical reception");
                    }

                    _old_seqNo = _seqNo;
                    SendAck(true);
                    return _bytesRead - 4;
                }
                else
                {
                    Console.WriteLine("Data received failed!");
                    SendAck(false);
                }
            }
        }
    }
}
