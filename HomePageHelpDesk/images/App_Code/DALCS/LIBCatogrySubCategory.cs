using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using fmsf.lib;

namespace fmsf.lib
{
    [Serializable]
    public class LIBCategory
    {
        private int _CategoryId = -1;

        public int CategoryID
        {
            get { return _CategoryId; }
            set { if (value > 0 || string.IsNullOrEmpty(value.ToString())) _CategoryId = value; }
        }
        public string CategoryName
        {
            get;
            set;
        }
        public int ExamId
        {
            get;
            set;
        }
        public int AsgnId
        {
            get;
            set;
        }
        public int ScrId
        {
            get;
            set;
        }
        public string CatogeryDisplayText
        {
            get { return "CategoryName"; }


        }

        public string CategoryValueField
        {
            get { return "CategoryID"; }

        }
        public int SamId
        {
            get;
            set;
        }

    }
    [Serializable]
    public class LIBCategoryListing : List<LIBCategory>
    {

    }
    
}
