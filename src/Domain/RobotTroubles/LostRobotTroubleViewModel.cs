namespace RodriBus.MartianRobots.Domain.RobotTroubles
{
    /// <summary>
    /// Represents a lost robot trouble.
    /// </summary>
    public struct LostRobotTroubleViewModel : IRobotTrouble
    {
        private const string TroubleCode = "LOST";

        /// <summary>
        /// Gets the trouble code.
        /// </summary>
        public string GetTroubleCode() => TroubleCode;
    }
}