using System.Windows;
#region #usings
using DevExpress.XtraPrinting;
using DevExpress.XtraPrintingLinks;
using DevExpress.XtraRichEdit;
#endregion #usings
using System.Windows.Forms;


namespace SaveAsImage
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {

            this.Cursor = System.Windows.Input.Cursors.Wait;
            #region #saveasimage
            PrintableComponentLinkBase pcl = new PrintableComponentLinkBase(new PrintingSystemBase());
            pcl.Component = ((IRichEditControl)richEditControl1).InnerControl;
            pcl.CreateDocument(false);
            ImageExportOptions imgOptions = new ImageExportOptions();
            imgOptions.ExportMode = ImageExportMode.DifferentFiles;
            imgOptions.Format = System.Drawing.Imaging.ImageFormat.Png;
            imgOptions.Resolution = 150;
            imgOptions.PageRange = "1,3-5";
            pcl.ExportToImage("export.png", imgOptions);
            #endregion #saveasimage
            this.Cursor = System.Windows.Input.Cursors.Arrow;

        }

        private void richEditControl1_Loaded(object sender, RoutedEventArgs e)
        {
            richEditControl1.LoadDocument("test.docx");
        }
    }
}
