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

    public class LIBStudent
    {
        public LIBStudent()
        {

        }

        public string StudentEmail
        {
            get;
            set;
        }

        public int StudentLogId
        {
            set;
            get;
        }



        public string LoginFrom
        {
            get;
            set;
        }


        public DateTime LoginDate
        {
            get;
            set;
        }

        public string LoginDate1
        {
            get;
            set;
        }
        public string LoginTime
        {
            get;
            set;
        }
        public DateTime LoginOut
        {
            get;
            set;
        }


        public int stid
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

        public string StudentName
        {
            get;
            set;
        }


        public string CourseTitle
        {
            get;
            set;
        }






        public int aid
        {
            get;
            set;
        }
        public string FirstName
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


        public string CuurentProfession
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


        public string edboard1
        {
            get;
            set;
        }



        public string edstream1
        {
            get;
            set;
        }



        public string edmarks1
        {
            get;
            set;
        }



        public string edyrs1
        {
            get;
            set;
        }


        public string edboard2
        {
            get;
            set;
        }



        public string edstream2
        {
            get;
            set;
        }



        public string edmarks2
        {
            get;
            set;
        }



        public string edyrs2
        {
            get;
            set;
        }

        public string edboard3
        {
            get;
            set;
        }



        public string edstream3
        {
            get;
            set;
        }



        public string edmarks3
        {
            get;
            set;
        }



        public string edyrs3
        {
            get;
            set;
        }

        public string edboard4
        {
            get;
            set;
        }



        public string edstream4
        {
            get;
            set;
        }



        public string edmarks4
        {
            get;
            set;
        }



        public string edyrs4
        {
            get;
            set;
        }


        public string totExp
        {
            get;
            set;
        }



        public string ExOrg1
        {
            get;
            set;
        }


        public string ExPh1
        {
            get;
            set;
        }

        public string ExDesignation1
        {
            get;
            set;
        }



        public string ExService1
        {
            get;
            set;
        }




        public string ExOrg2
        {
            get;
            set;
        }


        public string ExPh2
        {
            get;
            set;
        }

        public string ExDesignation2
        {
            get;
            set;
        }



        public string ExService2
        {
            get;
            set;
        }

        public int FacultyLogId
        {
            set;
            get;
        }



        public int Fid
        {
            get;
            set;
        }




        public string FacultyName
        {
            get;
            set;
        }

        public int THr
        {
            get;
            set;
        }
        public int Courseid
        {
            get;
            set;
        }
        public int batchid
        {
            get;
            set;
        }
        public string CourseCode
        {
            get;
            set;
        }
        public string BatchCode
        {
            get;
            set;
        }
        public string LoginTime1
        {
            get;
            set;
        }
        public string LoginOutTime1
        {
            get;
            set;
        }

        public string Password
        {
            get;
            set;
        }

        public string ProfileImage
        {
            get;
            set;
        }

        public int KCID
        {
            get;
            set;
        }
        public string Caption
        {
            get;
            set;
        }
        public string KnowledgeCenterType
        {
            get;
            set;
        }
        public string KnowledgeCenterDescription
        {
            get;
            set;
        }

        public string FileName
        {
            get;
            set;
        }

        public string FilePath
        {
            get;
            set;
        }

        public string FileMode
        {
            get;
            set;
        }

        public string URLlink
        {
            get;
            set;
        }
        public Boolean Check
        {
            get;
            set;
        }

        public string Search
        {
            get;
            set;
        }

        public int SemesterId
        {
            get;
            set;
        }

        public int PaperId
        {
            get;
            set;
        }
        public int UnitId
        {
            get;
            set;
        }
        public string Note
        {
            get;
            set;
        }

        public string RowNumber
        {
            get;
            set;
        }
    }
        [Serializable]
        public class LIBStudentListing : List<LIBStudent>
        {

        }



    
}
