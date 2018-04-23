Imports System
Imports System.Windows
Imports DevExpress.Data.Filtering
Imports DevExpress.Xpf.Grid
Imports DevExpress.Xpo
Imports DevExpress.Xpf.Core

Namespace InstantFeedbackMode
    ''' <summary>
    ''' Interaction logic for MainWindow.xaml
    ''' </summary>
    Partial Public Class MainWindow
        Inherits Window

        Public Sub New()
            InitDAL()
            ' Generates test data - 100,000 records.
            GenerateTestData(100000)
            InitializeComponent()

            ' Creates and initializes the data source which activates the Instant Feedback UI Mode.
            Dim instantDS As New XPInstantFeedbackSource(GetType(TestObject))
            AddHandler instantDS.ResolveSession, AddressOf instantDS_ResolveSession
            AddHandler instantDS.DismissSession, AddressOf instantDS_DismissSession

            ' Bind the grid.
            grid.ItemsSource = instantDS
        End Sub

        Private Sub instantDS_ResolveSession(ByVal sender As Object, ByVal e As ResolveSessionEventArgs)
            e.Session = New UnitOfWork()
        End Sub

        Private Sub instantDS_DismissSession(ByVal sender As Object, ByVal e As ResolveSessionEventArgs)
            Dim session As IDisposable = TryCast(e.Session, IDisposable)
            If session IsNot Nothing Then
                session.Dispose()
            End If
        End Sub

        Private Shared Sub InitDAL()
            XpoDefault.Session = Nothing
            XpoDefault.DataLayer = XpoDefault.GetDataLayer(DevExpress.Xpo.DB.AccessConnectionProvider.GetConnectionString("test.mdb"), DevExpress.Xpo.DB.AutoCreateOption.DatabaseAndSchema)
        End Sub

        Private Sub GenerateTestData(ByVal recordCount As Integer)
            Using s As New UnitOfWork()
                If s.FindObject(Of TestObject)(Nothing) IsNot Nothing Then
                    Return
                End If
                For i As Integer = 0 To recordCount - 1
                    Dim o As New TestObject(s) With {.HasAttachment = False, .Sent = Date.Now, .Subject = String.Format("Subject {0}", i)}
                Next i
                s.CommitChanges()
            End Using
        End Sub
    End Class
End Namespace
