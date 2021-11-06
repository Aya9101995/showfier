using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MWCore.Areas.MWCore.Models.Modules.Enums
{
    public enum enumOrdersStatus
    {
        Pending = 1,
        Processing = 2,
        Picked_Up = 3,
        On_The_Way = 4,
        Completed = 5,
        Cancelled = 6
    }
}