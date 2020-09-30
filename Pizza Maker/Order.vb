Public Class Order
    'Class used to store information about each order

    Dim starterIndex, pizzaIndex As Integer
    Dim toppingsIndexes As Integer()
    Dim price As Decimal

    Public Sub New(starterIndex As Integer, pizzaIndex As Integer, toppingsIndexes As Integer(), price As Decimal)
        Me.starterIndex = starterIndex
        Me.pizzaIndex = pizzaIndex
        Me.toppingsIndexes = toppingsIndexes
        Me.price = price
    End Sub

    Public Function getStarterIndex()
        Return starterIndex
    End Function

    Public Function getPrice()
        Return price
    End Function

    Public Function getPizzaIndex()
        Return pizzaIndex
    End Function

    Public Function getToppingsIndexes()
        Return toppingsIndexes
    End Function
End Class
