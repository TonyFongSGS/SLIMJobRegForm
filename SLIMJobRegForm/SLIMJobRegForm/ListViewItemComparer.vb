Public Class ListViewItemComparer
    Implements System.Collections.IComparer
    Private col As Integer

    Public Sub New()
        col = 0
    End Sub

    Public Sub New(column As Integer)
        col = column
    End Sub

    Public Function Compare(x As Object, y As Object) As Integer _
                            Implements System.Collections.IComparer.Compare
        Dim returnVal As Integer = -1

        If col = 0 Then
            'Dim dX As Double = Convert.ToDouble(CType(x, Windows.Forms.ListViewItem).SubItems(col).Text)
            'Dim dY As Double = Convert.ToDouble(CType(y, Windows.Forms.ListViewItem).SubItems(col).Text)
            'If dX < dY Then
            '    returnVal = CType(x, Windows.Forms.ListViewItem).SubItems(col).Text
            'Else
            '    returnVal = CType(y, Windows.Forms.ListViewItem).SubItems(col).Text
            'End If

            returnVal = [String].Compare(Right(CType(x, Windows.Forms.ListViewItem).SubItems(col).Text.PadLeft(10, "0"), 10), _
                Right(CType(y, Windows.Forms.ListViewItem).SubItems(col).Text.PadLeft(10, "0"), 10))
        Else
            returnVal = [String].Compare(CType(x,  _
                            Windows.Forms.ListViewItem).SubItems(col).Text, _
                            CType(y, Windows.Forms.ListViewItem).SubItems(col).Text)
        End If

        Return returnVal

    End Function

End Class