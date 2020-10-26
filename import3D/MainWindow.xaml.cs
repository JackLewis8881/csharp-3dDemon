using HelixToolkit.Wpf;
using System.Windows;
using System.Windows.Media.Media3D;

namespace import3D
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        ModelImporter import = new ModelImporter();//导入模型的类对象
        public MainWindow()
        {
            InitializeComponent();
            ObjReader myHelixObjReader = new ObjReader();
            //读入模型文件
            Model3DGroup MyModel = import.Load(@".\model\magnolia.stl");
            // Display the model
            model.Content = MyModel;
            helixControl.ZoomExtents();
        }

        private void F_16_btn_Click(object sender, RoutedEventArgs e)
        {
            string myModelPath = chooseModel();
            Model3DGroup MyModel;
            if (string.Empty!=myModelPath)
            {
                MyModel = import.Load(myModelPath);
                model.Content = MyModel;
                helixControl.ZoomExtents();
            }
        }
        
        string chooseModel() {
            string path = string.Empty;
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.InitialDirectory = System.IO.Directory.GetCurrentDirectory();
            // Show open file dialog box
            System.Nullable<bool> result = dlg.ShowDialog();

            // Process open file dialog box results
            if (result == true)
            {
                // Open document
                path = dlg.FileName;
            }
            return path;
        }
    }
}
