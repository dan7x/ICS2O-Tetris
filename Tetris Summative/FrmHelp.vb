Public Class FrmHelp
    Private Sub btnControls_Click(sender As Object, e As EventArgs) Handles btnControls.Click
        MessageBox.Show("Use the Z key to rotate Counter-Clockwise and X to rotate clockwise.", "Rotations")
        MessageBox.Show("Use the left and right arrow keys to move the piece horizontally.", "Movement")
        MessageBox.Show("Use the Down Arrow to slowly drop a piece, but at a faster rate than game speed.", "Soft Dropping")
        MessageBox.Show("Use the spacebar to instantly drop a piece.", "Hard Dropping")
        MessageBox.Show("Press C to reserve a piece for later. The next piece in the queue will be spawned.", "Holding")
        MessageBox.Show("Fill a whole row to clear it and earn points!", "Line clear")
        MessageBox.Show("Different game modes will have different rules and scoring.", "Game modes")
        MessageBox.Show("Use the Esc. key to pause the game.", "Pausing")
        MessageBox.Show("Have Fun!", ":)")
    End Sub

    Private Sub btnMarathon_Click(sender As Object, e As EventArgs) Handles btnMarathon.Click
        MessageBox.Show("Play through 10 levels to win!", "Marathon Help")
        MessageBox.Show("The number under 'Goal' tells you how many more lines to clear until the next level.", "Goal")
        MessageBox.Show("Tetrises are worth 1000pts, triples are 500, doubles are 300, and singles are 100.", "Marathon Scoring")
        MessageBox.Show("The amount you score each line clear is multiplied by the current level.", "Multiplier")
        MessageBox.Show("Place your pieces wisely..", ":)")
    End Sub

    Private Sub btnEndless_Click(sender As Object, e As EventArgs) Handles btnEndless.Click
        MessageBox.Show("Essentially an endless version of Marathon (see 'Marathon').")
        MessageBox.Show("Reach 2,147,483,647 points to crash the game!", ":O")
    End Sub

    Private Sub btnClassic_Click(sender As Object, e As EventArgs) Handles btnClassic.Click
        MessageBox.Show("The most basic version of Tetris.", "Classic Help")
        MessageBox.Show("Tetrises are worth 1000pts, triples are 500, doubles are 300, and singles are 100.", "Classic Scoring")
        MessageBox.Show("Unlike Marathon, the score is not multiplied by the level.", "Classic Multiplier")
        MessageBox.Show("You cannot hold pieces in Classic mode!", "Holding in Classic")
        MessageBox.Show("25 lines are required to level up, as opposed to 10 in other modes.", "Leveling")
        MessageBox.Show("Can you beat the game without holding pieces?", "(:")
    End Sub

    Private Sub btnSprint_Click(sender As Object, e As EventArgs) Handles btnSprint.Click
        MessageBox.Show("Clear 40 lines as fast as you can!", "Sprint Rules")
        MessageBox.Show("There is no scoring system or levels. Only a timer and a goal.", "Sprint Rules")
        MessageBox.Show("How fast do you think you really are?", ":D")
    End Sub

    Private Sub btnSurvival_Click(sender As Object, e As EventArgs) Handles btnSurvival.Click
        MessageBox.Show("How long can you survive for?", ":d")
    End Sub

    Private Sub FrmHelp_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class