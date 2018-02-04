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
using LanguageWords;
// 定时刷新界面程序实现
using System.Windows.Threading;
// 界面库Label
using KzergWpfCtrl.List.Label;
using System.Collections;


namespace KzergEnglish
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// 定时刷新界面显示
        /// </summary>
        private DispatcherTimer dtimer = new DispatcherTimer();
        private IDeep ideep = null;

        public MainWindow()
        {
            InitializeComponent();
        }

        void dtimerTick(object sender, EventArgs e)
        {
            GetData();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            ideep = DeepFactory.CreateInterface(devdeep.english);
            GetData();
            dtimer.Tick += new EventHandler(dtimerTick);
            dtimer.Interval = TimeSpan.FromSeconds(10);
            dtimer.Start();

            
        }

        private void GetData()
        {
            List<Hashtable> list = ideep.Next();
            list = ideep.Format(list);
            ull.Update(list);
        }
    }
}
