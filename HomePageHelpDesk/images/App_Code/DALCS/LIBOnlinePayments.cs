using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace fmsf.lib
{
    [Serializable]
    public class LIBOnlinePayments
    {
        private string _TID;
        public string TID
        {
            get;
            set;
        }
        private Int32 _Status;
        public Int32 Status
        {
            get;
            set;
        }
        private Decimal _ID;
        public Decimal ID
        {
            get;
            set;
        }
        private string _SiteId;
        public string SiteId
        {
            get;
            set;
        }
        private string _SiteTransactionId;
        public string SiteTransactionId
        {
            get;
            set;
        }
        private string _OrderID;
        public string OrderID
        {
            get;
            set;
        }
        private string _BankTransactionId;
        public string BankTransactionId
        {
            get;
            set;
        }
        private string _BankAuthorisationCode;
        public string BankAuthorisationCode
        {
            get;
            set;
        }
        private string _DisplayResponse;
        public string DisplayResponse
        {
            get;
            set;
        }
        private string _CurrId;
        public string CurrId
        {
            get;
            set;
        }
        private string _OrderDetails;
        public string OrderDetails
        {
            get;
            set;
        }
        private string _Method;
        public string Method
        {
            get;
            set;
        }
        private string _MethodCode;
        public string MethodCode
        {
            get;
            set;
        }
        private DateTime _TransactionDate;
        public DateTime TransactionDate
        {
            get;
            set;
        }
        private string _Type;
        public string Type
        {
            get;
            set;
        }
        private Decimal _Amount;
        public Decimal Amount
        {
            get;
            set;
        }
        private int _UserID;
        public int UserID
        {
            get;
            set;
        }
        private bool _PaymentStatus;
        public bool PaymentStatus
        {
            get;
            set;
        }

        private string _DDNo;
        public string DDNo
        {
            get;
            set;
        }

        private string _BranchName;
        public string BranchName
        {
            get;
            set;
        }

        private string _BankName;
        public string BankName
        {
            get;
            set;
        }

        private string _PaymentMode;
        public string PaymentMode
        {
            get;
            set;
        }

        private string _PaymentType;
        public string PaymentType
        {
            get;
            set;
        }

        private int _stid;
        public int stid
        {
            get;
            set;
        }

        private int _CourseId;
        public int CourseId
        {
            get;
            set;
        }

        private int _SemId;
        public int SemId
        {
            get;
            set;
        }

        private DateTime _DDdate;
        public DateTime DDdate
        {
            get;
            set;
        }
    }

[Serializable]
public class LIBOnlinePaymentsListing : List<LIBOnlinePayments>
{

}
}
