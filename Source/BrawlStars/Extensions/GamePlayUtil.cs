using System;
using BrawlStars.Files;
using BrawlStars.Files.Logic;

namespace BrawlStars.Extensions
{
    public class GamePlayUtil
    {
        public int GetResourceDiamondCost(int resourceCount, string resource)
        {
            int result = 0;
 
                var globals = Csv.Tables.Get(Csv.Files.Globals);

                if (resourceCount >= 1)
                {
                    if (resourceCount >= 100)
                    {
                        if (resourceCount >= 1000)
                        {
                            if (resourceCount >= 10000)
                            {
                                if (resourceCount >= 100000)
                                {
                                    if (resourceCount >= 1000000)
                                    {
                                        var supCost = globals.GetData<Global>("RESOURCE_DIAMOND_COST_10000000")
                                            .NumberValue;
                                        var infCost = globals.GetData<Global>("RESOURCE_DIAMOND_COST_1000000")
                                            .NumberValue;
                                        result = CalculateResourceCost(10000000, 1000000, supCost, infCost,
                                            resourceCount);
                                    }
                                    else
                                    {
                                        var supCost = globals.GetData<Global>("RESOURCE_DIAMOND_COST_1000000")
                                            .NumberValue;
                                        var infCost = globals.GetData<Global>("RESOURCE_DIAMOND_COST_100000")
                                            .NumberValue;
                                        result = CalculateResourceCost(1000000, 100000, supCost, infCost,
                                            resourceCount);
                                    }
                                }
                                else
                                {
                                    var supCost = globals.GetData<Global>("RESOURCE_DIAMOND_COST_100000").NumberValue;
                                    var infCost = globals.GetData<Global>("RESOURCE_DIAMOND_COST_10000").NumberValue;
                                    result = CalculateResourceCost(100000, 10000, supCost, infCost, resourceCount);
                                }
                            }
                            else
                            {
                                var supCost = globals.GetData<Global>("RESOURCE_DIAMOND_COST_10000").NumberValue;
                                var infCost = globals.GetData<Global>("RESOURCE_DIAMOND_COST_1000").NumberValue;
                                result = CalculateResourceCost(10000, 1000, supCost, infCost, resourceCount);
                            }
                        }
                        else
                        {
                            var supCost = globals.GetData<Global>("RESOURCE_DIAMOND_COST_1000").NumberValue;
                            var infCost = globals.GetData<Global>("RESOURCE_DIAMOND_COST_100").NumberValue;
                            result = CalculateResourceCost(1000, 100, supCost, infCost, resourceCount);
                        }
                    }
                    else
                    {
                        result = globals.GetData<Global>("RESOURCE_DIAMOND_COST_100")
                            .NumberValue;
                    }
                }

            return result;
        }

        public static int GetSpeedUpCost(int seconds)
        {
            var globals = Csv.Tables.Get(Csv.Files.Globals);
            var cost = 0;
            if (seconds >= 1)
            {
                if (seconds >= 60)
                {
                    if (seconds >= 3600)
                    {
                        if (seconds >= 86400)
                        {
                            var supCost = globals.GetData<Global>("SPEED_UP_DIAMOND_COST_1_WEEK").NumberValue;
                            var infCost = globals.GetData<Global>("SPEED_UP_DIAMOND_COST_24_HOURS").NumberValue;
                            cost = CalculateSpeedUpCost(604800, 86400, supCost, infCost, seconds);
                        }
                        else
                        {
                            var supCost = globals.GetData<Global>("SPEED_UP_DIAMOND_COST_24_HOURS").NumberValue;
                            var infCost = globals.GetData<Global>("SPEED_UP_DIAMOND_COST_1_HOUR").NumberValue;
                            cost = CalculateSpeedUpCost(86400, 3600, supCost, infCost, seconds);
                        }
                    }
                    else
                    {
                        var supCost = globals.GetData<Global>("SPEED_UP_DIAMOND_COST_1_HOUR")
                            .NumberValue;
                        var infCost = globals.GetData<Global>("SPEED_UP_DIAMOND_COST_1_MIN")
                            .NumberValue;
                        cost = CalculateSpeedUpCost(3600, 60, supCost, infCost, seconds);
                    }
                }
                else
                {
                    cost = globals.GetData<Global>("SPEED_UP_DIAMOND_COST_1_MIN")
                        .NumberValue;
                }
            }

            return cost;
        }

        public static int CalculateResourceCost(int sup, int inf, int supCost, int infCost, int amount)
        {
            return (int) Math.Round((supCost - infCost) * (long) (amount - inf) / (sup - inf * 1.0)) + infCost;
        }

        public static int CalculateSpeedUpCost(int sup, int inf, int supCost, int infCost, int amount)
        {
            return (int) Math.Round((supCost - infCost) * (long) (amount - inf) / (sup - inf * 1.0)) + infCost;
        }
    }
}