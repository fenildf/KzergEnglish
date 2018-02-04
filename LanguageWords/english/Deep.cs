using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSCommon.CommonClass;
using System.Threading;
using MgCmn;
using CSCommon.CommonClass.MgThread;
using System.Collections;


namespace LanguageWords.english
{
    // 2018-02-01 15:43:41
    /// <summary>
    /// Deep function class. operation .
    /// </summary>
    public class Deep : BaseDeep, IDeep
    {
        public List<Hashtable> Next()
        {
            List<Hashtable> list = GetNextList();
            return list;
        }


        public List<Hashtable> Format(List<Hashtable> list)
        {
            return GetFormatList(list);
        }
    }

}
