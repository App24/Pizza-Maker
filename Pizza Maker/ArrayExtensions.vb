Imports System.Runtime.CompilerServices

Public Module ArrayExtensions
    <Extension()>
    Public Sub Add(Of T)(ByRef arr As T(), item As T)
        If arr IsNot Nothing Then
            Array.Resize(arr, arr.Length + 1) 'Resizes the array to ensure that it can add an extra item to it
            arr(arr.Length - 1) = item 'Appends the item to the end of it
        Else
            ReDim arr(0) 'If array is null it then recreates the array with 1 length
            arr(0) = item 'Then sets the array's first element to the item
        End If

    End Sub
    <Extension()>
    Public Sub RemoveAt(Of T)(ByRef arr As T(), ByVal index As Integer)
        Dim uBound = arr.GetUpperBound(0) 'This equates to arr.length - 1
        Dim lBound = arr.GetLowerBound(0)
        Dim arrLen = uBound - lBound

        If index < lBound OrElse index > uBound Then
            Throw New ArgumentOutOfRangeException(
        String.Format("Index must be from {0} to {1}.", lBound, uBound))

        Else
            'create an array 1 element less than the input array
            Dim outArr(arrLen - 1) As T
            'copy the first part of the input array
            Array.Copy(arr, 0, outArr, 0, index)
            'then copy the second part of the input array
            Array.Copy(arr, index + 1, outArr, index, uBound - index)

            arr = outArr
        End If
    End Sub
End Module
