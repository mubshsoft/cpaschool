using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Text;

namespace fmsf.lib
{
    public class LIBQueryDetails
    {
        public LIBQueryDetails()
        {
        }

        public string QuerySubject
        {
            get;
            set;
        }

        public string Query
        {
            get;
            set;
        }



        public string feeStauts
        {
            get;
            set;
        }

        public string Semester
        {
            get;
            set;
        }


        public string Course
        {
            get;
            set;
        }

        public string CourseStauts
        {
            get;
            set;
        }


        public int NumberofUnRepliedQueries
        {
            set;
            get;
        }


        public int NumberofQueriesPosted
        {
            set;
            get;
        }


        public int QueryId
        {
            get;
            set;
        }


        public int FID
        {
            get;
            set;
        }


        public int stid
        {
            get;
            set;
        }

        public int Status
        {
            get;
            set;
        }

        public string Reply
        {
            get;
            set;
        }


        public string QueryDate
        {
            get;
            set;
        }


        public string ReplyDate
        {
            get;
            set;
        }

        public int NumberofRepliedQueries
        {
            set;
            get;
        }

        public int bid
        {
            get;
            set;
        }

     



    }

    [Serializable]
    public class LIBQueryDetailsListing : List<LIBQueryDetails>
    {

    }


}
