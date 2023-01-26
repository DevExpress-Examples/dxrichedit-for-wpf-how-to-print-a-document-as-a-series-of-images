Imports System.Windows
'#Region "#usings"
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraPrintingLinks
Imports DevExpress.XtraRichEdit

'#End Region  ' #usings
Namespace SaveAsImage

    ''' <summary>
    ''' Interaction logic for MainWindow.xaml
    ''' </summary>
    Public Partial Class MainWindow
        Inherits Window

        Public Sub New()
            Me.InitializeComponent()
        End Sub

        Private Sub barButtonItem1_ItemClick(ByVal sender As Object, ByVal e As DevExpress.Xpf.Bars.ItemClickEventArgs)
            Cursor = Input.Cursors.Wait
'#Region "#saveasimage"
            Dim pcl As PrintableComponentLinkBase = New PrintableComponentLinkBase(New PrintingSystemBase())
            pcl.Component = CType(Me.richEditControl1, IRichEditControl).InnerControl
            pcl.CreateDocument(False)
            Dim imgOptions As ImageExportOptions = New ImageExportOptions()
            imgOptions.ExportMode = ImageExportMode.DifferentFiles
            imgOptions.Format = System.Drawing.Imaging.ImageFormat.Png
            imgOptions.Resolution = 150
            imgOptions.PageRange = "1,3-5"
            pcl.ExportToImage("export.png", imgOptions)
'#End Region  ' #saveasimage
            Cursor = Input.Cursors.Arrow
        End Sub

        Private Sub richEditControl1_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Me.richEditControl1.LoadDocument("test.docx")
        End Sub
    End Class
End Namespace
