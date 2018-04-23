Imports Microsoft.VisualBasic
Imports System.Windows
#Region "#usings"
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraPrintingLinks
Imports DevExpress.XtraRichEdit
#End Region ' #usings
Imports System.Windows.Forms


Namespace SaveAsImage
	''' <summary>
	''' Interaction logic for MainWindow.xaml
	''' </summary>
	Partial Public Class MainWindow
		Inherits Window
		Public Sub New()
			InitializeComponent()

		End Sub

		Private Sub barButtonItem1_ItemClick(ByVal sender As Object, ByVal e As DevExpress.Xpf.Bars.ItemClickEventArgs)

			Me.Cursor = System.Windows.Input.Cursors.Wait
'			#Region "#saveasimage"
			Dim pcl As New PrintableComponentLinkBase(New PrintingSystemBase())
			pcl.Component = (CType(richEditControl1, IRichEditControl)).InnerControl
			pcl.CreateDocument(False)
			Dim imgOptions As New ImageExportOptions()
			imgOptions.ExportMode = ImageExportMode.DifferentFiles
			imgOptions.Format = System.Drawing.Imaging.ImageFormat.Png
			imgOptions.Resolution = 150
			imgOptions.PageRange = "1,3-5"
			pcl.ExportToImage("export.png", imgOptions)
'			#End Region ' #saveasimage
			Me.Cursor = System.Windows.Input.Cursors.Arrow

		End Sub

		Private Sub richEditControl1_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
			richEditControl1.LoadDocument("test.docx")
		End Sub
	End Class
End Namespace
