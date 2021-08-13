Imports System.Data.Odbc

Public Interface InfProsess
    Function InsertData(Ob As Object) As OdbcCommand

    Function updateData(Ob As Object) As OdbcCommand

    Function deleteData(kunci As String) As OdbcCommand

    Function tampilData() As DataView

    Function cariData(kunci As String) As DataView

End Interface
