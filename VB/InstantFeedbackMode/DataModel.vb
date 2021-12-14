Imports DevExpress.Xpo

Namespace InstantFeedbackMode

    Public Class TestObject
        Inherits XPObject

        Private _subject As String

        Public Property Subject As String
            Get
                Return _subject
            End Get

            Set(ByVal value As String)
                SetPropertyValue("Subject", _subject, value)
            End Set
        End Property

        Private _sent As Date

        Public Property Sent As Date
            Get
                Return _sent
            End Get

            Set(ByVal value As Date)
                SetPropertyValue(Of Date)("Sent", _sent, value)
            End Set
        End Property

        Private _hasAttachment As Boolean

        Public Property HasAttachment As Boolean
            Get
                Return _hasAttachment
            End Get

            Set(ByVal value As Boolean)
                SetPropertyValue("HasAttachment", _hasAttachment, value)
            End Set
        End Property

        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub

        Public Sub New()
            MyBase.New(Session.DefaultSession)
        End Sub

        Public Overrides Sub AfterConstruction()
            MyBase.AfterConstruction()
        End Sub
    End Class
End Namespace
