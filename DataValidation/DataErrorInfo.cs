using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WNSNotifier.DataValidation
{
    public class DataErrorInfo:IDataErrorInfo
    {
        string IDataErrorInfo.Error
        {
            get { return DataErrorInfoHelper.GetErrorInfo(this); }
        }

        string IDataErrorInfo.this[string columnName]
        {
            get { return DataErrorInfoHelper.GetErrorInfo(this, columnName); }
        }
    }
}
