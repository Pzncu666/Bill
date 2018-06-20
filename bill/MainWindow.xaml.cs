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
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //按+按鈕
        private void AddBtn_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //產生新項目
            NewTag newTags = new NewTag();
            TagList.Children.Add(newTags);
            
            //計算總額
            int totalprice = 0;
            foreach (NewTag newtags in TagList.Children)
            {
                totalprice += newtags.setPriceValue;
            }
            //顯示價格
            Total.Text = totalprice.ToString();
        }

        //關閉視窗
        private void Window_Closed(object sender, EventArgs e)
        {
            // 新增一個串列裝每個項目轉成的文字
            List<string> datas = new List<string>();
            // 轉換每一個項目
            foreach (NewTag tags in TagList.Children)
            {
                string line = "";

                line += tags.TagDate.Text + "|" + tags.TagName.Text + "|" + tags.TagPrice.Text;
                // 加入串列中
                datas.Add(line);
            }
            // 存檔
            System.IO.File.WriteAllLines(@"D:\data.txt", datas);
        }

        // 開啟視窗事件
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // 開檔
            string[] lines = System.IO.File.ReadAllLines(@"D:\data.txt");
            // 分析每一行
            foreach (string line in lines)
            {
                // 用 | 符號拆開
                string[] parts = line.Split('|');
                // 建立 NewTag
                NewTag newtags = new NewTag();

                newtags.TagDate.Text = parts[0];
                newtags.TagName.Text = parts[1];
                newtags.TagPrice.Text = parts[2];

                // 放到清單中
                TagList.Children.Add(newtags);
            }
        }
    }
}
