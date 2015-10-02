using System;
using System.IO;
using System.Linq;

namespace CommonLibrary.StreamHelp
{
    public static class StreamExtensions
    {
        /// <summary>
        /// Reads data into a complete array, throwing an EndOfStreamException
        /// if the stream runs out of data first, or if an IOException
        /// naturally occurs.
        /// </summary>
        /// <param name="stream">The stream to read data from</param>
        /// <param name="data">The array to read bytes into. The array
        /// will be completely filled from the stream, so an appropriate
        /// size must be given.</param>
        public static void ReadWholeArray(this Stream stream, byte[] data)
        {
            int offset = 0;
            int remaining = data.Length;
            while (remaining > 0)
            {
                int read = stream.Read(data, offset, remaining);
                if (read <= 0)
                    throw new EndOfStreamException
                        (String.Format("End of stream reached with {0} bytes left to read", remaining));
                remaining -= read;
                offset += read;
            }
        }

        /// <summary>
        /// Reads data from a stream until the end is reached. The
        /// data is returned as a byte array. An IOException is
        /// thrown if any of the underlying IO calls fail.
        /// </summary>
        /// <param name="stream">The stream to read data from</param>
        public static byte[] ReadFully(this Stream stream)
        {
            byte[] buffer = new byte[32768];
            using (MemoryStream ms = new MemoryStream())
            {
                while (true)
                {
                    int read = stream.Read(buffer, 0, buffer.Length);
                    if (read <= 0)
                        return ms.ToArray();
                    ms.Write(buffer, 0, read);
                }
            }
        }

        public static byte[] StreamToByteArray(this Stream stream)
        {
            if (stream is MemoryStream)
            {
                return ((MemoryStream)stream).ToArray();
            }
            else
            {
                // Jon Skeet's accepted answer 
                return ReadFully(stream);
            }
        }


        /// <summary>
        /// Reads data from a stream until the end is reached. The
        /// data is returned as a byte array. An IOException is
        /// thrown if any of the underlying IO calls fail.
        /// </summary>
        /// <param name="stream">The stream to read data from</param>
        /// <param name="initialLength">The initial buffer length</param>
        //public static byte[] ReadFully(this Stream stream, int initialLength)
        //{
        //    // If we've been passed an unhelpful initial length, just
        //    // use 32K.
        //    if (initialLength < 1)
        //    {
        //        initialLength = 32768;
        //    }

        //    byte[] buffer = new byte[initialLength];
        //    long read = 0;

        //    int chunk;
        //    while ((chunk = stream.Read(buffer, read, buffer.Length - read)) > 0)
        //    {
        //        read += chunk;

        //        // If we've reached the end of our buffer, check to see if there's
        //        // any more information
        //        if (read == buffer.Length)
        //        {
        //            int nextByte = stream.ReadByte();

        //            // End of stream? If so, we're done
        //            if (nextByte == -1)
        //            {
        //                return buffer;
        //            }

        //            // Nope. Resize the buffer, put in the byte we've just
        //            // read, and continue
        //            byte[] newBuffer = new byte[buffer.Length * 2];
        //            Array.Copy(buffer, newBuffer, buffer.Length);
        //            newBuffer[read] = (byte)nextByte;
        //            buffer = newBuffer;
        //            read++;
        //        }
        //    }
        //    // Buffer is now too big. Shrink it.
        //    byte[] ret = new byte[read];
        //    Array.Copy(buffer, ret, read);
        //    return ret;
        //}


    }
}
