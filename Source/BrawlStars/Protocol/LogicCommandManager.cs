using System;
using System.Collections.Generic;

namespace BrawlStars.Protocol
{
    public class LogicCommandManager
    {
        public static Dictionary<int, Type> Commands;

        static LogicCommandManager()
        {
            Commands = new Dictionary<int, Type>
            {

            };
        }
    }
}