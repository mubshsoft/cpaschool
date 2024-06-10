using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Chapter
/// </summary>
namespace fmsf.lib
{
    [Serializable]
    public class Chapter
    {
        public int ID
        {
            get;
            set;
        }
        public int UnitID
        {
            get;
            set;
        }
        public string ChapterID
        {
            get;
            set;
        }

        public string ChapterText
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

        public string Type
        {
            get;
            set;
        }

        public string KeyLearning
        {
            get;
            set;
        }
        public Boolean Status
        {
            get;
            set;
        }

        public string active
        {
            get;
            set;
        }

        public string AssessmentsURL
        {
            get;
            set;
        }

        public string UserId
        {
            get;
            set;
        }
    }
    [Serializable]
    public class ChapterListing : List<Chapter>
    {

    }
}