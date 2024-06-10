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
    public class LIBExam
    {
        public string StudentName
        {
            get;
            set;
        }
        public string ColName
        {
            get;
            set;
        }
        public string EmailContent
        {
            get;
            set;
        }

        public string StudentEmail
        {
            get;
            set;
        }
        public string UploadQuestionImagePath
        {
            get;
            set;
        }
        public string App_Status
        {
            get;
            set;
        }

        public string Option
        {
            get;
            set;
        }
        public string FileCaption
        {
            get;
            set;
        }

        public string UploadFilePath
        {
            get;
            set;
        }
        public string FromDate
        {
            get;
            set;
        }
        public string ToDate
        {
            get;
            set;
        }
        public string Activate
        {
            get;
            set;
        }
        public string CourseName
        {
            get;
            set;
        }
        public string Text1
        {
            get;
            set;
        }
        public string Text2
        {
            get;
            set;
        }
        public string Text3
        {
            get;
            set;
        }
        public string Text4
        {
            get;
            set;
        }

        public string BannerHeading
        {
            get;
            set;
        }

        public string BannerDesc
        {
            get;
            set;
        }

        public string dataorientation
        {
            get;
            set;
        }

        public string Bannerimages
        {
            get;
            set;
        }
        public string CourseOfferedIcon
        {
            get;
            set;
        }

        public string dataslice1rotation
        {
            get;
            set;
        }

        public string dataslice2rotation
        {
            get;
            set;
        }

        public string dataslice1scale
        {
            get;
            set;
        }

        public string dataslice2scale
        {
            get;
            set;
        }

        public string ImagePath
        {
            get;
            set;
        }
        public Boolean Check
        {
            get;
            set;
        }
        public int Year
        {
            get;
            set;
        }
        public string Name
        {
            get;
            set;
        }
        public string Type
        {
            get;
            set;
        }
        public string UploadAnsPath
        {
            get;
            set;
        }
        public int ExamId
        {
            get;
            set;
        }
        public int fid
        {
            get;
            set;
        }
        public int AsgnId
        {
            get;
            set;
        }
        public int OldExamId
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
        public string examcode
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
        public string ExamDisplayText
        {
            get { return "ExamName"; }


        }

        public string ExamValueField
        {
            get { return "ExamId"; }

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
       
        
        public string ExamName
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

        public int userid
        {
            get;
            set;
        }
        public int Bid
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

        private string _InstructionText;
        public string InstructionText
        {
            get { return _InstructionText; }
            set { _InstructionText = value; }

        }

        public Boolean ExamMarks
        {
            get;
            set;
        }
        public Boolean AssignmentMarks
        {
            get;
            set;
        }
        public Boolean DiscussionForumMarks
        {
            get;
            set;
        }
        public Boolean ProjectMarks
        {
            get;
            set;
        }

        public Boolean CaseStudyMarks
        {
            get;
            set;
        }

        public string ColumnName1
        {
            get;
            set;
        }
        public string ColumnName2
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
        public string Password
        {
            get;
            set;
        }

        private int _bid;
        public int bid1
        {
            get { return _bid; }
            set { _bid = value; }
        }
        private string _BatchCode;

        public string BatchCode1
        {
            get { return _BatchCode; }
            set { _BatchCode = value; }

        }


        public int OldSubQuestionId
        {
            get;
            set;
        }


        public string FeeStatus
        {
            get;
            set;
        }

        public string PassStatus
        {
            get;
            set;
        }


      
        public string Topic
        {
            get;
            set;
        }

        public string PostReply
        {
            get;
            set;
        }


        public int SubjectId
        {
            get;
            set;
        }


        public string DateOfPost
        {
            get;
            set;
        }

        public string TextDetails
        {
            get;
            set;
        }

        public Boolean ChkCourseOffered
        {
            get;
            set;
        }

        public string FacultyName
        {
            get;
            set;
        }
        public string FacultyEmail
        {
            get;
            set;
        }

        public string Gender
        {
            get;
            set;
        }

        public string courseEmail
        {
            get;
            set;
        }

        public DateTime TestimonialsDate
        {
            get;
            set;
        }
        public DateTime CertificateDispatchedDate
        {
            get;
            set;
        }
        public DateTime SentDate
        {
            get;
            set;
        }
        public DateTime ReceiveDate
        {
            get;
            set;
        }
        public DateTime StudentTestimonialsDate
        {
            get;
            set;
        }
        public DateTime StudentCertificateDispatchedDate
        {
            get;
            set;
        }
        public int stid
        {
            get;
            set;
        }
        //public int CourseId
        //{
        //    get;
        //    set;
        //}
        public int bid
        {
            get;
            set;
        }
        public string paperid
        {
            get;
            set;
        }

        /// <summary>
        /// added by chhaya
        /// </summary>
        public string TestimonialsDate1
        {
            get;
            set;
        }
        public string CertificateDispatchedDate1
        {
            get;
            set;
        }
        public string StudentTestimonialsDate1
        {
            get;
            set;
        }
        public string StudentCertificateDispatchedDate1
        {
            get;
            set;
        }

        public string ReceiveDate1
        {
            get;
            set;
        }
        public string SentDate1
        {
            get;
            set;
        }

        public int FacultyId
        {
            get;
            set;
        }
        public int TotalMarks
        {
            get;
            set;
        }

        public int UnitID
        {
            get;
            set;
        }

        public int ChapterID
        {
            get;
            set;
        }

        public int GroupId
        {
            get;
            set;
        }

        public string GroupName
        {
            get;
            set;
        }

        public string Exam
        {
            get;
            set;
        }

        public string Project
        {
            get;
            set;
        }

        public string Assignment
        {
            get;
            set;
        }

        public string CaseStudy
        {
            get;
            set;
        }

        public string Forum
        {
            get;
            set;
        }

        public Boolean ApplicantCategory
        {
            get;
            set;
        }
        public Boolean CurrentProfession
        {
            get;
            set;
        }

        public Boolean EvaluationCategory
        {
            get;
            set;
        }

        public Boolean EducationalDetails
        {
            get;
            set;
        }

        public Boolean WorkExperience
        {
            get;
            set;
        }

        public int OrderNumber
        {
            get;
            set;
        }
    }
    [Serializable]
    public class LIBExamListing : List<LIBExam>
    {

    }
}
