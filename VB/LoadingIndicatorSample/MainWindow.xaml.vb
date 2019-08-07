Imports DevExpress.Mvvm
Imports System
Imports System.Windows
Imports System.Windows.Threading

Namespace LoadingIndicatorSample
	''' <summary>
	''' Interaction logic for MainWindow.xaml
	''' </summary>
	Partial Public Class MainWindow
		Inherits Window

		Public Sub New()
			InitializeComponent()
		End Sub
	End Class

	Public Class LoadingScreenViewModel
		Inherits ViewModelBase

		Public Property Progress() As Integer
			Get
				Return GetProperty(Function() Progress)
			End Get
			Set(ByVal value As Integer)
				SetProperty(Function() Progress, value)
			End Set
		End Property
		Public Sub New()
			Dim tmr As New DispatcherTimer() With {.Interval = TimeSpan.FromSeconds(0.5)}
			AddHandler tmr.Tick, AddressOf OnTick
			tmr.Start()
		End Sub
		Private Sub OnTick(ByVal sender As Object, ByVal e As EventArgs)
			Progress += 1
			If Progress >= 100 Then
				Progress = 0
			End If
		End Sub
	End Class
End Namespace
