using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnergyCAP
{
    /// <summary>
    /// Constains all the session constants used throughout the web application.
    /// </summary>
    public class SessionConstants
    {
        /// <summary>
        ///  Currently selected building ID.
        /// </summary>
        public static readonly string BUILDING_ID = "buildingID";

        /// <summary>
        /// Currently selected meter ID.
        /// </summary>
        public static readonly string METER_ID = "meterID";
    }
}