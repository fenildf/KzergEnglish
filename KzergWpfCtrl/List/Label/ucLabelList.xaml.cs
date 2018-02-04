using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections;
using CSCommon.CommonClass;
using KzergWpfCtrl.Basic.Label;

namespace KzergWpfCtrl.List.Label
{
    /// <summary>
    /// ucLabelList.xaml 的交互逻辑
    /// </summary>
    public partial class ucLabelList : UserControl
    {
        public ucLabelList()
        {
            InitializeComponent();
        }
        //private void InitRows(int rowCount, Grid g)
        //{
        //    while (rowCount-- > 0)
        //    {
        //        RowDefinition rd = new RowDefinition();
        //        rd.Height = new GridLength();
        //        g.RowDefinitions.Add(rd);
        //    }
        //}
        //private void InitColumns(int colCount, Grid g)
        //{
        //    while (colCount-- > 0)
        //    {
        //        ColumnDefinition rd = new ColumnDefinition();
        //        rd.Width = new GridLength();
        //        g.ColumnDefinitions.Add(rd);
        //    }
        //}

        /// <summary>
        /// set label content
        /// </summary>
        /// <param name="list">
        /// key = label.content
        /// key = label.tooltip1
        /// key = label.tooltip2
        /// </param>
        public int Update(List<Hashtable> list)
        {
            if (ListHelper.IsNullOrEmpty(list))
                return ErrorCode.EmptyParams;
            int rowCount = ListHelper.Count<Hashtable>(list);
            while (rowCount-- > 0)
            {
                RowDefinition rd = new RowDefinition();
                rd.Height = new GridLength();
                grid.RowDefinitions.Add(rd);
            }
            grid.Children.Clear();
            int nRow = 0;
            foreach (Hashtable item in list)
            {
                string content = HashtableHelper.GetString(item, "label.content");
                string tooltip1 = HashtableHelper.GetString(item, "label.tooltip1");
                string tooltip2 = HashtableHelper.GetString(item, "label.tooltip2");
                ucTipLabel utl = new ucTipLabel();
                utl.Init(content, tooltip1, tooltip2);
                grid.Children.Add(utl);
                // Grid.SetColumn(utl, c);
                Grid.SetRow(utl, nRow++);
            }
            return ErrorCode.Success;
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

        }


    }
}
