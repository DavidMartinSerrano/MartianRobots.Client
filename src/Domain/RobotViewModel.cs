using RodriBus.MartianRobots.Domain.RobotTroubles;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace RodriBus.MartianRobots.Domain
{
    /// <summary>
    /// Planetary robot.
    /// </summary>
    [DebuggerDisplay("{Coordinates.DebuggerDisplay,nq} - {Orientation,nq}")]
    public class RobotViewModel
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public RobotViewModel()
        {
            Troubles = new List<IRobotTrouble>();

        }
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Current coordinates.
        /// </summary>
        public CoordinatesViewModel Coordinates { get; set; }

        /// <summary>
        /// Current orientation.
        /// </summary>
        public Orientation Orientation { get; set; }

        /// <summary>
        /// Reported troubles.
        /// </summary>
        public IList<IRobotTrouble> Troubles { get; set; }

        /// <summary>
        /// Creates an instance.
        /// </summary>
        public RobotViewModel(CoordinatesViewModel coordinates, Orientation orientation)
        {
            Coordinates = coordinates;
            Orientation = orientation;
            Troubles = new List<IRobotTrouble>();
        }
    }
}