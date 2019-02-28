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

namespace DispatcherExample
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnProcess_Click(object sender, RoutedEventArgs e)
        {
            UseTask();
        }


        private void UseTask()
        {
            //使用Task创建一个新的线程
            Task task = new Task(() =>
            {
                int inputNUm = 100;
               for (int i = 0; i < inputNUm; i++)
                {
                    System.Threading.Thread.Sleep(100);
                    //this.Dispatcher.BeginInvoke((Action)delegate
                    //    {
                    //        this.progressBar.Value = i;
                    //        this.textBox.Text = i.ToString();

                    //    });
                    
                    //使用Dispatcher访问本线程
                    this.Dispatcher.Invoke(new Action(() =>
                    {
                        this.progressBar.Value = i;
                        this.textBox.Text = i.ToString();
                    }));
                }
                MessageBox.Show("sddd");

            });

            task.Start();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.progressBar.Value = 0;
            this.textBox.Text = null;
        }
    }
}
