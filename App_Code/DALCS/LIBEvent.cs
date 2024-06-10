using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace fmsf.lib
{

    /// <summary>
    /// Summary description for LIBEvent
    /// </summary>
    [Serializable]
    public class LIBEvent
    {
        public int eventID
        {
            get;
            set;
        }
        public string title
        {
            get;
            set;
        }
        public string description
        {
            get;
            set;
        }
        public string ThemeColor
        {
            get;
            set;
        }
        public Boolean IsFullDay
        {
            get;
            set;
        }

        public DateTime start_date
        {
            get;
            set;
        }

        public DateTime end_date
        {
            get;
            set;
        }

        public Boolean Check
        {
            get;
            set;
        }

        public string CourseID
        {
            get;
            set;
        }
    }
    [Serializable]
    public class LIBEventListing : List<LIBEvent>
    {

    }
}