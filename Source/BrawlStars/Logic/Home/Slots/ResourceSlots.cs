namespace BrawlStars.Logic.Home.Slots
{
    public class ResourceSlots : DataSlots
    {
        /// <summary>
        ///     Sets the default resources to this dataslots
        /// </summary>
        public void InitializeDefault()
        {
            Set(5000001, 100); // Gold
            Set(5000002, 0); // owcAny
            Set(5000003, 0); // DarkElixir

            Set(5000007, 1000); // Dust
            Set(5000008, 1000); // Upgradium
        }

        /// <summary>
        ///     Sets the max resources to this dataslots
        /// </summary>
        public void Initialize()
        {
            Set(5000001, 1000000000);
            Set(5000002, 1000000000);
            Set(5000003, 10000000);

            Set(5000007, 1000000000);
            Set(5000008, 1000000000);
        }
    }
}