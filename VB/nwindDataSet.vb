Imports System
Imports DevExpress.Data
' ...

Partial Class nwindDataSet
    Inherits Global.System.Data.DataSet
    Implements IDisplayNameProvider

    Public Function GetDataSourceDisplayName1() _
    As String Implements DevExpress.Data.IDisplayNameProvider.GetDataSourceDisplayName
        ' Substitute the default datasource display name
        ' with a custom one.
        Return "Northwind Traders"
    End Function

    Public Function GetFieldDisplayName(ByVal fieldAccessors() As String) _
    As String Implements DevExpress.Data.IDisplayNameProvider.GetFieldDisplayName
        ' Hide the data member if its name ends with 'ID'.
        If fieldAccessors(0).EndsWith("ID") Then
            Return Nothing
        End If

        ' Hide the 'Products' table, because its fields are accessible 
        ' via the 'CategoriesProducts' table only.
        If fieldAccessors(0).StartsWith("Products") Then
            Return Nothing
        End If

        ' Get a field name form the data member's name. 
        Dim fieldName As String = fieldAccessors((fieldAccessors.Length - 1))

        ' Insert spaces between separate words of a field name.
        Return ChangeNames(fieldName)
    End Function

    Public Function ChangeNames(ByVal name As String) As String
        Dim result As String = String.Empty
        Dim isPrevLow As Boolean = False

        Dim symb As Char
        For Each symb In name
            ' Check if a character is of upper case. To avoid spaces inside abbreviations,
            ' check if the previous character is of upper case, too.
            If [Char].IsUpper(symb) And isPrevLow Then
                result += " " + symb
            Else
                result += symb
            End If
            isPrevLow = [Char].IsLower(symb)
        Next symb
        Return result
    End Function
End Class
