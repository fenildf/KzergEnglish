using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSCommon.CommonClass;
using System.Threading;
using MgCmn;
using CSCommon.CommonClass.MgThread;
using System.Collections;


namespace LanguageWords
{

    /// <summary>
    /// deep type.
    /// </summary>
    static public class devdeep
    {
        public static bool Validate(string deep)
        {
            Type t = typeof(devdeep);
            return ProgramHelper.IsFieldValueExist(t, t.FullName, deep);
        }
        public static List<string> GetList()
        {
            return ProgramHelper.getFieldValues("LanguageWords.devdeep");
        }
        /// These are the supported "type". 
        /// <summary>
        /// english
        /// </summary>
        public const string english = "english";
    }
    public class DeepFactory
    {
        /// <summary>
        /// create interface of class Deep
        /// </summary>
        /// <param name="type"></param>
        /// <returns>IDeep operation class</returns>
        public static IDeep CreateInterface(string type)
        {
            IDeep ideep = null;
            switch (type)
            {
                case devdeep.english:
                    ideep = new english.Deep();
                    break;

                default:
					ideep = new english.Deep();
                    break;
            }
            return ideep;
        }
    }

    public interface IDeep
    {
        List<Hashtable> Next();

        List<Hashtable> Format(List<Hashtable> list);
    }
}

