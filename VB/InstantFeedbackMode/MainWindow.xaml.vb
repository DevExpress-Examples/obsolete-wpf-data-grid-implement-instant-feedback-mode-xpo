Imports System
Imports System.Windows
Imports DevExpress.Xpo

Namespace InstantFeedbackMode

    ''' <summary>
    ''' Interaction logic for MainWindow.xaml
    ''' </summary>
    Public Partial Class MainWindow
        Inherits Window

        Public Sub New()
            Call InitDAL()
            ' Generates test data - 100,000 records.
            GenerateTestData(100000)
            Me.InitializeComponent()
            ' Creates and initializes the data source which activates the Instant Feedback UI Mode.
            Dim instantDS As XPInstantFeedbackSource = New XPInstantFeedbackSource(GetType(TestObject))
            AddHandler instantDS.ResolveSession, New EventHandler(Of ResolveSessionEventArgs)(AddressOf instantDS_ResolveSession)
            AddHandler instantDS.DismissSession, New EventHandler(Of ResolveSessionEventArgs)(AddressOf instantDS_DismissSession)
            ' Bind the grid.
            Me.grid.ItemsSource = instantDS
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
            XpoDefault.DataLayer = XpoDefault.GetDataLayer(DB.AccessConnectionProvider.GetConnectionString("test.mdb"), DB.AutoCreateOption.DatabaseAndSchema)
        End Sub

        Private Sub GenerateTestData(ByVal recordCount As Integer)
            Using s As UnitOfWork = New UnitOfWork()
                If s.FindObject(Of TestObject)(Nothing) IsNot Nothing Then Return
                For i As Integer = 0 To recordCount - 1
                    Dim o As TestObject = New TestObject(s) With {.HasAttachment = False, .Sent = Date.Now, .Subject = String.Format("Subject {0}", i)}
                Next

                s.CommitChanges()
            End Using
        End Sub
    End Class
End Namespace
