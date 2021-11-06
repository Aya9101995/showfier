using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MWCore.Areas.MWCore.Models.Modules.Enums
{
    public enum TripStatus
    {
        Pending = 1 ,
        Assigned = 2 ,
        Confirmed = 3,
        DriverOnTheWay = 4,
        Arrived = 5 ,
        OnGoing = 6,
        DroppedOff = 7,
        Completed = 8

    }
}