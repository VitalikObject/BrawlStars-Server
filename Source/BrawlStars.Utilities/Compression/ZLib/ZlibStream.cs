using System;
using System.IO;

namespace BrawlStars.Utilities.Compression.ZLib
{
    public class ZlibStream : Stream
    {
        internal ZlibBaseStream BaseStream;
        private bool _disposed;

        public ZlibStream(Stream stream, CompressionMode mode)
            : this(stream, mode, CompressionLevel.Default, false)
        {
        }

        public ZlibStream(Stream stream, CompressionMode mode, CompressionLevel level)
            : this(stream, mode, level, false)
        {
        }

        public ZlibStream(Stream stream, CompressionMode mode, bool leaveOpen)
            : this(stream, mode, CompressionLevel.Default, leaveOpen)
        {
        }

        public ZlibStream(Stream stream, CompressionMode mode, CompressionLevel level, bool leaveOpen)
        {
            BaseStream = new ZlibBaseStream(stream, mode, level, ZlibStreamFlavor.Zlib, leaveOpen);
        }

        public int BufferSize
        {
            get => BaseStream.BufferSize;
            set
            {
                if (_disposed)
                    throw new ObjectDisposedException("ZlibStream");
                if (BaseStream._workingBuffer != null)
                    throw new ZlibException("The working buffer is already set.");
                if (value < ZlibConstants.WorkingBufferSizeMin)
                    throw new ZlibException(
                        $"Don't be silly. {value} bytes?? Use a bigger buffer, at least {ZlibConstants.WorkingBufferSizeMin}.");

                BaseStream.BufferSize = value;
            }
        }

        public override bool CanRead
        {
            get
            {
                if (_disposed)
                    throw new ObjectDisposedException("ZlibStream");

                return BaseStream.Stream.CanRead;
            }
        }

        public override bool CanSeek => false;

        public override bool CanWrite
        {
            get
            {
                if (_disposed)
                    throw new ObjectDisposedException("ZlibStream");

                return BaseStream.Stream.CanWrite;
            }
        }

        public virtual FlushType FlushMode
        {
            get => BaseStream.FlushMode;
            set
            {
                if (_disposed)
                    throw new ObjectDisposedException("ZlibStream");

                BaseStream.FlushMode = value;
            }
        }

        public override long Length => throw new NotSupportedException();

        public override long Position
        {
            get
            {
                switch (BaseStream._streamMode)
                {
                    case ZlibBaseStream.StreamMode.Writer:
                        return BaseStream.Z.TotalBytesOut;
                    case ZlibBaseStream.StreamMode.Reader:
                        return BaseStream.Z.TotalBytesIn;
                    default:
                        return 0;
                }
            }

            set => throw new NotSupportedException();
        }

        public virtual long TotalIn => BaseStream.Z.TotalBytesIn;

        public virtual long TotalOut => BaseStream.Z.TotalBytesOut;

        protected override void Dispose(bool disposing)
        {
            try
            {
                if (_disposed) return;

                if (disposing)
                    BaseStream?.Close();
                _disposed = true;
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        public static byte[] CompressBuffer(byte[] b, CompressionLevel compressionLevel)
        {
            using (var ms = new MemoryStream())
            {
                Stream compressor =
                    new ZlibStream(ms, CompressionMode.Compress, compressionLevel);

                ZlibBaseStream.CompressBuffer(b, compressor);
                return ms.ToArray();
            }
        }

        public static byte[] CompressString(string s, CompressionLevel compressionLevel)
        {
            using (var ms = new MemoryStream())
            {
                Stream compressor =
                    new ZlibStream(ms, CompressionMode.Compress, compressionLevel);
                ZlibBaseStream.CompressString(s, compressor);
                return ms.ToArray();
            }
        }

        public static byte[] UncompressBuffer(byte[] compressed)
        {
            using (var input = new MemoryStream(compressed))
            {
                Stream decompressor =
                    new ZlibStream(input, CompressionMode.Decompress);

                return ZlibBaseStream.UncompressBuffer(decompressor);
            }
        }

        public static string UncompressString(byte[] compressed)
        {
            using (var input = new MemoryStream(compressed))
            {
                Stream decompressor =
                    new ZlibStream(input, CompressionMode.Decompress);

                return ZlibBaseStream.UncompressString(decompressor);
            }
        }

        public override void Flush()
        {
            if (_disposed)
                throw new ObjectDisposedException("ZlibStream");

            BaseStream.Flush();
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            if (_disposed)
                throw new ObjectDisposedException("ZlibStream");

            return BaseStream.Read(buffer, offset, count);
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            throw new NotSupportedException();
        }

        public override void SetLength(long value)
        {
            throw new NotSupportedException();
        }


        public override void Write(byte[] buffer, int offset, int count)
        {
            if (_disposed)
                throw new ObjectDisposedException("ZlibStream");

            BaseStream.Write(buffer, offset, count);
        }
    }
}