using RodriBus.MartianRobots.Application.Abstractions.Maps;
using RodriBus.MartianRobots.Domain;

namespace RodriBus.MartianRobots.Application.Maps.Landmarks
{
    /// <summary>
    /// A landmark representing last traces of a lost robot.
    /// </summary>
    public record LostLandmark : Landmark
    {
        /// <summary>
        /// Coordinates to where the lost robot was headed.
        /// </summary>
        public CoordinatesViewModel LostRecordedCoords { get; }

        /// <summary>
        /// Creates an instance.
        /// </summary>
        public LostLandmark(CoordinatesViewModel lostRecordedCoords)
        {
            LostRecordedCoords = lostRecordedCoords;
        }
    }
}