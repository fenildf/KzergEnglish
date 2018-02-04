/********************************************************************************
** auth： 张白玉
** date： 2018-02-01 15:43:41
** desc： base of function of Deep
** Version:  1.0.0.1
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSCommon.CommonClass;
using System.Data;
using CodeForm;
using System.Collections;

namespace LanguageWords
{
    public class BaseDeep
    {
        protected string ConfigPath = @"D:\MyDocuments\文献资料\personal\dailyRecord\EnglishLearn2018.xlsx";
        private DataTable dtAllWord = null;
        private DataTable dtAllRoot = null;

        protected List<Hashtable> GetFormatList(List<Hashtable> list)
        {
            for (int i = 0; i < ListHelper.Count<Hashtable>(list); i++)
            {
                Hashtable ht = ListHelper.Get<Hashtable>(list, i, null);

                // now has two type of question.
                // 1.display word
                // 2.display explain
                int randomQuesType = DebugHelper.IntRandom99();

                bool bQuesType = randomQuesType % 2 == 0;

                string content = HashtableHelper.GetString(ht, bQuesType ? "单词" : "解释");
                string tooltip1 = HashtableHelper.GetString(ht, bQuesType ? "解释" : "单词");
                string tooltip2 = HashtableHelper.GetString(ht, "例句");

                HashtableHelper.Add(ref ht, "label.content", content);
                HashtableHelper.Add(ref ht, "label.tooltip1", tooltip1);
                HashtableHelper.Add(ref ht, "label.tooltip2", tooltip2);
            }
            return list;
        }

        protected List<Hashtable> GetNextList()
        {
            if(dtAllWord == null)
            {
                ExcelInput eiWord = new ExcelInput(ConfigPath);
                dtAllWord = eiWord.ToDataTable();
                dtAllRoot = eiWord.ToDataTable(1);
            }

            List<Hashtable> list = new List<Hashtable>();

            int nTarget = DebugHelper.IntRandom(0,3);
            switch(nTarget)
            {
                case 0:
                    list = GetNextListByRoot();
                    break;
                case 1:
                    list = GetNextListByExplain();
                    break;
                default:// random get words
                    list = DebugHelper.ChooseFromDataTable(dtAllWord, 5);
                    break;
            }


            return list;
        }

        private List<Hashtable> GetNextListByRoot()
        {
            List<Hashtable> list = new List<Hashtable>();
            List<Hashtable> rootlist = DebugHelper.ChooseFromDataTable(dtAllRoot, 1);
            Hashtable ht = ListHelper.Get<Hashtable>(rootlist, DebugHelper.IntRandom(0, ListHelper.Count<Hashtable>(rootlist)), null);
            string roots = HashtableHelper.GetString(ht, "单词");
            string[] rootArr = StringHelper.Split(roots,",");
            string root = ArrayHelper.Get<string>(rootArr, 0, "");
            if (root == "") return new List<Hashtable>();
            DataTable dt = DataTableHelper.Select(dtAllWord, "[单词] like '%" + root + "%'");
            return DataTableHelper.ToHashtableList(dt);
        }

        private List<Hashtable> GetNextListByExplain()
        {
            List<Hashtable> list = new List<Hashtable>();
            List<Hashtable> rootlist = DebugHelper.ChooseFromDataTable(dtAllWord, 1);
            Hashtable ht = ListHelper.Get<Hashtable>(rootlist, DebugHelper.IntRandom(0, ListHelper.Count<Hashtable>(rootlist)), null);
            string fullexplain = HashtableHelper.GetString(ht, "解释");
            string explain = RegexHelper.Replace(fullexplain, "[^\\u4e00-\\u9fa5]+", "");
            int n = DebugHelper.IntRandom(0, explain.Length);
            string randexplain = StringHelper.Substring(explain, n, 1);
            DataTable dt = DataTableHelper.Select(dtAllWord, "[解释] like '%" + randexplain + "%'");
            return DataTableHelper.ToHashtableList(dt);
        }
    }
}

