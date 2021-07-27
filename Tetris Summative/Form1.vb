Public Class frmTetris 'made by Daniel Xiao; ICS2O summative 2018-19
    Const MaxValue As Integer = 8
    Dim g As Graphics
    Dim rand As New Random
    Dim gameSpeed As Integer = 500
    Dim posArray(21, 9) As Integer
    Dim colArray(21, 9) As Char
    Dim spawn As Boolean = False
    Dim active As Char
    Dim state As Char
    Dim initialSpawn(6) As Integer
    Dim pieceQueue(6) As Integer
    Dim spawnCount As Integer = 0
    Dim gridX As Integer = 100
    Dim gridY As Integer = 50
    Dim gridScalar As Integer = 21
    Dim held As Integer = Nothing
    Dim isHoldable As Boolean = True
    Dim isDropped As Boolean = False
    Dim linesCleared As Integer = 0
    Dim isHardDrop As Boolean = False
    'everything above this comment deals with gameplay mechanisms, everything below deals with unique gamemodes and themes.
    Dim gameMode As Char = Nothing
    Dim score As Integer = 0
    Dim level As Integer = 0
    Dim lines As Integer = 0
    Dim goalLine As Integer = 0

    Private Sub frmTetris_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        g = Me.CreateGraphics()
        tmrGame.Interval = gameSpeed
        For y = 0 To 21 'resets array
            For x = 0 To 9
                posArray(y, x) = 0
                colArray(y, x) = ""
            Next
        Next
    End Sub

    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        GameModeInitialize() 'sets gamemode (see method for details)
        lblTitle.Visible = False
        lblCount.Text = " "
        btnStart.Visible = False
        btnHelp.Visible = False
        g.DrawRectangle(Pens.Gray, gridX + 1, gridY + 1, 208, 418)
        lblCount.Location = New Point(gridX + 69, gridY + 175)
        Bag7() 'initial spawner (unique 7 pieces in first 7 blocks)
        tmrCountDwn.Start() 'starts countdown to game start.
    End Sub

    Private Sub NextPiece()
        Dim nextMino As Integer
        For y = 0 To 21 'clears any instance of a "loose block" (bug fixer)
            For x = 0 To 9
                If posArray(y, x) = 1 Then
                    posArray(y, x) = 0
                End If
            Next
        Next
        nextMino = pieceQueue(0) 'picks piece to spawn based on array
        Select Case nextMino
            Case 1
                SpawnI()
            Case 2
                SpawnT()
            Case 3
                SpawnO()
            Case 4
                SpawnS()
            Case 5
                SpawnZ()
            Case 6
                SpawnL()
            Case 7
                SpawnJ()
        End Select
        For i = 0 To 5
            pieceQueue(i) = pieceQueue(i + 1) 'shifts elements in array down 1 index
        Next
        pieceQueue(6) = rand.Next(1, 8) 'random next piece
        For i = 0 To 6
            Console.Write(pieceQueue(i).ToString + ",")
        Next
        Console.WriteLine()
        RefreshQueueUI() 'refresh next (see method for details)
        spawnCount += 1
    End Sub

    Private Sub Bag7()
        Dim bypass As Boolean = False
        Do 'generates first 7 pieces (unique)
            For i = 0 To initialSpawn.Length() - 1
                initialSpawn(i) = 0
            Next
            If bypass = False Then
                bypass = True
            End If
            For i = 0 To initialSpawn.Length() - 1
                initialSpawn(rand.Next(0, initialSpawn.Length())) = i + 1
            Next
            For i = 0 To initialSpawn.Length() - 1
                If initialSpawn(i) = 0 Then
                    bypass = False
                End If
            Next
        Loop Until bypass = True
        For i = 0 To 6
            pieceQueue(i) = initialSpawn(i)
        Next
    End Sub

    Private Sub HoldPiece()
        Dim placeHold As Integer = Nothing
        If isHoldable Then
            If held <> Nothing Then 'if nothing is held, remove piece from playing field and spawn next
                placeHold = held
                HolderHelp()
                For y = 21 To 0 Step -1
                    For x = 0 To 9
                        If posArray(y, x) = 1 Then
                            posArray(y, x) = 0
                        End If
                    Next
                Next
                Select Case placeHold
                    Case 1
                        SpawnI()
                    Case 2
                        SpawnT()
                    Case 3
                        SpawnO()
                    Case 4
                        SpawnS()
                    Case 5
                        SpawnZ()
                    Case 6
                        SpawnL()
                    Case 7
                        SpawnJ()
                End Select
                UIRefresh()
            Else ' if something is held, then replace the held item with the current block in the playing field and spawn the previously held block.
                HolderHelp()
                NextPiece()
            End If
            isHoldable = False
        End If
    End Sub
    Private Sub HolderHelp()
        If active = "I" Then
            held = 1
        ElseIf active = "T" Then
            held = 2
        ElseIf active = "O" Then
            held = 3
        ElseIf active = "S" Then
            held = 4
        ElseIf active = "Z" Then
            held = 5
        ElseIf active = "L" Then
            held = 6
        ElseIf active = "J" Then
            held = 7
        End If
    End Sub

    Private Sub RefreshQueueUI()
        g.FillRectangle(Brushes.LightGray, gridX + 210, gridY + 30, 80, 370)
        g.DrawRectangle(Pens.Gray, gridX + 210, gridY + 30, 80, 370)
        Dim xClear As Integer = gridX + 235
        For i = 0 To 5
            If pieceQueue(i) = 1 Then
                DrawI(xClear, 110 + 55 * i)
            ElseIf pieceQueue(i) = 2 Then
                DrawT(xClear, 110 + 55 * i)
            ElseIf pieceQueue(i) = 3 Then
                DrawO(xClear, 110 + 55 * i)
            ElseIf pieceQueue(i) = 4 Then
                DrawS(xClear, 110 + 55 * i)
            ElseIf pieceQueue(i) = 5 Then
                DrawZ(xClear, 110 + 55 * i)
            ElseIf pieceQueue(i) = 6 Then
                DrawL(xClear, 110 + 55 * i)
            ElseIf pieceQueue(i) = 7 Then
                DrawJ(xClear, 110 + 55 * i)
            End If
        Next
        Select Case held
            Case 1
                DrawI(gridX - 65, gridY + 40)
            Case 2
                DrawT(gridX - 65, gridY + 40)
            Case 3
                DrawO(gridX - 65, gridY + 40)
            Case 4
                DrawS(gridX - 65, gridY + 40)
            Case 5
                DrawZ(gridX - 65, gridY + 40)
            Case 6
                DrawL(gridX - 65, gridY + 40)
            Case 7
                DrawJ(gridX - 65, gridY + 40)
        End Select
    End Sub

    'draw methods for next queue display, as well as the "Hold"
    Private Sub DrawI(x, y)
        For i = 0 To 45 Step 15
            g.FillRectangle(Brushes.Turquoise, x + i - 10, y, 15, 15)
        Next
        For i = 0 To 45 Step 15
            g.DrawRectangle(Pens.Gray, x + i - 10, y, 15, 15)
        Next
    End Sub
    Private Sub DrawT(x, y)
        g.FillRectangle(Brushes.Purple, x, y, 15, 15)
        g.FillRectangle(Brushes.Purple, x - 15, y, 15, 15)
        g.FillRectangle(Brushes.Purple, x + 15, y, 15, 15)
        g.FillRectangle(Brushes.Purple, x, y - 15, 15, 15)
        g.DrawRectangle(Pens.Gray, x, y, 15, 15)
        g.DrawRectangle(Pens.Gray, x - 15, y, 15, 15)
        g.DrawRectangle(Pens.Gray, x + 15, y, 15, 15)
        g.DrawRectangle(Pens.Gray, x, y - 15, 15, 15)
    End Sub
    Private Sub DrawO(x, y)
        g.FillRectangle(Brushes.Yellow, x, y, 15, 15)
        g.FillRectangle(Brushes.Yellow, x + 15, y, 15, 15)
        g.FillRectangle(Brushes.Yellow, x, y + 15, 15, 15)
        g.FillRectangle(Brushes.Yellow, x + 15, y + 15, 15, 15)
        g.DrawRectangle(Pens.Gray, x, y, 15, 15)
        g.DrawRectangle(Pens.Gray, x + 15, y, 15, 15)
        g.DrawRectangle(Pens.Gray, x, y + 15, 15, 15)
        g.DrawRectangle(Pens.Gray, x + 15, y + 15, 15, 15)
    End Sub
    Private Sub DrawS(x, y)
        g.FillRectangle(Brushes.LightGreen, x, y, 15, 15)
        g.FillRectangle(Brushes.LightGreen, x - 15, y, 15, 15)
        g.FillRectangle(Brushes.LightGreen, x + 15, y - 15, 15, 15)
        g.FillRectangle(Brushes.LightGreen, x, y - 15, 15, 15)
        g.DrawRectangle(Pens.Gray, x, y, 15, 15)
        g.DrawRectangle(Pens.Gray, x - 15, y, 15, 15)
        g.DrawRectangle(Pens.Gray, x + 15, y - 15, 15, 15)
        g.DrawRectangle(Pens.Gray, x, y - 15, 15, 15)
    End Sub
    Private Sub DrawZ(x, y)
        g.FillRectangle(Brushes.Red, x, y, 15, 15)
        g.FillRectangle(Brushes.Red, x + 15, y, 15, 15)
        g.FillRectangle(Brushes.Red, x, y - 15, 15, 15)
        g.FillRectangle(Brushes.Red, x - 15, y - 15, 15, 15)
        g.DrawRectangle(Pens.Gray, x, y, 15, 15)
        g.DrawRectangle(Pens.Gray, x + 15, y, 15, 15)
        g.DrawRectangle(Pens.Gray, x, y - 15, 15, 15)
        g.DrawRectangle(Pens.Gray, x - 15, y - 15, 15, 15)
    End Sub
    Private Sub DrawJ(x, y)
        g.FillRectangle(Brushes.Blue, x + 5, y, 15, 15)
        g.FillRectangle(Brushes.Blue, x + 5, y - 15, 15, 15)
        g.FillRectangle(Brushes.Blue, x + 5, y + 15, 15, 15)
        g.FillRectangle(Brushes.Blue, x - 10, y + 15, 15, 15)
        g.DrawRectangle(Pens.Gray, x + 5, y, 15, 15)
        g.DrawRectangle(Pens.Gray, x + 5, y - 15, 15, 15)
        g.DrawRectangle(Pens.Gray, x + 5, y + 15, 15, 15)
        g.DrawRectangle(Pens.Gray, x - 10, y + 15, 15, 15)
    End Sub
    Private Sub DrawL(x, y)
        g.FillRectangle(Brushes.Orange, x - 5, y - 15, 15, 15)
        g.FillRectangle(Brushes.Orange, x - 5, y + 15, 15, 15)
        g.FillRectangle(Brushes.Orange, x + 10, y + 15, 15, 15)
        g.FillRectangle(Brushes.Orange, x - 5, y, 15, 15)
        g.DrawRectangle(Pens.Gray, x - 5, y - 15, 15, 15)
        g.DrawRectangle(Pens.Gray, x - 5, y + 15, 15, 15)
        g.DrawRectangle(Pens.Gray, x + 10, y + 15, 15, 15)
        g.DrawRectangle(Pens.Gray, x - 5, y, 15, 15)
    End Sub
    Private Sub HardDrop()
        isHardDrop = True
        Do Until isDropped
            MoveDown()
        Loop
        isHardDrop = False
    End Sub

    Private Sub ShuffleBoard() 'for survival mode. shuffles the board every level passes.
        Dim hiY As Integer = 21
        Dim temp As Integer = 21
        Dim remStore As Integer = 0
        For x = 0 To 9
            For y = 0 To 21
                If posArray(y, x) = 2 Then
                    temp = y
                    Exit For
                End If
            Next
            If temp < hiY Then
                hiY = temp
            End If
        Next
        Console.WriteLine(hiY)
        For x = 0 To 9
            For y = hiY To 21
                remStore = rand.Next(1, 5)
                If remStore = 1 Then
                    posArray(y, x) = 0
                ElseIf remStore = 2 Then
                    remStore = rand.Next(1, 8)
                    posArray(y, x) = 2
                    Select Case remStore
                        Case 1
                            colArray(y, x) = "T"
                        Case 2
                            colArray(y, x) = "O"
                        Case 3
                            colArray(y, x) = "L"
                        Case 4
                            colArray(y, x) = "J"
                        Case 5
                            colArray(y, x) = "S"
                        Case 6
                            colArray(y, x) = "Z"
                        Case 7
                            colArray(y, x) = "I"
                    End Select

                End If
            Next
        Next
        UIRefresh()
    End Sub

    Private Sub LineClearCheck()
        linesCleared = 0
        Dim clears As Boolean = False
        Dim bypass As Boolean = False
        For y = 21 To 2 Step -1
            If posArray(y, 0) = 2 And posArray(y, 1) = 2 And posArray(y, 2) = 2 And posArray(y, 3) = 2 And posArray(y, 4) = 2 And posArray(y, 5) = 2 And posArray(y, 6) = 2 And posArray(y, 7) = 2 And posArray(y, 8) = 2 And posArray(y, 9) = 2 Then
                For i = 0 To 9 'when the line is found that is full, its cleared.
                    posArray(y, i) = 0
                Next
                clears = True
                linesCleared += 1
            End If
        Next
        If linesCleared > 0 Then 'checks for more than one line clear that isn't directly on top of one another.
            For j = 1 To 4
                For y = 21 To 1 Step -1
                    If posArray(y, 0) = 0 And posArray(y, 1) = 0 And posArray(y, 2) = 0 And posArray(y, 3) = 0 And posArray(y, 4) = 0 And posArray(y, 5) = 0 And posArray(y, 6) = 0 And posArray(y, 7) = 0 And posArray(y, 8) = 0 And posArray(y, 9) = 0 Then
                        For i = y To 1 Step -1
                            For x = 0 To 9
                                If posArray(i - 1, x) = 2 Then
                                    posArray(i, x) = posArray(i - 1, x)
                                    posArray(i - 1, x) = 0
                                    colArray(i, x) = colArray(i - 1, x)
                                    colArray(i - 1, x) = ""
                                End If
                            Next
                        Next
                    End If
                Next
            Next
        End If
        lines += linesCleared
        goalLine -= linesCleared
        UIRefresh()
        If gameMode <> "S" Then 'scoring for different modes.
            If gameMode = "C" Then
                Select Case linesCleared
                    Case 1
                        score += 100
                    Case 2
                        score += 300
                    Case 3
                        score += 500
                    Case 4
                        score += 1000
                End Select
            Else
                Select Case linesCleared
                    Case 1
                        score += 100 * level
                    Case 2
                        score += 300 * level
                    Case 3
                        score += 500 * level
                    Case 4
                        score += 1000 * level
                End Select
            End If
            If goalLine <= 0 Then 'tells game when to level up, or when game is complete (for certain modes).
                If level < 10 Then
                    gameSpeed -= 50
                    If gameMode = "V" Then
                        ShuffleBoard()
                    End If
                    level += 1
                    If gameMode = "C" Then
                        goalLine = 25
                    Else
                        goalLine = 10
                    End If
                    lblLevel.Text = level.ToString
                Else
                    If gameMode <> "E" Then
                        GameOver()
                        lblCount.Text = "Complete!"
                    Else
                        lblLevel.Text = "∞"
                        gameSpeed = 5
                    End If
                End If
            End If
        Else
            If goalLine <= 0 Then
                GameOver()
                lblCount.Text = "Complete!"
            End If
        End If
        tmrGame.Stop()
        tmrGame.Interval = gameSpeed
        tmrGame.Start()
        If gameMode <> "S" Then
            lblScore.Text = score.ToString
            lblGoal.Text = goalLine.ToString
        End If
    End Sub

    Private Sub DeathCheck()
        If posArray(2, 0) = 2 Or posArray(2, 1) = 2 Or posArray(2, 2) = 2 Or posArray(2, 3) = 2 Or posArray(2, 4) = 2 Or posArray(2, 5) = 2 Or posArray(2, 6) = 2 Or posArray(2, 7) = 2 Or posArray(2, 8) = 2 Or posArray(2, 9) = 2 Then
            GameOver()
        End If
    End Sub

    Private Sub GameOver()
        tmrGame.Stop()
        For y = 21 To 2 Step -1 'makes the blocks on the screen grey from the bottom up.
            For x = 0 To 9
                If posArray(y, x) = 2 Then
                    g.FillRectangle(Brushes.LightGray, x * gridScalar + gridX, (y - 2) * gridScalar + gridY, 20, 20)
                ElseIf posArray(y, x) = 1 Then
                    posArray(y, x) = 0
                End If
            Next
            System.Threading.Thread.Sleep(10)
        Next
        lblCount.Font = New Font("Arial", 12, FontStyle.Bold) 'used countdown timer to put endgame messages..
        lblCount.Location = New Point(gridX + 60, gridY + 200)
        lblCount.Text = "Game Over"
        tmrSprint.Stop()
        tmrOver.Start()
    End Sub

    Private Sub ActiveRefresh() 'refreshes colors for active pieces (UIRefresh() is the method that refreshes everything).
        For y = 2 To 21
            For x = 0 To 9
                If posArray(y, x) = 1 Then
                    If active = "I" Then
                        g.FillRectangle(Brushes.Turquoise, x * gridScalar + gridX, (y - 2) * gridScalar + gridY, 20, 20)
                    ElseIf active = "T" Then
                        g.FillRectangle(Brushes.Purple, x * gridScalar + gridX, (y - 2) * gridScalar + gridY, 20, 20)
                    ElseIf active = "O" Then
                        g.FillRectangle(Brushes.Yellow, x * gridScalar + gridX, (y - 2) * gridScalar + gridY, 20, 20)
                    ElseIf active = "S" Then
                        g.FillRectangle(Brushes.LightGreen, x * gridScalar + gridX, (y - 2) * gridScalar + gridY, 20, 20)
                    ElseIf active = "Z" Then
                        g.FillRectangle(Brushes.Red, x * gridScalar + gridX, (y - 2) * gridScalar + gridY, 20, 20)
                    ElseIf active = "L" Then
                        g.FillRectangle(Brushes.Orange, x * gridScalar + gridX, (y - 2) * gridScalar + gridY, 20, 20)
                    ElseIf active = "J" Then
                        g.FillRectangle(Brushes.Blue, x * gridScalar + gridX, (y - 2) * gridScalar + gridY, 20, 20)
                    End If
                ElseIf posArray(y, x) = 0 Then
                    g.FillRectangle(Brushes.LightGray, x * gridScalar + gridX, (y - 2) * gridScalar + gridY, 20, 20)
                End If
            Next
        Next
        'FixPosArray()
    End Sub

    Private Sub UIRefresh() 'refreshes all graphics. active refresh exists to make the program refresh faster.
        For y = 2 To 21
            For x = 0 To 9
                If posArray(y, x) = 2 Then
                    If colArray(y, x) = "I" Then
                        g.FillRectangle(Brushes.Turquoise, x * gridScalar + gridX, (y - 2) * gridScalar + gridY, 20, 20)
                    ElseIf colArray(y, x) = "T" Then
                        g.FillRectangle(Brushes.Purple, x * gridScalar + gridX, (y - 2) * gridScalar + gridY, 20, 20)
                    ElseIf colArray(y, x) = "O" Then
                        g.FillRectangle(Brushes.Yellow, x * gridScalar + gridX, (y - 2) * gridScalar + gridY, 20, 20)
                    ElseIf colArray(y, x) = "S" Then
                        g.FillRectangle(Brushes.LightGreen, x * gridScalar + gridX, (y - 2) * gridScalar + gridY, 20, 20)
                    ElseIf colArray(y, x) = "Z" Then
                        g.FillRectangle(Brushes.Red, x * gridScalar + gridX, (y - 2) * gridScalar + gridY, 20, 20)
                    ElseIf colArray(y, x) = "L" Then
                        g.FillRectangle(Brushes.Orange, x * gridScalar + gridX, (y - 2) * gridScalar + gridY, 20, 20)
                    ElseIf colArray(y, x) = "J" Then
                        g.FillRectangle(Brushes.Blue, x * gridScalar + gridX, (y - 2) * gridScalar + gridY, 20, 20)
                    End If
                ElseIf posArray(y, x) = 0 Then
                    g.FillRectangle(Brushes.LightGray, x * gridScalar + gridX, (y - 2) * gridScalar + gridY, 20, 20)
                End If

            Next
        Next

    End Sub

    Private Sub SpawnI()
        active = "I"
        state = "A"
        For i = 3 To 6
            posArray(1, i) = 1
        Next
    End Sub
    Private Sub SpawnT()
        active = "T"
        state = "A"
        posArray(0, 4) = 1
        For i = 3 To 5
            posArray(1, i) = 1
        Next
    End Sub
    Private Sub SpawnO()
        active = "O"
        state = "A"
        posArray(0, 4) = 1
        posArray(0, 5) = 1
        posArray(1, 5) = 1
        posArray(1, 4) = 1
    End Sub
    Private Sub SpawnS()
        active = "S"
        state = "A"
        posArray(0, 4) = 1
        posArray(0, 5) = 1
        posArray(1, 3) = 1
        posArray(1, 4) = 1
    End Sub
    Private Sub SpawnZ()
        active = "Z"
        state = "A"
        posArray(0, 3) = 1
        posArray(0, 4) = 1
        posArray(1, 4) = 1
        posArray(1, 5) = 1
    End Sub
    Private Sub SpawnL()
        active = "L"
        state = "A"
        posArray(0, 5) = 1
        posArray(1, 5) = 1
        posArray(1, 3) = 1
        posArray(1, 4) = 1
    End Sub
    Private Sub SpawnJ()
        active = "J"
        state = "A"
        posArray(0, 3) = 1
        posArray(1, 5) = 1
        posArray(1, 3) = 1
        posArray(1, 4) = 1
    End Sub

    Private Sub ColAssign(y As Integer, x As Integer)
        If active = "I" Then
            colArray(y, x) = "I"
        ElseIf active = "T" Then
            colArray(y, x) = "T"
        ElseIf active = "O" Then
            colArray(y, x) = "O"
        ElseIf active = "S" Then
            colArray(y, x) = "S"
        ElseIf active = "Z" Then
            colArray(y, x) = "Z"
        ElseIf active = "L" Then
            colArray(y, x) = "L"
        ElseIf active = "J" Then
            colArray(y, x) = "J"
        End If
    End Sub

    Private Sub MoveDown()
        Dim exitfor As Boolean = False
        Dim moves As Boolean = True
        For y = 21 To 0 Step -1
            For x = 0 To 9
                If posArray(y, x) = 1 Then
                    If y <> 21 Then
                        If posArray(y + 1, x) = 2 Then
                            moves = False
                        End If
                    Else
                        moves = False
                    End If
                End If
            Next
        Next
        For y = 21 To 0 Step -1
            For x = 0 To 9
                If moves Then
                    If posArray(y, x) = 1 Then
                        posArray(y + 1, x) = 1
                        posArray(y, x) = 0
                    End If
                Else
                    If posArray(y, x) = 1 Then
                        ColAssign(y, x)
                        posArray(y, x) = 2
                    End If
                End If
            Next
        Next
        If moves = False Then
            isDropped = True
            isHoldable = True
            UIRefresh()
            NextPiece()
        End If
    End Sub

    Private Sub GameModeInitialize() 'puts in the initial settings for the gamemodes.
        lblScore.Text = score.ToString
        gbxStats.Visible = True
        level = 1
        goalLine = 10
        If radClassic.Checked Then
            gameMode = "C"
            lblMode.Text = "Classic"
            goalLine = 25
        ElseIf radMarathon.Checked Then
            gameMode = "M"
            lblMode.Text = "Marathon"
        ElseIf radSprint.Checked Then
            gameMode = "S"
            lblScoreText.Text = "Timer:"
            lblLevelText.Text = ""
            lblMode.Text = "Sprint"
            level = 0
            goalLine = 40
        ElseIf radSurvival.Checked Then
            gameMode = "V"
            lblMode.Text = "Survival"
        ElseIf radEndless.Checked Then
            gameMode = "E"
            lblMode.Text = "Endless"
        End If
        lblGoal.Text = goalLine.ToString
        If gameMode <> "S" Then
            lblLevel.Text = level.ToString
        End If
        gbxMode.Visible = False
    End Sub

    Private Sub gamePause()
        tmrCountDwn.Stop()
        If gameMode <> "S" Then
            tmrGame.Stop()
        Else
            tmrGame.Stop()
            tmrSprint.Stop()
        End If
        g.FillRectangle(Brushes.Gray, gridX - 1, gridY - 1, 211, 421)
        For y = 2 To 21
            For x = 0 To 9
                If posArray(y, x) <> 0 Then
                    g.FillRectangle(Brushes.LightGray, x * gridScalar + gridX, (y - 2) * gridScalar + gridY, 20, 20)
                End If
            Next
        Next
        btnExit.Visible = True
        btnQuit.Visible = True
        btnResume.Visible = True
    End Sub

    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Dim exitfor As Boolean = False
        If lblCount.Text = Nothing And gameMode <> Nothing Then
            If e.KeyCode = Keys.C Then 'c is pressed to hold a piece
                e.SuppressKeyPress = True
                If gameMode <> "C" Then
                    HoldPiece()
                    Console.WriteLine(held)
                    g.FillRectangle(Brushes.LightGray, gridX - 81, gridY + 20, 80, 80)
                    g.DrawRectangle(Pens.Gray, gridX - 81, gridY + 20, 80, 80)
                    Select Case held 'draws pieces in the holder box on the interface.
                        Case 1
                            DrawI(gridX - 65, gridY + 40)
                        Case 2
                            DrawT(gridX - 65, gridY + 40)
                        Case 3
                            DrawO(gridX - 65, gridY + 40)
                        Case 4
                            DrawS(gridX - 65, gridY + 40)
                        Case 5
                            DrawZ(gridX - 65, gridY + 40)
                        Case 6
                            DrawL(gridX - 65, gridY + 40)
                        Case 7
                            DrawJ(gridX - 65, gridY + 40)
                    End Select
                End If
            End If

            If e.KeyCode = Keys.Right Then 'move right.
                e.SuppressKeyPress = True
                Dim moveR As Boolean = True
                For y = 0 To 21 'scans game for active piece and shifts all indexes in array with value 1 right by one unit until right wall reached.
                    For x = 9 To 0 Step -1
                        If posArray(y, x) = 1 Then
                            If x = 9 Then
                                moveR = False
                                exitfor = True
                            Else
                                If posArray(y, x + 1) = 2 Then
                                    moveR = False
                                    exitfor = True
                                End If
                            End If
                        End If
                        If exitfor Then
                            Exit For
                        End If
                    Next
                    If exitfor = True Then
                        exitfor = False
                        Exit For
                    End If
                Next
                If moveR = True Then
                    For y = 0 To 21
                        For x = 9 To 0 Step -1
                            If posArray(y, x) = 1 Then
                                posArray(y, x) = 0
                                posArray(y, x + 1) = 1
                            End If
                        Next
                    Next
                End If
                ActiveRefresh()
            End If
            If e.KeyCode = Keys.Left Then 'works same as right, but left..
                e.SuppressKeyPress = True
                Dim moveL As Boolean = True
                For y = 0 To 21
                    For x = 0 To 9
                        If posArray(y, x) = 1 Then
                            If x = 0 Then
                                moveL = False
                                exitfor = True
                            Else
                                If posArray(y, x - 1) = 2 Then
                                    moveL = False
                                    exitfor = True
                                End If
                            End If
                        End If
                        If exitfor = True Then
                            Exit For
                        End If
                    Next
                    If exitfor = True Then
                        exitfor = False
                        Exit For
                    End If
                Next
                If moveL = True Then
                    For y = 0 To 21
                        For x = 0 To 9
                            If posArray(y, x) = 1 Then
                                posArray(y, x) = 0
                                posArray(y, x - 1) = 1
                            End If
                        Next
                    Next
                End If
                ActiveRefresh()
            End If

            If e.KeyCode = Keys.X Then 'rotates clockwise. searches for piece and rotates if there are spaces available. these spaces are filled in the array, and the old ones that dont overlap are set to 0.
                e.SuppressKeyPress = True
                'there are a lot of combinations..
                If active = "I" Then
                    If state = "D" Then
                        For y = 0 To 18
                            For x = 1 To 7
                                If posArray(y, x) = 1 And posArray(y + 1, x) = 1 And posArray(y + 2, x) = 1 And posArray(y + 3, x) = 1 Then
                                    If posArray(y + 1, x - 1) = 0 And posArray(y + 1, x + 1) = 0 And posArray(y + 1, x + 2) = 0 Then
                                        posArray(y, x) = 0
                                        posArray(y + 2, x) = 0
                                        posArray(y + 3, x) = 0
                                        posArray(y + 1, x + 2) = 1
                                        posArray(y + 1, x - 1) = 1
                                        posArray(y + 1, x + 1) = 1
                                        exitfor = True
                                        Exit For
                                    End If
                                End If
                            Next
                            If exitfor Then
                                exitfor = False
                                Exit For
                            End If
                        Next
                        state = "A"
                    ElseIf state = "C" Then
                        For y = 2 To 20
                            For x = 0 To 6
                                If posArray(y, x) = 1 And posArray(y, x + 1) = 1 And posArray(y, x + 2) = 1 And posArray(y, x + 3) = 1 Then
                                    If posArray(y - 2, x + 1) = 0 And posArray(y - 1, x + 1) = 0 And posArray(y + 1, x + 1) = 0 Then
                                        posArray(y, x) = 0
                                        posArray(y, x + 2) = 0
                                        posArray(y, x + 3) = 0
                                        posArray(y - 1, x + 1) = 1
                                        posArray(y + 1, x + 1) = 1
                                        posArray(y - 2, x + 1) = 1
                                        UIRefresh()
                                        exitfor = True
                                        Exit For
                                    End If
                                End If
                            Next
                            If exitfor = True Then
                                exitfor = False
                                Exit For
                            End If
                        Next
                        state = "D"
                    ElseIf state = "B" Then
                        For y = 0 To 18
                            For x = 2 To 8
                                If posArray(y, x) = 1 And posArray(y + 1, x) = 1 And posArray(y + 2, x) = 1 And posArray(y + 3, x) = 1 Then
                                    If posArray(y + 2, x - 2) = 0 And posArray(y + 2, x - 1) = 0 And posArray(y + 2, x + 1) = 0 Then
                                        posArray(y, x) = 0
                                        posArray(y + 1, x) = 0
                                        posArray(y + 3, x) = 0
                                        posArray(y + 2, x - 2) = 1
                                        posArray(y + 2, x - 1) = 1
                                        posArray(y + 2, x + 1) = 1
                                        exitfor = True
                                        Exit For
                                    End If
                                End If
                            Next
                            If exitfor = True Then
                                exitfor = False
                                Exit For
                            End If
                        Next
                        state = "C"
                    ElseIf state = "A" Then
                        For y = 1 To 19
                            For x = 0 To 6
                                If posArray(y, x) = 1 And posArray(y, x + 1) = 1 And posArray(y, x + 2) = 1 And posArray(y, x + 3) = 1 Then
                                    If posArray(y - 1, x + 2) = 0 And posArray(y + 1, x + 2) = 0 And posArray(y + 2, x + 2) = 0 Then
                                        posArray(y, x) = 0
                                        posArray(y, x + 1) = 0
                                        posArray(y, x + 3) = 0
                                        posArray(y - 1, x + 2) = 1
                                        posArray(y + 1, x + 2) = 1
                                        posArray(y + 2, x + 2) = 1
                                        UIRefresh()
                                        exitfor = True
                                        Exit For
                                    End If
                                End If
                            Next
                            If exitfor = True Then
                                exitfor = False
                                Exit For
                            End If
                        Next
                        state = "B"
                    End If
                ElseIf active = "T" Then
                    If state = "D" Then
                        For y = 1 To 19
                            For x = 1 To 8
                                If posArray(y, x) = 1 And posArray(y - 1, x) = 1 And posArray(y + 1, x) = 1 And posArray(y, x - 1) = 1 Then
                                    If posArray(y, x + 1) = 0 Then
                                        posArray(y, x + 1) = 1
                                        posArray(y + 1, x) = 0
                                        exitfor = True
                                        Exit For
                                    End If
                                End If
                                If exitfor = True Then
                                    exitfor = False
                                    Exit For
                                End If
                            Next
                        Next
                        state = "A"
                    ElseIf state = "C" Then
                        For y = 1 To 19
                            For x = 1 To 8
                                If posArray(y, x) = 1 And posArray(y, x - 1) = 1 And posArray(y + 1, x) = 1 And posArray(y, x + 1) = 1 Then
                                    If posArray(y - 1, x) = 0 Then
                                        posArray(y, x + 1) = 0
                                        posArray(y - 1, x) = 1
                                        exitfor = True
                                        Exit For
                                    End If
                                End If
                                If exitfor = True Then
                                    exitfor = False
                                    Exit For
                                End If
                            Next
                        Next
                        state = "D"
                    ElseIf state = "B" Then
                        For y = 1 To 19
                            For x = 1 To 8
                                If posArray(y, x) = 1 And posArray(y - 1, x) = 1 And posArray(y + 1, x) = 1 And posArray(y, x + 1) = 1 Then
                                    If posArray(y, x - 1) = 0 Then
                                        posArray(y, x - 1) = 1
                                        posArray(y - 1, x) = 0
                                        exitfor = True
                                        Exit For
                                    End If
                                End If
                                If exitfor = True Then
                                    exitfor = False
                                    Exit For
                                End If
                            Next
                        Next
                        state = "C"
                    ElseIf state = "A" Then
                        For y = 1 To 19
                            For x = 1 To 8
                                If posArray(y, x) = 1 And posArray(y, x - 1) = 1 And posArray(y - 1, x) = 1 And posArray(y, x + 1) = 1 Then
                                    If posArray(y + 1, x) = 0 Then
                                        posArray(y, x - 1) = 0
                                        posArray(y + 1, x) = 1
                                        exitfor = True
                                        Exit For
                                    End If
                                End If
                                If exitfor = True Then
                                    exitfor = False
                                    Exit For
                                End If
                            Next
                        Next
                        state = "B"
                    End If
                ElseIf active = "S" Then
                    If state = "D" Then
                        For y = 1 To 19
                            For x = 1 To 8
                                If posArray(y, x) = 1 And posArray(y + 1, x) = 1 And posArray(y, x - 1) = 1 And posArray(y - 1, x - 1) = 1 Then
                                    If posArray(y - 1, x) = 0 And posArray(y - 1, x + 1) = 0 Then
                                        posArray(y + 1, x) = 0
                                        posArray(y - 1, x - 1) = 0
                                        posArray(y - 1, x) = 1
                                        posArray(y - 1, x + 1) = 1
                                        exitfor = True
                                        Exit For
                                    End If
                                End If
                            Next
                            If exitfor = True Then
                                exitfor = False
                                Exit For
                            End If
                        Next
                        state = "A"
                    ElseIf state = "C" Then
                        For y = 1 To 19
                            For x = 1 To 8
                                If posArray(y, x) = 1 And posArray(y + 1, x) = 1 And posArray(y, x + 1) = 1 And posArray(y + 1, x - 1) = 1 Then
                                    If posArray(y - 1, x) = 0 And posArray(y + 1, x + 1) = 0 Then
                                        posArray(y - 1, x) = 1
                                        posArray(y + 1, x + 1) = 1
                                        posArray(y + 1, x) = 0
                                        posArray(y + 1, x - 1) = 0
                                        exitfor = True
                                        Exit For
                                    End If
                                End If
                            Next
                            If exitfor = True Then
                                exitfor = False
                                Exit For
                            End If
                        Next
                        state = "D"
                    ElseIf state = "B" Then
                        For y = 1 To 19
                            For x = 1 To 8
                                If posArray(y, x) = 1 And posArray(y, x + 1) = 1 And posArray(y + 1, x + 1) = 1 And posArray(y - 1, x) = 1 Then
                                    If posArray(y + 1, x) = 0 And posArray(y + 1, x - 1) = 0 Then
                                        posArray(y - 1, x) = 0
                                        posArray(y + 1, x + 1) = 0
                                        posArray(y + 1, x) = 1
                                        posArray(y + 1, x - 1) = 1
                                        exitfor = True
                                        Exit For
                                    End If
                                End If
                            Next
                            If exitfor = True Then
                                exitfor = False
                                Exit For
                            End If
                        Next
                        state = "C"
                    ElseIf state = "A" Then
                        For y = 1 To 19
                            For x = 1 To 8
                                If posArray(y, x) = 1 And posArray(y - 1, x) = 1 And posArray(y, x - 1) = 1 And posArray(y - 1, x + 1) = 1 Then
                                    If posArray(y, x + 1) = 0 And posArray(y + 1, x + 1) = 0 Then
                                        posArray(y, x - 1) = 0
                                        posArray(y - 1, x + 1) = 0
                                        posArray(y + 1, x + 1) = 1
                                        posArray(y, x + 1) = 1
                                        exitfor = True
                                        Exit For
                                    End If
                                End If
                            Next
                            If exitfor = True Then
                                exitfor = False
                                Exit For
                            End If
                        Next
                        state = "B"
                    End If
                ElseIf active = "Z" Then
                    If state = "D" Then
                        For y = 1 To 19
                            For x = 1 To 8
                                If posArray(y, x) = 1 And posArray(y, x - 1) = 1 And posArray(y - 1, x) = 1 And posArray(y + 1, x - 1) = 1 Then
                                    If posArray(y, x + 1) = 0 And posArray(y - 1, x - 1) = 0 Then
                                        posArray(y, x + 1) = 1
                                        posArray(y - 1, x - 1) = 1
                                        posArray(y, x - 1) = 0
                                        posArray(y + 1, x - 1) = 0
                                        exitfor = True
                                        Exit For
                                    End If
                                End If
                            Next
                            If exitfor = True Then
                                exitfor = False
                                Exit For
                            End If
                        Next
                        state = "A"
                    ElseIf state = "C" Then
                        For y = 1 To 10
                            For x = 1 To 8
                                If posArray(y, x) = 1 And posArray(y, x - 1) = 1 And posArray(y + 1, x) = 1 And posArray(y + 1, x + 1) = 1 Then
                                    If posArray(y + 1, x - 1) = 0 And posArray(y - 1, x) = 0 Then
                                        posArray(y + 1, x) = 0
                                        posArray(y + 1, x + 1) = 0
                                        posArray(y - 1, x) = 1
                                        posArray(y + 1, x - 1) = 1
                                        exitfor = True
                                        Exit For
                                    End If
                                End If
                            Next
                            If exitfor = True Then
                                exitfor = False
                                Exit For
                            End If
                        Next
                        state = "D"
                    ElseIf state = "B" Then
                        For y = 1 To 19
                            For x = 1 To 8
                                If posArray(y, x) = 1 And posArray(y + 1, x) = 1 And posArray(y, x + 1) = 1 And posArray(y - 1, x + 1) = 1 Then
                                    If posArray(y, x - 1) = 0 And posArray(y + 1, x + 1) = 0 Then
                                        posArray(y, x - 1) = 1
                                        posArray(y + 1, x + 1) = 1
                                        posArray(y, x + 1) = 0
                                        posArray(y - 1, x + 1) = 0
                                        exitfor = True
                                        Exit For
                                    End If
                                End If
                            Next
                            If exitfor = True Then
                                exitfor = False
                                Exit For
                            End If
                        Next
                        state = "C"
                    ElseIf state = "A" Then
                        For y = 1 To 20
                            For x = 1 To 8
                                If posArray(y, x) = 1 And posArray(y, x + 1) = 1 And posArray(y - 1, x) = 1 And posArray(y - 1, x - 1) = 1 Then
                                    If posArray(y + 1, x) = 0 And posArray(y - 1, x + 1) = 0 Then
                                        posArray(y - 1, x) = 0
                                        posArray(y - 1, x - 1) = 0
                                        posArray(y + 1, x) = 1
                                        posArray(y - 1, x + 1) = 1
                                        exitfor = True
                                        Exit For
                                    End If
                                End If
                            Next
                            If exitfor = True Then
                                exitfor = False
                                Exit For
                            End If
                        Next
                        state = "B"
                    End If
                ElseIf active = "L" Then
                    If state = "D" Then
                        For y = 1 To 19
                            For x = 1 To 8
                                If posArray(y, x) = 1 And posArray(y - 1, x) = 1 And posArray(y + 1, x) = 1 And posArray(y - 1, x - 1) = 1 Then
                                    If posArray(y, x + 1) = 0 And posArray(y, x - 1) = 0 And posArray(y - 1, x + 1) = 0 Then
                                        posArray(y - 1, x) = 0
                                        posArray(y + 1, x) = 0
                                        posArray(y - 1, x - 1) = 0
                                        posArray(y, x - 1) = 1
                                        posArray(y, x + 1) = 1
                                        posArray(y - 1, x + 1) = 1
                                        exitfor = True
                                        Exit For
                                    End If
                                End If
                            Next
                            If exitfor = True Then
                                exitfor = False
                                Exit For
                            End If
                        Next
                        state = "A"
                    ElseIf state = "C" Then
                        For y = 1 To 19
                            For x = 1 To 8
                                If posArray(y, x) = 1 And posArray(y, x - 1) = 1 And posArray(y, x + 1) = 1 And posArray(y + 1, x - 1) = 1 Then
                                    If posArray(y - 1, x) = 0 And posArray(y + 1, x) = 0 And posArray(y - 1, x + 1) = 0 Then
                                        posArray(y - 1, x) = 1
                                        posArray(y + 1, x) = 1
                                        posArray(y - 1, x - 1) = 1
                                        posArray(y, x - 1) = 0
                                        posArray(y, x + 1) = 0
                                        posArray(y + 1, x - 1) = 0
                                        exitfor = True
                                        Exit For
                                    End If
                                End If
                            Next
                            If exitfor = True Then
                                exitfor = False
                                Exit For
                            End If
                        Next
                        state = "D"
                    ElseIf state = "B" Then
                        For y = 1 To 19
                            For x = 1 To 8
                                If posArray(y, x) = 1 And posArray(y + 1, x) = 1 And posArray(y - 1, x) = 1 And posArray(y + 1, x + 1) = 1 Then
                                    If posArray(y, x - 1) = 0 And posArray(y, x + 1) = 0 And posArray(y + 1, x - 1) = 0 Then
                                        posArray(y - 1, x) = 0
                                        posArray(y + 1, x) = 0
                                        posArray(y + 1, x + 1) = 0
                                        posArray(y, x - 1) = 1
                                        posArray(y, x + 1) = 1
                                        posArray(y + 1, x - 1) = 1
                                        exitfor = True
                                        Exit For
                                    End If
                                End If
                            Next
                            If exitfor = True Then
                                exitfor = True
                                Exit For
                            End If
                        Next
                        state = "C"
                    ElseIf state = "A" Then
                        For y = 1 To 19
                            For x = 1 To 8
                                If posArray(y, x) = 1 And posArray(y, x + 1) = 1 And posArray(y, x - 1) = 1 And posArray(y - 1, x + 1) = 1 Then
                                    If posArray(y + 1, x) = 0 And posArray(y + 1, x + 1) = 0 And posArray(y - 1, x) = 0 Then
                                        posArray(y + 1, x) = 1
                                        posArray(y + 1, x + 1) = 1
                                        posArray(y - 1, x) = 1
                                        posArray(y, x - 1) = 0
                                        posArray(y, x + 1) = 0
                                        posArray(y - 1, x + 1) = 0
                                        exitfor = True
                                        Exit For
                                    End If
                                End If
                            Next
                            If exitfor = True Then
                                exitfor = False
                                Exit For
                            End If
                        Next
                        state = "B"
                    End If
                ElseIf active = "J" Then
                    If state = "D" Then
                        For y = 1 To 19
                            For x = 1 To 8
                                If posArray(y, x) = 1 And posArray(y - 1, x) = 1 And posArray(y + 1, x) = 1 And posArray(y + 1, x - 1) = 1 Then
                                    If posArray(y, x + 1) = 0 And posArray(y, x - 1) = 0 And posArray(y - 1, x - 1) = 0 Then
                                        posArray(y + 1, x) = 0
                                        posArray(y - 1, x) = 0
                                        posArray(y + 1, x - 1) = 0
                                        posArray(y, x + 1) = 1
                                        posArray(y, x - 1) = 1
                                        posArray(y - 1, x - 1) = 1
                                        exitfor = True
                                        Exit For
                                    End If
                                End If
                            Next
                            If exitfor = True Then
                                exitfor = False
                                Exit For
                            End If
                        Next
                        state = "A"
                    ElseIf state = "C" Then
                        For y = 1 To 19
                            For x = 1 To 8
                                If posArray(y, x) = 1 And posArray(y, x - 1) = 1 And posArray(y, x + 1) = 1 And posArray(y + 1, x + 1) = 1 Then
                                    If posArray(y + 1, x) = 0 And posArray(y + 1, x - 1) = 0 And posArray(y - 1, x) = 0 Then
                                        posArray(y, x - 1) = 0
                                        posArray(y, x + 1) = 0
                                        posArray(y + 1, x + 1) = 0
                                        posArray(y - 1, x) = 1
                                        posArray(y + 1, x) = 1
                                        posArray(y + 1, x - 1) = 1
                                        exitfor = True
                                        Exit For
                                    End If
                                End If
                            Next
                            If exitfor = True Then
                                exitfor = False
                                Exit For
                            End If
                        Next
                        state = "D"
                    ElseIf state = "B" Then
                        For y = 1 To 19
                            For x = 1 To 8
                                If posArray(y, x) = 1 And posArray(y - 1, x) = 1 And posArray(y + 1, x) = 1 And posArray(y - 1, x + 1) = 1 Then
                                    If posArray(y, x + 1) = 0 And posArray(y, x - 1) = 0 And posArray(y + 1, x + 1) = 0 Then
                                        posArray(y, x + 1) = 1
                                        posArray(y, x - 1) = 1
                                        posArray(y + 1, x + 1) = 1
                                        posArray(y + 1, x) = 0
                                        posArray(y - 1, x) = 0
                                        posArray(y - 1, x + 1) = 0
                                        exitfor = True
                                        Exit For
                                    End If
                                End If
                            Next
                            If exitfor = True Then
                                exitfor = False
                                Exit For
                            End If
                        Next
                        state = "C"
                    ElseIf state = "A" Then
                        For y = 1 To 19
                            For x = 1 To 8
                                If posArray(y, x) = 1 And posArray(y, x - 1) = 1 And posArray(y, x + 1) = 1 And posArray(y - 1, x - 1) = 1 Then
                                    If posArray(y - 1, x) = 0 And posArray(y - 1, x + 1) = 0 And posArray(y + 1, x) = 0 Then
                                        posArray(y, x - 1) = 0
                                        posArray(y, x + 1) = 0
                                        posArray(y - 1, x - 1) = 0
                                        posArray(y + 1, x) = 1
                                        posArray(y - 1, x) = 1
                                        posArray(y - 1, x + 1) = 1
                                        exitfor = True
                                        Exit For
                                    End If
                                End If
                            Next
                            If exitfor = True Then
                                exitfor = False
                                Exit For
                            End If
                        Next
                        state = "B"
                    End If
                End If
                Console.WriteLine(state)
                ActiveRefresh()
            End If

            If e.KeyCode = Keys.Escape Then 'pauses game
                e.SuppressKeyPress = True
                gamePause()

            End If

            If e.KeyCode = Keys.Z Then 'same as X, but the other direction.
                e.SuppressKeyPress = True
                If active = "I" Then
                    If state = "A" Then
                        For y = 0 To 21
                            For x = 0 To 6
                                If posArray(y, x) = 1 And posArray(y, x + 1) = 1 And posArray(y, x + 2) = 1 And posArray(y, x + 3) = 1 Then
                                    If posArray(y - 1, x + 1) = 0 And posArray(y + 1, x + 1) = 0 And posArray(y + 2, x + 1) = 0 Then
                                        posArray(y, x) = 0
                                        posArray(y, x + 2) = 0
                                        posArray(y, x + 3) = 0
                                        posArray(y - 1, x + 1) = 1
                                        posArray(y + 1, x + 1) = 1
                                        posArray(y + 2, x + 1) = 1
                                        exitfor = True
                                        Exit For
                                    End If
                                End If
                            Next
                            If exitfor Then
                                exitfor = False
                                Exit For
                            End If
                        Next
                        state = "D"
                    ElseIf state = "B" Then
                        For y = 0 To 18
                            For x = 0 To 9
                                If posArray(y, x) = 1 And posArray(y + 1, x) = 1 And posArray(y + 2, x) = 1 And posArray(y + 3, x) = 1 Then
                                    If posArray(y + 1, x - 2) = 0 And posArray(y + 1, x - 1) = 0 And posArray(y + 1, x + 1) = 0 Then
                                        posArray(y, x) = 0
                                        posArray(y + 2, x) = 0
                                        posArray(y + 3, x) = 0
                                        posArray(y + 1, x - 2) = 1
                                        posArray(y + 1, x - 1) = 1
                                        posArray(y + 1, x + 1) = 1
                                        exitfor = True
                                        Exit For
                                    End If
                                End If
                            Next
                            If exitfor Then
                                exitfor = False
                                Exit For
                            End If
                        Next
                        state = "A"
                    ElseIf state = "C" Then
                        For y = 0 To 21
                            For x = 0 To 6
                                If posArray(y, x) = 1 And posArray(y, x + 1) = 1 And posArray(y, x + 2) = 1 And posArray(y, x + 3) = 1 Then
                                    If posArray(y - 1, x + 2) = 0 And posArray(y - 2, x + 2) = 0 And posArray(y - 1, x + 2) = 0 Then
                                        posArray(y, x) = 0
                                        posArray(y, x + 1) = 0
                                        posArray(y, x + 3) = 0
                                        posArray(y - 1, x + 2) = 1
                                        posArray(y + 1, x + 2) = 1
                                        posArray(y - 2, x + 2) = 1
                                        exitfor = True
                                        Exit For
                                    End If
                                End If
                            Next
                            If exitfor Then
                                exitfor = False
                                Exit For
                            End If
                        Next
                        state = "B"
                    ElseIf state = "D" Then
                        For x = 0 To 9
                            For y = 0 To 18
                                If posArray(y, x) = 1 And posArray(y + 1, x) = 1 And posArray(y + 2, x) = 1 And posArray(y + 3, x) = 1 Then
                                    If posArray(y + 2, x - 1) = 0 And posArray(y + 2, x + 1) = 0 And posArray(y + 2, x + 2) = 0 Then
                                        posArray(y + 2, x - 1) = 1
                                        posArray(y + 2, x + 1) = 1
                                        posArray(y + 2, x + 2) = 1
                                        posArray(y, x) = 0
                                        posArray(y + 1, x) = 0
                                        posArray(y + 3, x) = 0
                                        exitfor = True
                                        Exit For
                                    End If
                                End If
                            Next
                            If exitfor Then
                                exitfor = False
                                Exit For
                            End If
                        Next
                        state = "C"
                    End If
                ElseIf active = "T" Then
                    If state = "A" Then
                        For y = 1 To 20
                            For x = 1 To 8
                                If posArray(y, x) = 1 And posArray(y - 1, x) = 1 And posArray(y, x - 1) = 1 And posArray(y, x + 1) = 1 Then
                                    If posArray(y + 1, x) = 0 Then
                                        posArray(y + 1, x) = 1
                                        posArray(y, x + 1) = 0
                                        exitfor = True
                                        Exit For
                                    End If
                                End If
                            Next
                            If exitfor Then
                                exitfor = False
                                Exit For
                            End If
                        Next
                        state = "D"
                    ElseIf state = "B" Then
                        For y = 1 To 20
                            For x = 1 To 8
                                If posArray(y, x) = 1 And posArray(y - 1, x) = 1 And posArray(y, x + 1) = 1 And posArray(y + 1, x) = 1 Then
                                    If posArray(y, x - 1) = 0 Then
                                        posArray(y, x - 1) = 1
                                        posArray(y + 1, x) = 0
                                        exitfor = True
                                        Exit For
                                    End If
                                End If
                            Next
                            If exitfor Then
                                exitfor = False
                                Exit For
                            End If
                        Next
                        state = "A"
                    ElseIf state = "C" Then
                        For y = 1 To 20
                            For x = 1 To 8
                                If posArray(y, x) = 1 And posArray(y + 1, x) = 1 And posArray(y, x - 1) = 1 And posArray(y, x + 1) = 1 Then
                                    If posArray(y - 1, x) = 0 Then
                                        posArray(y - 1, x) = 1
                                        posArray(y, x - 1) = 0
                                        exitfor = True
                                        Exit For
                                    End If
                                End If
                            Next
                            If exitfor Then
                                exitfor = False
                                Exit For
                            End If
                        Next
                        state = "B"
                    ElseIf state = "D" Then
                        For y = 1 To 20
                            For x = 1 To 8
                                If posArray(y, x) = 1 And posArray(y - 1, x) = 1 And posArray(y, x - 1) = 1 And posArray(y + 1, x) = 1 Then
                                    If posArray(y, x + 1) = 0 Then
                                        posArray(y, x + 1) = 1
                                        posArray(y - 1, x) = 0
                                        exitfor = True
                                        Exit For
                                    End If
                                End If
                            Next
                            If exitfor Then
                                exitfor = False
                                Exit For
                            End If
                        Next
                        state = "C"
                    End If
                ElseIf active = "S" Then
                    If state = "A" Then
                        For y = 1 To 20
                            For x = 1 To 8
                                If posArray(y, x) = 1 And posArray(y - 1, x) = 1 And posArray(y - 1, x + 1) = 1 And posArray(y, x - 1) = 1 Then
                                    If posArray(y - 1, x - 1) = 0 And posArray(y + 1, x) = 0 Then
                                        posArray(y - 1, x - 1) = 1
                                        posArray(y + 1, x) = 1
                                        posArray(y - 1, x) = 0
                                        posArray(y - 1, x + 1) = 0
                                        exitfor = True
                                        Exit For
                                    End If
                                End If
                            Next
                            If exitfor Then
                                exitfor = False
                                Exit For
                            End If
                        Next
                        state = "D"
                    ElseIf state = "B" Then
                        For y = 1 To 20
                            For x = 1 To 8
                                If posArray(y, x) = 1 And posArray(y, x + 1) = 1 And posArray(y + 1, x + 1) = 1 And posArray(y - 1, x) = 1 Then
                                    If posArray(y, x - 1) = 0 And posArray(y - 1, x + 1) = 0 Then
                                        posArray(y - 1, x + 1) = 1
                                        posArray(y, x - 1) = 1
                                        posArray(y, x + 1) = 0
                                        posArray(y + 1, x + 1) = 0
                                        exitfor = True
                                        Exit For
                                    End If
                                End If
                            Next
                            If exitfor Then
                                exitfor = False
                                Exit For
                            End If
                        Next
                        state = "A"
                    ElseIf state = "C" Then
                        For y = 0 To 20
                            For x = 1 To 8
                                If posArray(y, x) = 1 And posArray(y + 1, x) = 1 And posArray(y + 1, x - 1) = 1 And posArray(y, x + 1) = 1 Then
                                    If posArray(y + 1, x + 1) = 0 And posArray(y - 1, x) = 0 Then
                                        posArray(y + 1, x + 1) = 1
                                        posArray(y - 1, x) = 1
                                        posArray(y + 1, x) = 0
                                        posArray(y + 1, x - 1) = 0
                                        exitfor = True
                                        Exit For
                                    End If
                                End If
                            Next
                            If exitfor Then
                                exitfor = False
                                Exit For
                            End If
                        Next
                        state = "B"
                    ElseIf state = "D" Then
                        For x = 1 To 8
                            For y = 1 To 20
                                If posArray(y, x) = 1 And posArray(y - 1, x - 1) = 1 And posArray(y, x - 1) = 1 And posArray(y + 1, x) = 1 Then
                                    If posArray(y, x + 1) = 0 And posArray(y + 1, x - 1) = 0 Then
                                        posArray(y, x + 1) = 1
                                        posArray(y + 1, x - 1) = 1
                                        posArray(y - 1, x - 1) = 0
                                        posArray(y, x - 1) = 0
                                        exitfor = True
                                        Exit For
                                    End If
                                End If
                            Next
                            If exitfor Then
                                exitfor = False
                                Exit For
                            End If
                        Next
                        state = "C"
                    End If
                ElseIf active = "Z" Then
                    If state = "A" Then
                        For y = 1 To 20
                            For x = 1 To 8
                                If posArray(y, x + 1) = 1 And posArray(y, x) = 1 And posArray(y - 1, x) = 1 And posArray(y - 1, x - 1) = 1 Then
                                    If posArray(y, x - 1) = 0 And posArray(y + 1, x - 1) = 0 Then
                                        posArray(y, x - 1) = 1
                                        posArray(y + 1, x - 1) = 1
                                        posArray(y, x + 1) = 0
                                        posArray(y - 1, x - 1) = 0
                                        exitfor = True
                                        Exit For
                                    End If
                                End If
                            Next
                            If exitfor Then
                                exitfor = False
                                Exit For
                            End If
                        Next
                        state = "D"
                    ElseIf state = "B" Then
                        For y = 1 To 20
                            For x = 1 To 8
                                If posArray(y, x) = 1 And posArray(y, x + 1) = 1 And posArray(y - 1, x + 1) = 1 And posArray(y + 1, x) = 1 Then
                                    If posArray(y - 1, x) = 0 And posArray(y - 1, x - 1) = 0 Then
                                        posArray(y - 1, x) = 1
                                        posArray(y - 1, x - 1) = 1
                                        posArray(y - 1, x + 1) = 0
                                        posArray(y + 1, x) = 0
                                        exitfor = True
                                        Exit For
                                    End If
                                End If
                            Next
                            If exitfor Then
                                exitfor = False
                                Exit For
                            End If
                        Next
                        state = "A"
                    ElseIf state = "C" Then
                        For y = 1 To 20
                            For x = 1 To 8
                                If posArray(y, x) = 1 And posArray(y, x - 1) = 1 And posArray(y + 1, x) = 1 And posArray(y + 1, x + 1) = 1 Then
                                    If posArray(y - 1, x + 1) = 0 And posArray(y, x + 1) = 0 Then
                                        posArray(y - 1, x + 1) = 1
                                        posArray(y, x + 1) = 1
                                        posArray(y + 1, x + 1) = 0
                                        posArray(y, x - 1) = 0
                                        exitfor = True
                                        Exit For
                                    End If
                                End If
                            Next
                            If exitfor Then
                                exitfor = False
                                Exit For
                            End If
                        Next
                        state = "B"
                    ElseIf state = "D" Then
                        For y = 1 To 20
                            For x = 1 To 8
                                If posArray(y, x) = 1 And posArray(y - 1, x) = 1 And posArray(y + 1, x - 1) = 1 And posArray(y, x - 1) = 1 Then
                                    If posArray(y + 1, x) = 0 And posArray(y + 1, x + 1) = 0 Then
                                        posArray(y + 1, x) = 1
                                        posArray(y + 1, x + 1) = 1
                                        posArray(y + 1, x - 1) = 0
                                        posArray(y - 1, x) = 0
                                        exitfor = True
                                        Exit For
                                    End If
                                End If
                            Next
                            If exitfor Then
                                exitfor = False
                                Exit For
                            End If
                        Next
                        state = "C"
                    End If
                ElseIf active = "L" Then
                    If state = "A" Then
                        For y = 1 To 20
                            For x = 1 To 8
                                If posArray(y, x) = 1 And posArray(y - 1, x + 1) = 1 And posArray(y, x - 1) = 1 And posArray(y, x + 1) = 1 Then
                                    If posArray(y - 1, x) = 0 And posArray(y - 1, x - 1) = 0 And posArray(y + 1, x) = 0 Then
                                        posArray(y - 1, x) = 1
                                        posArray(y - 1, x - 1) = 1
                                        posArray(y + 1, x) = 1
                                        posArray(y, x - 1) = 0
                                        posArray(y, x + 1) = 0
                                        posArray(y - 1, x + 1) = 0
                                        exitfor = True
                                        Exit For
                                    End If
                                End If
                            Next
                            If exitfor Then
                                exitfor = False
                                Exit For
                            End If
                        Next
                        state = "D"
                    ElseIf state = "B" Then
                        For y = 1 To 20
                            For x = 1 To 8
                                If posArray(y, x) = 1 And posArray(y - 1, x) = 1 And posArray(y + 1, x) = 1 And posArray(y + 1, x + 1) = 1 Then
                                    If posArray(y, x + 1) = 0 And posArray(y - 1, x + 1) = 0 And posArray(y, x - 1) = 0 Then
                                        posArray(y, x + 1) = 1
                                        posArray(y - 1, x + 1) = 1
                                        posArray(y, x - 1) = 1
                                        posArray(y - 1, x) = 0
                                        posArray(y + 1, x) = 0
                                        posArray(y + 1, x + 1) = 0
                                        exitfor = True
                                        Exit For
                                    End If
                                End If
                            Next
                            If exitfor Then
                                exitfor = True
                                Exit For
                            End If
                        Next
                        state = "A"
                    ElseIf state = "C" Then
                        For y = 1 To 20
                            For x = 1 To 8
                                If posArray(y, x) = 1 And posArray(y + 1, x - 1) = 1 And posArray(y, x - 1) = 1 And posArray(y, x + 1) = 1 Then
                                    If posArray(y + 1, x) = 0 And posArray(y + 1, x + 1) = 0 And posArray(y - 1, x) = 0 Then
                                        posArray(y + 1, x) = 1
                                        posArray(y + 1, x + 1) = 1
                                        posArray(y - 1, x) = 1
                                        posArray(y, x - 1) = 0
                                        posArray(y, x + 1) = 0
                                        posArray(y + 1, x - 1) = 0
                                        exitfor = True
                                        Exit For
                                    End If
                                End If
                            Next
                            If exitfor Then
                                exitfor = False
                                Exit For
                            End If
                        Next
                        state = "B"
                    ElseIf state = "D" Then
                        For y = 1 To 20
                            For x = 1 To 8
                                If posArray(y, x) = 1 And posArray(y - 1, x) = 1 And posArray(y + 1, x) = 1 And posArray(y - 1, x - 1) = 1 Then
                                    If posArray(y, x - 1) = 0 And posArray(y + 1, x - 1) = 0 And posArray(y, x + 1) = 0 Then
                                        posArray(y, x + 1) = 1
                                        posArray(y + 1, x - 1) = 1
                                        posArray(y, x - 1) = 1
                                        posArray(y - 1, x) = 0
                                        posArray(y + 1, x) = 0
                                        posArray(y - 1, x - 1) = 0
                                        exitfor = True
                                        Exit For
                                    End If
                                End If
                            Next
                            If exitfor Then
                                exitfor = True
                                Exit For
                            End If
                        Next
                        state = "C"
                    End If
                ElseIf active = "J" Then
                    If state = "A" Then
                        For y = 1 To 20
                            For x = 1 To 8
                                If posArray(y, x) = 1 And posArray(y, x + 1) = 1 And posArray(y, x - 1) = 1 And posArray(y - 1, x - 1) = 1 Then
                                    If posArray(y + 1, x - 1) = 0 And posArray(y + 1, x) = 0 And posArray(y - 1, x) = 0 Then
                                        posArray(y + 1, x - 1) = 1
                                        posArray(y + 1, x) = 1
                                        posArray(y - 1, x) = 1
                                        posArray(y - 1, x - 1) = 0
                                        posArray(y, x - 1) = 0
                                        posArray(y, x + 1) = 0
                                        exitfor = True
                                        Exit For
                                    End If
                                End If
                            Next
                            If exitfor Then
                                exitfor = False
                                Exit For
                            End If
                        Next
                        state = "D"
                    ElseIf state = "B" Then
                        For y = 1 To 20
                            For x = 1 To 8
                                If posArray(y, x) = 1 And posArray(y - 1, x) = 1 And posArray(y + 1, x) = 1 And posArray(y - 1, x + 1) = 1 Then
                                    If posArray(y, x - 1) = 0 And posArray(y, x + 1) = 0 And posArray(y - 1, x - 1) = 0 Then
                                        posArray(y, x - 1) = 1
                                        posArray(y, x + 1) = 1
                                        posArray(y - 1, x - 1) = 1
                                        posArray(y - 1, x) = 0
                                        posArray(y - 1, x + 1) = 0
                                        posArray(y + 1, x) = 0
                                        exitfor = False
                                        Exit For
                                    End If
                                End If
                            Next
                            If exitfor Then
                                exitfor = False
                                Exit For
                            End If
                        Next
                        state = "A"
                    ElseIf state = "C" Then
                        For y = 1 To 20
                            For x = 1 To 8
                                If posArray(y, x) = 1 And posArray(y, x + 1) = 1 And posArray(y, x - 1) = 1 And posArray(y + 1, x + 1) = 1 Then
                                    If posArray(y - 1, x + 1) = 0 And posArray(y + 1, x) = 0 And posArray(y - 1, x) = 0 Then
                                        posArray(y - 1, x + 1) = 1
                                        posArray(y + 1, x) = 1
                                        posArray(y - 1, x) = 1
                                        posArray(y + 1, x + 1) = 0
                                        posArray(y, x - 1) = 0
                                        posArray(y, x + 1) = 0
                                        exitfor = True
                                        Exit For
                                    End If
                                End If
                            Next
                            If exitfor Then
                                exitfor = False
                                Exit For
                            End If
                        Next
                        state = "B"
                    ElseIf state = "D" Then
                        For y = 1 To 20
                            For x = 1 To 8
                                If posArray(y, x) = 1 And posArray(y - 1, x) = 1 And posArray(y + 1, x) = 1 And posArray(y + 1, x - 1) = 1 Then
                                    If posArray(y, x - 1) = 0 And posArray(y, x + 1) = 0 And posArray(y + 1, x + 1) = 0 Then
                                        posArray(y, x - 1) = 1
                                        posArray(y, x + 1) = 1
                                        posArray(y + 1, x + 1) = 1
                                        posArray(y - 1, x) = 0
                                        posArray(y + 1, x - 1) = 0
                                        posArray(y + 1, x) = 0
                                        exitfor = False
                                        Exit For
                                    End If
                                End If
                            Next
                            If exitfor Then
                                exitfor = False
                                Exit For
                            End If
                        Next
                        state = "C"
                    End If
                End If
                ActiveRefresh()
            End If

            If e.KeyCode = Keys.Down Then 'fast drop
                e.SuppressKeyPress = True
                tmrGame.Interval = 20
                tmrGame.Start()
            End If
        End If

        If e.KeyCode = Keys.Space Then 'hard drop
            e.SuppressKeyPress = True
            If lblCount.Text = Nothing Then
                HardDrop()
            End If
        End If
    End Sub

    Private Sub tmrGame_Tick(sender As Object, e As EventArgs) Handles tmrGame.Tick 'self explainatory
        MoveDown()
        LineClearCheck()
        DeathCheck()
        ActiveRefresh()
        If isDropped Then
            isDropped = False
        End If
    End Sub

    Private Sub Form1_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.Down Then 'reverts back to normal game speed upon release of the up arrow.
            tmrGame.Interval = gameSpeed
            tmrGame.Start()
        End If
    End Sub

    Private Sub tmrCountDwn_Tick(sender As Object, e As EventArgs) Handles tmrCountDwn.Tick
        Static Dim countDwn As Integer = 3
        lblCount.Text = countDwn.ToString
        g.FillRectangle(Brushes.LightGray, gridX + 1, gridY + 1, 208, 418)
        g.DrawRectangle(Pens.Gray, gridX + 1, gridY + 1, 208, 418)
        countDwn -= 1
        If countDwn = -1 Then 'the timer for the starting countdown. when value is -1, game begins (displays as 0 so it works fine).
            lblCount.Text = Nothing
            UIRefresh()
            tmrCountDwn.Stop()
            tmrGame.Start()
            gamePause()
            resumeGame()
            NextPiece()
            If gameMode = "S" Then
                Console.WriteLine("startgam")
                tmrSprint.Start()
            End If
        End If
    End Sub

    Private Sub tmrOver_Tick(sender As Object, e As EventArgs) Handles tmrOver.Tick
        Static Dim increm As Integer = 0
        increm += 1
        If increm = 2 Then
            Dim isHigh As Boolean = False
            tmrOver.Stop()
            tmrGame.Stop()
            tmrCountDwn.Stop()
            Me.Invalidate()
            Console.WriteLine("stopped")
            With Me.gbxStats
                .Location = New Point(40, 40)
                .Size = New System.Drawing.Size(540, 350)
                .Text = "Stats"
            End With
            If gameMode = "S" Then
                lblScoreText.Text = "Time:"
            End If
            lblGoalText.Text = Nothing
            lblGoal.Text = Nothing
            btnQuit.Visible = True
            btnQuit.Text = "Play again"
            btnExit.Visible = True
        End If
    End Sub

    Private Sub tmrSprint_Tick(sender As Object, e As EventArgs) Handles tmrSprint.Tick
        Static Dim timeMs As Integer = 0 'special timer for the sprint game mode
        lblScore.Text = CStr(Format(Math.Floor(timeMs / 6000), "00")) & ":" & CStr(Format((timeMs Mod 6000) / 100, "00")) & ":" & CStr(Format(timeMs Mod 1000 / 10, "00"))
        Console.WriteLine(timeMs)
        score = timeMs
        timeMs += 2
    End Sub

    Private Sub btnResume_Click(sender As Object, e As EventArgs) Handles btnResume.Click
        tmrGame.Start()
        g.FillRectangle(Brushes.Gray, gridX - 1, gridY - 1, 211, 421)
        UIRefresh()
        RefreshQueueUI()
        btnResume.Visible = False
        btnExit.Visible = False
        btnQuit.Visible = False
        If gameMode = "S" Then
            tmrSprint.Start()
        End If
    End Sub

    Private Sub resumeGame()
        tmrGame.Start()
        g.FillRectangle(Brushes.Gray, gridX - 1, gridY - 1, 211, 421)
        UIRefresh()
        RefreshQueueUI()
        btnResume.Visible = False
        btnExit.Visible = False
        btnQuit.Visible = False
    End Sub

    Private Sub btnQuit_Click(sender As Object, e As EventArgs) Handles btnQuit.Click
        Application.Restart() 'restart the game
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Application.Exit() 'close game
    End Sub

    Private Sub btnHelp_Click(sender As Object, e As EventArgs) Handles btnHelp.Click
        FrmHelp.ShowDialog() 'help for game
    End Sub

    Private Sub HowToPlayToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HowToPlayToolStripMenuItem.Click
        FrmHelp.ShowDialog() 'open help page
    End Sub

    Private Sub RetryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RetryToolStripMenuItem.Click
        Application.Restart()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Application.Exit()
    End Sub
End Class
