using BrawlStars.Files.CsvHelpers;
using DotNetty.Buffers;

namespace BrawlStars.Extensions
{
    /// <summary>
    ///     This implements a few extensions for games from supercell
    /// </summary>
    public static class CustomWriter
    {
        /// <summary>
        ///     Encodes CsvData
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="value"></param>
        public static void WriteData(this IByteBuffer buffer, Data value)
        {
            buffer.WriteInt(value.GetDataType());
            buffer.WriteInt(value.GetInstanceId());
        }
    }
}