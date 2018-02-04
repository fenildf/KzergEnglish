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
using CSCommon.CommonClass;

namespace KzergWpfCtrl.Basic.Label
{
    /// <summary>
    /// ucTipLabel.xaml 的交互逻辑
    /// </summary>
    public partial class ucTipLabel : UserControl
    {
        private string text = "";
        private string tip1 = "";
        private string tip2 = "";

        public ucTipLabel()
        {
            InitializeComponent();
        }
        public int Init(string text, string tip1, string tip2)
        {
            lb.Content = text;
            this.tip1 = tip1;
            this.tip2 = tip2;
            tb.Text = tip1;
            return ErrorCode.Success;
        }
        private void lb_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (tb.Text == tip2) tb.Text = tip1;
            else tb.Text = tip2;
        }
    }
}
