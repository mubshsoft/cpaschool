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
    public class LIBFacultyDetails
    {
        public LIBFacultyDetails()
        {
        }

        public int Fid
        {
            get;
            set;
        }


        public int FacultyLogId
        {
            get;
            set;
        }


        public int CourseId
        {
            get;
            set;
        }


        public int PaperId
        {
            get;
            set;
        }

        public int SemId
        {
            get;
            set;
        }





        public int ModuleID
        {
            get;
            set;
        }

        
        public string firstName
        {
            get;
            set;
        }

       

        public string FacultyName
        {
            get;
            set;
        }

        public string loginfrom 
        {
            get;
            set;
        }


        public DateTime fromDate
        {
            set;
            get;
        }


        public DateTime toDate
        {
            set;
            get;
        }

        public DateTime logInDate
        {
            get;
            set;
        }

        public DateTime logOutDate
        {
            get;
            set;
        }


        public string CourseTitle
        {
            get;
            set;
        }

        public string PaperTitle
        {
            get;
            set;
        }


        public string SemesterTitle
        {
            get;
            set;
        }


        public string ModuleTitle
        {
            get;
            set;
        }

        public string LastName
        {
            get;
            set;
        }


        public string MiddleName
        {
            get;
            set;
        }

        public string DOB
        {
            get;
            set;
        }

        public string Address1
        {
            get;
            set;
        }

        public string Address2
        {
            get;
            set;
        }

        public string ContactNumber1
        {
            get;
            set;
        }


        public string ContactNumber2
        {
            get;
            set;
        }

        public string Gender
        {
            get;
            set;
        }
        public string Nationality
        {
            get;
            set;
        }


        public string category
        {
            get;
            set;
        }

        public string Profile
        {
            get;
            set;
        }

        public string Email
        {
            get;
            set;
        }
        public int THr
        {
            get;
            set;
        }

        public string logInDate1
        {
            get;
            set;
        }

        public string logInTime1
        {
            get;
            set;
        }

        public string logOutTime1
        {
            get;
            set;
        }

    }

    [Serializable]
    public class LIBFacultyDetailsListing : List<LIBFacultyDetails>
    {

    }

    
}
