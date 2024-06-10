using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace fmsf.lib
{
    /// <summary>
    /// this class have information about sales person
    /// </summary>
    [Serializable]
    public class LIBSample
    {
        public string UserName
        {
            get;
            set;
        }
        public string Password
        {
            get;
            set;
        }
        public string SamplePath
        {
            get;
            set;
        }
        public string UploadQuestionImagePath
        {
            get;
            set;
        }
        public string Activate
        {
            get;
            set;
        }
        public string InstructionText
        {
            get;
            set;
        }
        public string StudentName
        {
            get;
            set;
        }
        public string Option
        {
            get;
            set;
        }
        public string Type
        {
            get;
            set;
        }
        public string StudentEmail
        {
            get;
            set;
        }

        public string UploadAnsPath
        {
            get;
            set;
        }
        public string SampleType
        {
            get;
            set;
        }
        public int SamId
        {
            get;
            set;
        }
        public int Year
        {
            get;
            set;
        }
        public int OldSamId
        {
            get;
            set;
        }
        public string UserId
        {
            get;
            set;
        }
        public int SubQuestionId
        {
            get;
            set;
        }
        
        public string QUESTYPE
        {
            get;
            set;
        }
        public int MaxQueInSection
        {
            get;
            set;
        }
        public int MaxAttemptQue
        {
            get;
            set;
        }
        public int MaxQueMarks
        {
            get;
            set;
        }
        public string Samplecode
        {
            get;
            set;
        }
        public string Answer
        {
            get;
            set;
        }
        public string CourseTitle
        {
            get;
            set;
        }
        public string CourseCode
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
        public string PaperTitle
        {
            get;
            set;
        }
        public int CourseId
        {
            get;
            set;
        }
        public int SemesterId
        {
            get;
            set;
        }
        public int ModuleId
        {
            get;
            set;
        }
        public int paperId
        {
            get;
            set;
        }
        public Boolean Descriptive
        {
            get;
            set;
        }

        public Boolean Review
        {
            get;
            set;
        }
        public string CourseDispalyText
        {
            get { return "CourseTitle"; }


        }

        public string CourseValueField
        {
            get { return "CourseId"; }

        }
        public string SemesterDispalyText
        {
            get { return "SemesterTitle"; }


        }

        public string SemesterValueField
        {
            get { return "SemesterId"; }

        }

        public string ModuleDispalyText
        {
            get { return "ModuleTitle"; }


        }

        public string ModuleValueField
        {
            get { return "ModuleId"; }

        }

        public string PaperDispalyText
        {
            get { return "PaperTitle"; }


        }

        public string PaperValueField
        {
            get { return "PaperId"; }

        }
        public int QuestionId
        {
            get;
            set;
        }

        public int OldQuestionId
        {
            get;
            set;
        }

        public int NoOfAns
        {
            get;
            set;
        }
        public string QuesNo
        {
            get;
            set;
        }
        public int OPTID
        {
            get;
            set;
        }
        
        public string AnsText
        {
            get;
            set;
        }
        public string Category
        {
            get;
            set;
        }
       
        public string QuestionText
        {
            get;
            set;
        }
       
        public string OPTIONSDisplayText
        {
            get { return "OPTIONS"; }


        }

        public string OPTIONSValueField
        {
            get { return "OPTID"; }

        }
        public string SampleDisplayText
        {
            get { return "SampleName"; }


        }

        public string SampleValueField
        {
            get { return "SampleId"; }

        }
       
        public string OPTIONS
        {
            get;
            set;
        }
        public string OPTIONTYPE
        {
            get;
            set;
        }
       
        public int CategoryID
        {
            get;
            set;
        }
       
        
        public string SampleName
        {
            get;
            set;
        }
        public string CategoryName
        {
            get;
            set;
        }
       
        
        
        public string Question
        {
            get;
            set;
        }
      
       
        public string CreateDate
        {
            get;
            set;
        }

        public int BatchId
        {
            get;
            set;
        }
        public string BatchTitle
        {
            get;
            set;
        }
        public DateTime activateDate
        {
            get;
            set;
        }
        public DateTime DeactivateDate
        {
            get;
            set;
        }
        public string BatchDispalyText
        {
            get { return "BatchCode"; }


        }

        public string BatchValueField
        {
            get { return "BId"; }

        }

        private int _TimeAllowted;
        public int TimeAllowted
        {
            get { return _TimeAllowted; }
            set { _TimeAllowted = value; }
        }
        public int Stid
        {
            get;
            set;
        }


    }
    [Serializable]
    public class LIBSampleListing : List<LIBSample>
    {

    }
}
