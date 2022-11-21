Module Module1
    'Jason Klins
    '11/21/2022
    'Sudden Death Battleship


    'This will be used to represent the state of each cell
    Public Enum cellstate
        empty
        miss
        hit
        cmpship
    End Enum

    Public rows As Integer = 4
    Public cols As Integer = 5
    'This 2d array will be used to represent the board
    Public board(rows - 1, cols - 1) As cellstate

    Sub Main()
        Dim gameOver As Boolean = False
        Dim shotCount As Integer = 0
        ResetBoard()
        PlaceComputorShip()
        Do
            shotCount += 1
            PrintBoard()
            Dim row As Integer = GetUserInput("Please enter the row to fire on ->", rows - 1)
            Dim col As Integer = GetUserInput("Please enter the col to fire on ->", cols - 1)
            If board(row, col) = cellstate.cmpship Then
                board(row, col) = cellstate.hit
            Else
                board(row, col) = cellstate.miss
            End If
        Loop While Not gameOver
        PrintBoard()
        Console.WriteLine("You hit it in {0} shots!", shotCount.ToString)
    End Sub

    ''' <summary>
    ''' Sets all cells in the board to cellstate.empty
    ''' </summary>
    Sub ResetBoard()
        'Use nested For loops to populate each value
        'for i = 0 to max row num
        'for j = 0 to max col num
        'Set val to cellstate.empty
        For i As Integer = 0 To board.GetUpperBound(0) ' same as rows - 1
            For j As Integer = 0 To board.GetUpperBound(1) ' same as cols - 1
                board(i, j) = cellstate.empty
            Next
        Next
    End Sub

    ''' <summary>
    ''' Selects a random int from 0 to row -1 and a random int from cols-1 to
    ''' place a computor ship
    ''' </summary>


    Sub PlaceComputorShip()
        Dim rand As New Random
        Dim row As Integer = rand.Next(0, rows)
        Dim cols As Integer = rand.Next(0, cols)
        board(row, cols) = cellstate.cmpship
    End Sub



    Sub PrintBoard()

        'print the top row (column headers)
        Console.Write("  ")
        For row As Integer = 0 To cols - 1
            Console.Write(row & " ")
        Next
        Console.Write(vbNewLine)

        'loop through each row of the board, print the row number and then the column values
        For row As Integer = 0 To board.GetUpperBound(0)
            Console.Write(row & " ")
            For col As Integer = 0 To board.GetUpperBound(1)
                Select Case board(row, col)
                    Case cellstate.empty, cellstate.cmpship
                        Console.Write("- ")
                    Case cellstate.miss
                        Console.ForegroundColor = ConsoleColor.Red
                        Console.Write("x ")
                        Console.ResetColor()
                    Case cellstate.hit
                        Console.ForegroundColor = ConsoleColor.Green
                        Console.Write("H ")
                        Console.ResetColor()
                    Case cellstate.cmpship
                        Console.Write("- ")
                End Select
            Next
            Console.Write(vbNewLine)
        Next
    End Sub

    ''' <summary>
    ''' Repeats the prompt to the user until a number between 0 and max (inclusive) is given
    ''' Return that number
    ''' </summary>
    ''' <param name="prompt"></param>
    ''' <param name="max"></param>
    ''' <returns>An int between 0 and max(inclusive)</returns>
    Function GetUserInput(prompt As String, max As Integer) As Integer
        Dim Valid As Boolean = False
        Dim inputStr As String
        Dim userInput As Integer
        Do
            Console.Write(prompt)
            inputStr = Console.ReadLine
            Valid = Integer.TryParse(inputStr, userInput)
            If Not (Valid AndAlso userInput >= 0 AndAlso userInput <= max) Then
                Valid = False
            End If
            Return userInput
        Loop While Not Valid

    End Function

End Module
