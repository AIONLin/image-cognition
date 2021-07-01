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
using NumSharp;
using NumSharp.Backends;
using NumSharp.Backends.Unmanaged;
using SharpCV;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using Tensorflow;
using static Tensorflow.Binding;
using static SharpCV.Binding;
using System.Collections.Concurrent;
using System.Threading.Tasks;



namespace image_cognition
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            public bool Run()
            {
                string url = "https://github.com/SciSharp/SciSharp-Stack-Examples/blob/master/data/data_CnnInYourOwnData.zip";
                Directory.CreateDirectory(Name);
                Utility.Web.Download(url, Name, "data_CnnInYourOwnData.zip");
                Utility.Compress.UnZip(Name + "\\data_CnnInYourOwnData.zip", Name);
                BuildGraph();
​
                using (var sess = tf.Session())
                {
                    Train(sess);
                    Test(sess);
                }
​
                TestDataOutput();
​
                return accuracy_test > 0.98;
​            }
        }
    }
}
