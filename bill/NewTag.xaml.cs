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

namespace bill
{
    /// <summary>
    /// NewTag.xaml 的互動邏輯
    /// </summary>
    public partial class NewTag : UserControl
    {
        public NewTag()
        {
            InitializeComponent();
        }
        
        // 預設日期為當日
        private void TagDate_Loaded(object sender, RoutedEventArgs e)
        {
        TagDate.Text = DateTime.Now.ToString("M / dd");
        }
        
        // 避免輸入非數字的值
        public int setPriceValue
        {            
            get
            {
                try
                {
                    return int.Parse(TagPrice.Text);
                }

                catch
                {
                    {
                        MessageBox.Show("請輸入數字");
                    }
                    return 0;
                }
            }
            set
            {
                TagPrice.Text = value.ToString();
            }
        }


        //刪除事件
        private void DeletBtn_MouseDown(object sender, MouseButtonEventArgs e)
        {
            grid.Children.Remove(this);
        }
    }
}
