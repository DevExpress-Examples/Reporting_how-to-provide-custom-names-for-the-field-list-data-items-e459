Imports System
Imports DevExpress.Data
' ...

Partial Class nwindDataSet
    Inherits Global.System.Data.DataSet
    Implements IDataDictionary

    ' Implement the GetDataSourceDisplayName method.
    Function GetDataSourceDisplayName() As String _
    Implements IDataDictionary.GetDataSourceDisplayName
        Return "Northwind Traders"
    End Function

    ' Implement the GetObjectDisplayName method.
    Function GetObjectDisplayName(ByVal dataMember As String) As String _
    Implements IDataDictionary.GetObjectDisplayName

        ' Hide the data member, which name ends with 'ID'.
        If dataMember.EndsWith("ID") Then
            Return Nothing
        End If

        ' Hide the 'Products' table, as its fields are accessible via
        ' the 'CategoriesProducts' table only.
        If dataMember.StartsWith("Products") Then
            Return Nothing
        End If

        ' Find a dot in the data member's name. 
        Dim names As String() = dataMember.Split("."c)

        ' Get a field name form the data member's name. 
        Dim fieldName As String = names((names.Length - 1))

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
