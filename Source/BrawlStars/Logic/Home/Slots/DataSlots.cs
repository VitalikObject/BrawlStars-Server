using System.Collections.Generic;
using BrawlStars.Logic.Home.Slots.Items;
using DotNetty.Buffers;

namespace BrawlStars.Logic.Home.Slots
{
    public class DataSlots : List<DataSlot>
    {
        /// <summary>
        ///     Add a new dataslot or replace it
        /// </summary>
        /// <param name="id"></param>
        /// <param name="count"></param>
        public void Set(int id, int count)
        {
            var index = FindIndex(x => x.Id == id);
            if (index > -1)
            {
                var dataslot = this[index];
                dataslot.Count = count;
            }
            else
            {
                Add(new DataSlot
                {
                    Id = id,
                    Count = count
                });
            }
        }

        /// <summary>
        ///     Add or create a new dataslot
        /// </summary>
        /// <param name="id"></param>
        /// <param name="count"></param>
        public void Add(int id, int count)
        {
            var index = FindIndex(x => x.Id == id);
            if (index > -1)
            {
                var dataslot = this[index];
                dataslot.Count += count;
            }
            else
            {
                Add(new DataSlot
                {
                    Id = id,
                    Count = count
                });
            }
        }

        /// <summary>
        ///     Remove from a dataslot
        /// </summary>
        /// <param name="id"></param>
        /// <param name="count"></param>
        public void Remove(int id, int count)
        {
            var index = FindIndex(x => x.Id == id);
            if (index > -1)
            {
                var dataslot = this[index];
                dataslot.Count -= count;
            }
        }

        /// <summary>
        ///     Get the count of a dataslot by it's id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int GetCount(int id)
        {
            var index = FindIndex(x => x.Id == id);
            return index > -1 ? this[index].Count : 0;
        }

        /// <summary>
        ///     Get a dataslot by it's id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataSlot GetById(int id)
        {
            var index = FindIndex(x => x.Id == id);
            return index > -1 ? this[index] : null;
        }

        /// <summary>
        ///     Encodes all dataslots
        /// </summary>
        /// <param name="buffer"></param>
        public void Encode(IByteBuffer buffer)
        {
            buffer.WriteInt(Count);
            ForEach(x => x.Encode(buffer));
        }
    }
}