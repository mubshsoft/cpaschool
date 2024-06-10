using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace fmsf.lib
{

    #region EMessageType are the name of the object use in the complete project
    public enum EMessageType : int
    {
        Overtime = 1,
        payperiodtype = 2,
        Payperiodday = 3,
        Payperiodtimeslot = 4,
        payperioddays = 5,
        ColorCode = 6,
        PayType = 7,
        YesNo = 8


    }//end EMessageType
    #endregion EMessageType are the name of the object use in the complete project

    #region EStatus of the Action Perform
    public enum EStatus : int
    {
        Failure,
        Success,
        DatabaseNotFound,
        Exception,
        RecordNotFound,
        Duplicate
    }//end EStatus
    #endregion EStatus of the Action Perform

    #region enum of EXMLContextTypes
    public enum EXMLContextTypes : int
    {
        ClientDBConnection = 1,
        SearchInfo = 2
    }
    #endregion

    #region enum of Continet Types
    public enum ContinetTypes : int
    {
        Australia1 = 1,
        Africa = 2,
        Asia = 3,
        SouthAmerica = 4,
        NorthAmerica = 5,
        Europe = 6,
      
       
    }
    #endregion



}