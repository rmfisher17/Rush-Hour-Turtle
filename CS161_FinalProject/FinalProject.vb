'==============================================================================
'Project:           CS161_FinalProject
'Title:             Turtle Turtle
'File Name:         FinalProject.exe, FinalProject.vb, FinalProject.sln
'Date Completed:    3/12/2018
'
'Author:            Winners (Christopher, Melanie, Andy, and Mitch)
'Class:             CS161 Winter 2018
'
'Description:       
'==============================================================================
' Known Bugs:       1. Turtle progress can exceed the river before the final 
'                   part is loaded. Currently turtle is moved back to start of
'                   water. 
'                   2. Turtle does Not change animation When reaching the
'                   the water. 
'                   3. Alligator animation does Not work. 
'                   4. If you don't finish in a reasonable time score could
'                   potential be negative and music could stop playing.
'==============================================================================
Option Explicit On
Option Strict On

Imports System.Drawing.Drawing2D

Public Class FinalProject
    '--------------------------------------------------------------------------
    'Description:   Classwide variable declaration
    '--------------------------------------------------------------------------

    'Background image variables
    Dim graBG As Graphics
    Dim bmpBG As Bitmap = New Bitmap("..\Multimedia\background.png")
    Dim mtxBG As Matrix
    Dim graBuffer As Graphics
    Dim bmpBuffer As Bitmap
    Dim cshtViewWidth As Short
    Dim cshtViewHeight As Short
    Dim cshtBGMoveX As Short = -1
    Dim cshtBGMoveY As Short = 0
    Dim cshtBGY As Short
    Dim cshtBGMovementStart As Short = 50 'Pixel when Background will start moving

    'Sprite variables
    Dim graTurtle As Graphics
    Dim bmpTurtle As Bitmap = New Bitmap("..\Multimedia\turtleAnimation_right.png")
    Dim cshtTurtleX As Short = 50
    Dim cshtTurtleY As Short = 200
    Dim cshtTurtleNumberOfFrames As Short = 9 'Goes w/ sprite Animation Variables
    Dim cshtTurtleW As Short = CShort(bmpTurtle.Width / cshtTurtleNumberOfFrames)
    Dim cshtTurtleH As Short = CShort(bmpTurtle.Height)
    Dim cshtTurtleMoveX As Short = 10
    Dim cshtTurtleMoveY As Short = 10

    'Sprite Animation 
    Dim recCurrentFrame As Rectangle
    Dim cshtFrameX As Short
    Dim cshtFrameY As Short
    Dim cshtAnimatedSpriteLength As Short = CShort(bmpTurtle.Width)

    'Car variables/Images
    Dim bmpCarBlueDown As Bitmap = New Bitmap("..\Multimedia\carbludown.png")
    Dim bmpCarBlueUp As Bitmap = New Bitmap("..\Multimedia\CarBluUp.png")
    Dim bmpCarGreenUp As Bitmap = New Bitmap("..\Multimedia\cargrnup.png")
    Dim bmpCarGreenDown As Bitmap = New Bitmap("..\Multimedia\cargrndown.png")
    Dim bmpCarRedDown As Bitmap = New Bitmap("..\Multimedia\carredDown.png")
    Dim bmpCarRedUp As Bitmap = New Bitmap("..\Multimedia\carredUp.png")

    'Height and Width Same for all cars
    Dim cshtCarW As Short = CShort(bmpCarBlueDown.Width)
    Dim cshtCarH As Short = CShort(bmpCarBlueDown.Height)

    'Lane 1 Variables
    Dim graCar1stLane As Graphics
    Dim mtxCar1stLane As Matrix
    Dim cshtCar1stLane_X As Short = 200 'Drawn in First Lane
    Dim cshtCar1stLane_Y As Short = -100 'Draw Outside the Panel coming down
    Dim cshtMovementEnd1stLane As Short = 100
    Dim cshtCar1stLane_MoveX As Short = 0
    Dim cshtCar1stLane_MoveY As Short = 12

    'Lane 2 Variables
    Dim graCar2ndLane As Graphics
    Dim mtxCar2ndLane As Matrix
    Dim cshtCar2ndLane_X As Short = 250 'Drawn in second lane
    Dim cshtCar2ndLane_Y As Short
    Dim cshtMovementEndCar2ndLane As Short = 150
    Dim cshtCar2ndLane_MoveX As Short = 0
    Dim cshtCar2ndLane_MoveY As Short = -8

    'Lane 3 Variables
    Dim graCar3rdLane As Graphics
    Dim mtxCar3rdLane As Matrix
    Dim cshtCar3rdLane_X As Short = 525
    Dim cshtCar3rdLane_Y As Short = -500
    Dim cshtMovementEndCar3rdLane As Short = 200
    Dim cshtCar3rdLane_MoveX As Short = 0
    Dim cshtCar3rdLane_MoveY As Short = 8

    'Lane 4 Variables
    Dim graCar4thLane As Graphics
    Dim mtxCar4thLane As Matrix
    Dim cshtCar4thLane_X As Short = 600
    Dim cshtCar4thLane_Y As Short = -200
    Dim cshtMovementEndCar4thLane As Short = 200
    Dim cshtCar4thLane_MoveX As Short = 0
    Dim cshtCar4thLane_MoveY As Short = 8

    'Lane 5 Variables
    Dim graCar5thLane As Graphics
    Dim mtxCar5thLane As Matrix
    Dim cshtCar5thLane_X As Short = 725
    Dim cshtCar5thLane_Y As Short = -300
    Dim cshtMovementEndCar5thLane As Short = 200
    Dim cshtCar5thLane_MoveX As Short = 0
    Dim cshtCar5thLane_MoveY As Short = 6

    'water crossing variables
    Dim graAlligator As Graphics
    Dim mtxAlligator As Matrix
    Dim bmpAlligator As Bitmap = New Bitmap("..\Multimedia\alligator_RightTail.png")
    Dim cshtAlligator_X As Short = 120 'Drawn in First Lane
    Dim cshtAlligator_Y As Short = -50 'Draw Outside the Panel coming down
    Dim cshtMovementEndAlligator As Short = 600
    Dim cshtAlligator_MoveX As Short = 0
    Dim cshtAlligator_MoveY As Short = 3
    Dim cshtAlligatorW As Short = CShort(bmpAlligator.Width)
    Dim cshtAlligatorH As Short = CShort(bmpAlligator.Height)

    'Alligator Animation 
    Dim recCurrentAlligatorFrame As Rectangle
    Dim cshtAlligatorFrameX As Short
    Dim cshtAlligatorFrameY As Short
    Dim cshtAlligatorNumberOfFrames As Short = 12
    Dim cshtAnimatedAlligatorLength As Short = CShort(bmpAlligator.Width)

    'Lane 6 Variables
    Dim graCar6thLane As Graphics
    Dim mtxCar6thLane As Matrix
    Dim cshtCar6thLane_X As Short = 350
    Dim cshtCar6thLane_Y As Short = -100
    Dim cshtMovementEndCar6thLane As Short = 150
    Dim cshtCar6thLane_MoveX As Short = 0
    Dim cshtCar6thLane_MoveY As Short = 7

    'Lane 7 Variables
    Dim graCar7thLane As Graphics
    Dim mtxCar7thLane As Matrix
    Dim cshtCar7thLane_X As Short = 500
    Dim cshtCar7thLane_Y As Short = -100
    Dim cshtMovementEndCar7thLane As Short = 125
    Dim cshtCar7thLane_MoveX As Short = 0
    Dim cshtCar7thLane_MoveY As Short = -9

    'Scoring
    Dim intStart As Integer
    Dim intStop As Integer
    Dim intStage1 As Integer
    Dim intStage2 As Integer
    Dim lngScore As Long = 0
    Dim lngHighScore As Long = 0
    Dim bytDeathCounter As Byte
    Const cintLIFE As Integer = 10000
    Const clngMAX_TIME As Long = 1000000

    'Sound
    Dim cstrSongPath As String = Application.StartupPath

    '--------------------------------------------------------------------------
    'Description:   LOAD EVENT
    '--------------------------------------------------------------------------
    Private Sub FinalProject_Load(sender As Object,
                                  e As EventArgs) Handles Me.Load

        frmSplash.ShowSplash()
        Randomize()
        cshtViewWidth = CShort(pnlDisplay.Width)
        cshtViewHeight = CShort(pnlDisplay.Height)

        lblInfo.Text = Chr(13) & "Press start to begin a new game."

        'For drawing and displaying
        graBuffer = pnlDisplay.CreateGraphics
        bmpBuffer = New Bitmap(pnlDisplay.Width, pnlDisplay.Height, graBuffer)

        'Making Colors on our Sprites and Obstacles Transparent
        bmpCarBlueDown.MakeTransparent(Color.FromArgb(255, 0, 0))
        bmpCarBlueUp.MakeTransparent(Color.FromArgb(255, 0, 0))
        bmpCarGreenUp.MakeTransparent(Color.FromArgb(0, 0, 255))
        bmpCarGreenDown.MakeTransparent(Color.FromArgb(0, 0, 255))
        bmpCarRedUp.MakeTransparent(Color.FromArgb(0, 255, 0))
        bmpCarRedDown.MakeTransparent(Color.FromArgb(0, 255, 0))
        bmpTurtle.MakeTransparent(Color.FromArgb(255, 0, 0))
        bmpAlligator.MakeTransparent(Color.FromArgb(0, 0, 255))

        graBG = Graphics.FromImage(bmpBuffer)
        mtxBG = New Matrix(1, 0, 0, 1, cshtBGMoveX, cshtBGMoveY)

        graCar1stLane = Graphics.FromImage(bmpBuffer)
        mtxCar1stLane = New Matrix(1, 0, 0, 1,
                                   cshtCar1stLane_MoveX, cshtCar1stLane_MoveY)

        graCar2ndLane = Graphics.FromImage(bmpBuffer)
        mtxCar2ndLane = New Matrix(1, 0, 0, 1,
                                   cshtCar2ndLane_MoveX, cshtCar2ndLane_MoveY)

        'Determined by Panel Size so we declare value in Load event
        cshtCar2ndLane_Y = CShort(pnlDisplay.Height + 200)

        graCar3rdLane = Graphics.FromImage(bmpBuffer)
        mtxCar3rdLane = New Matrix(1, 0, 0, 1,
                                   cshtCar3rdLane_MoveX, cshtCar3rdLane_MoveY)

        graCar4thLane = Graphics.FromImage(bmpBuffer)
        mtxCar4thLane = New Matrix(1, 0, 0, 1,
                                   cshtCar4thLane_MoveX, cshtCar4thLane_MoveY)

        graCar5thLane = Graphics.FromImage(bmpBuffer)
        mtxCar5thLane = New Matrix(1, 0, 0, 1,
                                   cshtCar5thLane_MoveX, cshtCar5thLane_MoveY)

        graAlligator = Graphics.FromImage(bmpBuffer)
        mtxAlligator = New Matrix(1, 0, 0, 1,
                                   cshtAlligator_MoveX, cshtAlligator_MoveY)

        graCar6thLane = Graphics.FromImage(bmpBuffer)
        mtxCar6thLane = New Matrix(1, 0, 0, 1,
                                   cshtCar6thLane_MoveX, cshtCar6thLane_MoveY)

        graCar7thLane = Graphics.FromImage(bmpBuffer)
        mtxCar7thLane = New Matrix(1, 0, 0, 1,
                                   cshtCar7thLane_MoveX, cshtCar7thLane_MoveY)
        cshtCar7thLane_Y = CShort(pnlDisplay.Height + 300)

        graTurtle = Graphics.FromImage(bmpBuffer)

        cstrSongPath = cstrSongPath.Substring(0, cstrSongPath.Length -
                       "Debug".Length) & "\Multimedia\TMNT.wav"

        wmpPlayer.Visible = False

    End Sub

    '--------------------------------------------------------------------------
    'Description:   COLLISION FUNCTION
    '--------------------------------------------------------------------------
    Private Function fCollision(ByVal intXLocation As Integer,
                     ByVal intObj1X As Integer, ByVal intObj1W As Integer,
                     ByVal intObj2X As Integer, ByVal intObj1Y As Integer,
                     ByVal intObj1H As Integer, ByVal intObj2Y As Integer,
                     ByVal intObj2H As Integer, ByVal intObj2W As Integer,
                     ByVal intDistance As Integer) As Boolean

        Dim blnAnswer = False

        If intObj1X + intObj1W - 10 >= intObj2X - intXLocation And
                intObj1Y + intObj1H >= intObj2Y + intDistance + 20 And
                intObj1Y <= intObj2Y + intObj2H + intDistance - 20 And
                intObj1X <= intObj2X + intObj2W - intXLocation Then


            My.Computer.Audio.Play("..\Multimedia\Squish.wav")
            blnAnswer = True

        End If

        Return blnAnswer

    End Function

    '--------------------------------------------------------------------------
    'Description:   Keeps track of the current player lives remaining displayed
    '               on screen and turns them over to empty shells with each
    '               satisfying splat.
    '--------------------------------------------------------------------------
    Private Sub sDeathCount()

        If lblLife3.Visible = True Then
            lblLife3.Image = Image.FromFile("..\Multimedia\deadSprite.png")
            lblInfo.Text = Chr(13) & "You didn't make it, but you have another life!"
        Else
            If lblLife2.Visible = True Then
                lblLife2.Image = Image.FromFile("..\Multimedia\deadSprite.png")
                lblInfo.Text = Chr(13) & "Oh no! Only one life left!"
            Else
                If lblLife1.Visible = True Then
                    lblLife1.Image = Image.FromFile("..\Multimedia\deadSprite.png")
                    lblInfo.Text = Chr(13) & "Select the start button to play again."
                End If
            End If
        End If

    End Sub

    '--------------------------------------------------------------------------
    'Description:   START CLICK EVENT

    'Calls:         pCarColor, fColllision, pSpriteAnimation
    '--------------------------------------------------------------------------
    Private Sub btnStart_Click(sender As Object,
                               e As EventArgs) Handles btnStart.Click

        'Click Start to get the background and sprite on panel and from and
        'reset all fields so you can start  
        btnStart.Enabled = False
        btnQuit.Enabled = False

        If lngScore > 0 Then
            lblPrevious.Text = lngScore.ToString
        End If

        lngScore = 0
        cshtTurtleX = 25
        cshtTurtleY = 175
        bytDeathCounter = 3
        graBG.ResetTransform()
        graTurtle.ResetTransform()
        lblLife1.Image = Image.FromFile("..\Multimedia\RightSprite.png")
        lblLife2.Image = Image.FromFile("..\Multimedia\RightSprite.png")
        lblLife3.Image = Image.FromFile("..\Multimedia\RightSprite.png")
        lblInfo.Text = Chr(13) & "Get across the road before the hunter catches you!"

        Dim i As Integer

        Dim shtDistanceTraveled1stLane As Short
        Dim shtDistanceTraveled2ndLane As Short
        Dim shtDistanceTraveled3rdLane As Short
        Dim shtDistanceTraveled4thLane As Short
        Dim shtDistanceTraveled5thLane As Short

        Dim shtCounter1stLane As Short
        Dim shtCounter2ndLane As Short
        Dim shtCounter3rdLane As Short
        Dim shtCounter4thLane As Short
        Dim shtCounter5thLane As Short

        Dim bmpCarLane1 As Bitmap
        Dim bmpCarLane2 As Bitmap
        Dim bmpCarLane3 As Bitmap
        Dim bmpCarLane4 As Bitmap
        Dim bmpCarLane5 As Bitmap

        'Randomizing the Colors of Cars
        bmpCarLane1 = CarColor(1)
        bmpCarLane2 = CarColor(2)
        bmpCarLane3 = CarColor(3)
        bmpCarLane4 = CarColor(4)
        bmpCarLane5 = CarColor(5)

        graBG.DrawImageUnscaled(bmpBG, 0, 0)
        graBuffer.DrawImage(bmpBuffer, 0, 0)
        MessageBox.Show("Oh No! A hunter is chasing you. Avoid the traffic to get away.")

        'Audio 
        wmpPlayer.URL = cstrSongPath
        wmpPlayer.Ctlcontrols.play()

        'Start the timer
        intStart = Environment.TickCount

        For i = 0 To (bmpBG.Width - cshtViewWidth)

            'First we Draw our BG and Turtle Sprite

            graBG.DrawImageUnscaled(bmpBG, 0, 0)
            pSpriteAnimation(i)

            'Obstalces (Cars) Animation

            'This Car will be in our first lane
            'Checking to see if Car has reached the end of the screen 
            'which it will do Every 100 iterations (cshtCarMovementEnd)
            'NOTE 100 Value is determined by Car Locations Y Value and Matrix Vertical 
            'Translation Value (i.e how far our car travels)

            If Not i Mod cshtMovementEnd1stLane = 0 Then

                'If it hasn't then we just draw it with its position changin
                'after each iteration as we trasnform our graCar
                graCar1stLane.DrawImageUnscaled(bmpCarLane1, cshtCar1stLane_X - i,
                                                cshtCar1stLane_Y)

            Else

                'If it has then we reset our graphics so it will repeat the animation
                'and we also retreive a new car color for the lane
                graCar1stLane.ResetTransform()
                bmpCarLane1 = CarColor(1)
                shtDistanceTraveled1stLane = 0
                shtCounter1stLane = 0

            End If

            'This car will be in our 2nd lane
            'Checking to see if Car in 2nd lane has reached end of screen

            If Not i Mod cshtMovementEndCar2ndLane = 0 Then

                'If it hasn't then we just draw it in its new position
                graCar2ndLane.DrawImage(bmpCarGreenUp, cshtCar2ndLane_X - i,
                                        cshtCar2ndLane_Y)

            Else

                'If it has then we reset our graphics so it will repeat the animation
                'and we also retreive a new car color for the lane               
                graCar2ndLane.ResetTransform()
                bmpCarLane2 = CarColor(2)
                shtDistanceTraveled2ndLane = 0
                shtCounter2ndLane = 0

            End If

            'This Car Will be in our 3rd Lane
            If Not i Mod cshtMovementEndCar3rdLane = 0 Then

                'If it hasn't then we just draw it in its new position
                graCar3rdLane.DrawImage(bmpCarLane3, cshtCar3rdLane_X - i,
                                        cshtCar3rdLane_Y)

            Else

                'If it has then we reset our graphics so it will repeat the animation
                'and we also retreive a new car color for the lne
                graCar3rdLane.ResetTransform()
                bmpCarLane3 = CarColor(3)
                shtDistanceTraveled3rdLane = 0
                shtCounter3rdLane = 0

            End If

            'This Car Will be in our 4th Lane
            If Not i Mod cshtMovementEndCar4thLane = 0 Then

                'If it hasn't then we just draw it in its new position
                graCar4thLane.DrawImage(bmpCarLane4, cshtCar4thLane_X - i,
                                        cshtCar4thLane_Y)

            Else

                'If it has then we reset our graphics so it will repeat the animation
                'and we also retreive a new car color for the lne
                graCar4thLane.ResetTransform()
                bmpCarLane4 = CarColor(4)
                shtDistanceTraveled4thLane = 0
                shtCounter4thLane = 0

            End If

            If Not i Mod cshtMovementEndCar5thLane = 0 Then

                'If it hasn't then we just draw it in its new position
                graCar5thLane.DrawImage(bmpCarLane5, cshtCar5thLane_X - i,
                                        cshtCar5thLane_Y)

            Else

                'If it has then we reset our graphics so it will repeat the animation
                'and we also retreive a new car color for the lne
                graCar5thLane.ResetTransform()
                bmpCarLane5 = CarColor(5)
                shtDistanceTraveled5thLane = 0
                shtCounter5thLane = 0

            End If

            'End of Car Animation

            'Draw Everything to the panel and transform all our
            'Graphics Objects for animation effect for next iteration
            graBuffer.DrawImageUnscaled(bmpBuffer, 0, 0)


            'Alright, this is our Collision Code. What it does is we have a seperate 
            'counter that determines how many iterations in the car animation have 
            'passed. We multiply it by our distance traveled in one iteration 
            '(cshtCarNthLane_MoveY) to get our total distance traveled for the 
            ' entire animation. We then add one to the counter (1 car animation
            'has passed). Then we check that our sprite (turtle) isn't in the 
            'vicinity of the car. After the Car Animation has reset (look at 
            'code above) we reset both our counter and DistanceTraveled variables
            'to make our bounding box reset with the car sprite.
            'NOTE- The Use of Literals is to make collision a little less exact
            'due to exlusively using variables putting collision right on the 
            'edge of our images. Using literals lets the images overlap a little.
            'before the collision is detected.

            'WARNING - 

            shtDistanceTraveled1stLane = CShort(shtCounter1stLane * cshtCar1stLane_MoveY)
            shtDistanceTraveled2ndLane = CShort(shtCounter2ndLane * cshtCar2ndLane_MoveY)
            shtDistanceTraveled3rdLane = CShort(shtCounter3rdLane * cshtCar3rdLane_MoveY)
            shtDistanceTraveled4thLane = CShort(shtCounter4thLane * cshtCar4thLane_MoveY)
            shtDistanceTraveled5thLane = CShort(shtCounter5thLane * cshtCar5thLane_MoveY)

            shtCounter1stLane += CShort(1)
            shtCounter2ndLane += CShort(1)
            shtCounter3rdLane += CShort(1)
            shtCounter4thLane += CShort(1)
            shtCounter5thLane += CShort(1)

            'lane 1
            If fCollision(i, cshtTurtleX, cshtTurtleW, cshtCar1stLane_X,
                          cshtTurtleY, cshtTurtleH, cshtCar1stLane_Y,
                          cshtCarH, cshtCarW, shtDistanceTraveled1stLane) = True Then

                If cshtTurtleX < 25 Then
                    cshtTurtleX = 25
                Else
                    cshtTurtleX -= cshtCarW + cshtTurtleW
                End If
                bytDeathCounter -= CByte(1)
                sDeathCount()

                If bytDeathCounter = 0 Then

                    wmpPlayer.Ctlcontrols.stop()
                    btnStart.Enabled = True
                    btnQuit.Enabled = True
                    MsgBox("Game Over")
                    Exit For

                End If

            End If

            'lane 2
            If fCollision(i, cshtTurtleX, cshtTurtleW, cshtCar2ndLane_X,
                          cshtTurtleY, cshtTurtleH, cshtCar2ndLane_Y,
                          cshtCarH, cshtCarW, shtDistanceTraveled2ndLane) = True Then

                If cshtTurtleX < 25 Then
                    cshtTurtleX = 25
                Else
                    cshtTurtleX -= cshtCarW + cshtTurtleW
                End If
                bytDeathCounter -= CByte(1)
                sDeathCount()

                If bytDeathCounter = 0 Then

                    wmpPlayer.Ctlcontrols.stop()
                    btnStart.Enabled = True
                    btnQuit.Enabled = True
                    MsgBox("Game Over")
                    Exit For

                End If

            End If

            'lane 3
            If fCollision(i, cshtTurtleX, cshtTurtleW, cshtCar3rdLane_X,
                          cshtTurtleY, cshtTurtleH, cshtCar3rdLane_Y,
                          cshtCarH, cshtCarW, shtDistanceTraveled3rdLane) = True Then

                If cshtTurtleX < 25 Then
                    cshtTurtleX = 25
                Else
                    cshtTurtleX -= cshtCarW + cshtTurtleW
                End If
                bytDeathCounter -= CByte(1)
                sDeathCount()

                If bytDeathCounter = 0 Then

                    wmpPlayer.Ctlcontrols.stop()
                    btnStart.Enabled = True
                    btnQuit.Enabled = True
                    MsgBox("Game Over")
                    Exit For

                End If

            End If

            'lane 4
            If fCollision(i, cshtTurtleX, cshtTurtleW, cshtCar4thLane_X,
                          cshtTurtleY, cshtTurtleH, cshtCar4thLane_Y,
                          cshtCarH, cshtCarW, shtDistanceTraveled4thLane) = True Then

                If cshtTurtleX < 25 Then
                    cshtTurtleX = 25
                Else
                    cshtTurtleX -= cshtCarW + cshtTurtleW
                End If
                bytDeathCounter -= CByte(1)
                sDeathCount()

                If bytDeathCounter = 0 Then

                    wmpPlayer.Ctlcontrols.stop()
                    btnStart.Enabled = True
                    btnQuit.Enabled = True
                    MsgBox("Game Over")
                    Exit For

                End If

            End If

            'lane 5
            If fCollision(i, cshtTurtleX, cshtTurtleW, cshtCar5thLane_X,
                          cshtTurtleY, cshtTurtleH, cshtCar5thLane_Y,
                          cshtCarH, cshtCarW, shtDistanceTraveled5thLane) = True Then

                If cshtTurtleX < 25 Then
                    cshtTurtleX = 25
                Else
                    cshtTurtleX -= cshtCarW + cshtTurtleW
                End If
                bytDeathCounter -= CByte(1)
                sDeathCount()

                If bytDeathCounter = 0 Then

                    wmpPlayer.Ctlcontrols.stop()
                    btnStart.Enabled = True
                    btnQuit.Enabled = True
                    MsgBox("Game Over")
                    Exit For

                End If

            End If
            'End of Collision Code

            'Drarwing everything onto our panel and transforming Graphics
            graBG.MultiplyTransform(mtxBG)
            graCar1stLane.MultiplyTransform(mtxCar1stLane)
            graCar2ndLane.MultiplyTransform(mtxCar2ndLane)
            graCar3rdLane.MultiplyTransform(mtxCar3rdLane)
            graCar4thLane.MultiplyTransform(mtxCar4thLane)
            graCar5thLane.MultiplyTransform(mtxCar5thLane)
            Application.DoEvents()

            'lblInfo.Text = "Car X is " & (cshtCar1stLane_X - i).ToString &
            '    " Car Y is " & (cshtCar1stLane_Y + shtDistanceTraveled1stLane).
            '    ToString & ControlChars.CrLf & "Turtle X is " & cshtTurtleX.
            '    ToString & " Turtle Y Is" & cshtTurtleY.ToString & ControlChars.CrLf &
            '    i.ToString & "Transformation is " & shtDistanceTraveled1stLane.ToString

            'lblCurrent.Text = " " & cshtTurtleX.ToString & "Meters"

        Next i

        'END OF BG SLIDING

        If bytDeathCounter > 0 Then

            intStop = Environment.TickCount
            intStage1 = intStop - intStart
            wmpPlayer.Ctlcontrols.stop()
            MessageBox.Show("You Got Away! Just get across the last lanes of " &
                           "traffic And you'll be home.")

            Call pEnding()

        End If

    End Sub

    '--------------------------------------------------------------------------
    'Description:   This is a procedure for after our BG has finished scrolling
    '               in our btnStart Click event. After the BG has reached its 
    '               end we start animating the cars and then the user attempts
    '               to reach the finish line.
    ' 
    'Called By:     btnStart_Click
    '--------------------------------------------------------------------------
    Private Sub pEnding()

        cshtTurtleX = 25
        cshtTurtleY = 175
        Dim bmpCarLane6 = CarColor(6)
        Dim bmpCarLane7 = CarColor(7)

        Dim shtDistanceTraveledAlligator As Short
        Dim shtDistanceTraveled6thLane As Short
        Dim shtDistanceTraveled7thLane As Short

        Dim shtCounterAlligator As Short
        Dim shtCounter6thLane As Short
        Dim shtCounter7thLane As Short

        My.Computer.Audio.Play("..\Multimedia\AlmostThere.wav")
        lblInfo.Text = Chr(13) & "Watch out for the alligators!"
        wmpPlayer.Ctlcontrols.play()
        intStart = Environment.TickCount

        For j = 0 To 100000

            'pAlligatorAnimation()

            If Not j Mod cshtMovementEndCar6thLane = 0 Then

                graBG.DrawImageUnscaled(bmpBG, 0, 0)
                graAlligator.DrawImageUnscaled(bmpAlligator, cshtAlligator_X,
                                                cshtAlligator_Y)
                graCar6thLane.DrawImageUnscaled(bmpCarLane6, cshtCar6thLane_X,
                                                cshtCar6thLane_Y)
                graCar7thLane.DrawImageUnscaled(bmpCarLane7, cshtCar7thLane_X,
                                                cshtCar7thLane_Y)

                'Sprite Animation
                recCurrentFrame = New Rectangle(cshtFrameX, cshtFrameY,
                                                cshtTurtleW, cshtTurtleH)
                graTurtle.DrawImage(bmpTurtle, cshtTurtleX, cshtTurtleY,
                                    recCurrentFrame, GraphicsUnit.Pixel)

                If j Mod 20 = 0 Then

                    If cshtFrameX >= cshtAnimatedSpriteLength - cshtTurtleW Then

                        cshtFrameX = 0

                    Else

                        cshtFrameX += cshtTurtleW

                    End If

                End If

                'Alligator Animation
                recCurrentAlligatorFrame = New Rectangle(cshtAlligatorFrameX,
                                           cshtAlligatorFrameY,
                                           cshtAlligatorW, cshtAlligatorH)
                graAlligator.DrawImage(bmpAlligator, cshtAlligator_X, cshtAlligator_Y,
                                    recCurrentAlligatorFrame, GraphicsUnit.Pixel)

                If j Mod 20 = 0 Then

                    If cshtAlligatorFrameY >= cshtAnimatedAlligatorLength -
                        cshtAlligator_Y Then

                        cshtAlligatorFrameY = 0

                    Else

                        cshtAlligatorFrameY += cshtAlligator_Y

                    End If

                End If

                'Collision Code
                shtDistanceTraveledAlligator = CShort(shtCounterAlligator *
                    cshtAlligator_MoveY)
                shtCounterAlligator += CShort(1)

                shtDistanceTraveled6thLane = CShort(shtCounter6thLane *
                    cshtCar6thLane_MoveY)
                shtCounter6thLane += CShort(1)

                shtDistanceTraveled7thLane = CShort(shtCounter7thLane *
                    cshtCar7thLane_MoveY)
                shtCounter7thLane += CShort(1)

                'Water Crossing
                If cshtTurtleX + cshtTurtleW - 10 >= cshtAlligator_X And
                    cshtTurtleY + cshtTurtleH >= cshtAlligator_Y +
                    shtDistanceTraveledAlligator + 20 And
                    cshtTurtleY <= cshtAlligator_Y + cshtAlligatorH +
                    shtDistanceTraveledAlligator - 20 And
                    cshtTurtleX <= cshtAlligator_X + cshtAlligatorW Then

                    My.Computer.Audio.Play("..\Multimedia\Alligator.wav")

                    If cshtTurtleX < 25 Then
                        cshtTurtleX = 25
                    Else
                        cshtTurtleX -= cshtAlligatorW + cshtTurtleW
                    End If
                    bytDeathCounter -= CByte(1)
                    sDeathCount()

                    If bytDeathCounter = 0 Then

                        wmpPlayer.Ctlcontrols.stop()
                        btnStart.Enabled = True
                        btnQuit.Enabled = True
                        MsgBox("Game Over")
                        Exit For

                    End If

                End If

                'Lane 6
                If cshtTurtleX + cshtTurtleW - 10 >= cshtCar6thLane_X And
                cshtTurtleY + cshtTurtleH >= cshtCar6thLane_Y +
                shtDistanceTraveled6thLane + 20 And
                cshtTurtleY <= cshtCar6thLane_Y + cshtCarH +
                shtDistanceTraveled6thLane - 20 And
                cshtTurtleX <= cshtCar6thLane_X + cshtCarW Then

                    My.Computer.Audio.Play("..\Multimedia\Squish.wav")

                    If cshtTurtleX < 25 Then
                        cshtTurtleX = 25
                    Else
                        cshtTurtleX -= cshtCarW + cshtTurtleW
                    End If
                    bytDeathCounter -= CByte(1)
                    sDeathCount()

                    If bytDeathCounter = 0 Then

                        wmpPlayer.Ctlcontrols.stop()
                        btnStart.Enabled = True
                        btnQuit.Enabled = True
                        MsgBox("Game Over")
                        Exit For

                    End If

                End If

                If cshtTurtleX + cshtTurtleW - 10 >= cshtCar7thLane_X And
                    cshtTurtleY + cshtTurtleH >= cshtCar7thLane_Y +
                    shtDistanceTraveled7thLane + 20 And
                    cshtTurtleY <= cshtCar7thLane_Y + cshtCarH +
                    shtDistanceTraveled7thLane - 20 And
                    cshtTurtleX <= cshtCar7thLane_X + cshtCarW Then

                    My.Computer.Audio.Play("..\Multimedia\Squish.wav")

                    If cshtTurtleX < 25 Then
                        cshtTurtleX = 25
                    Else
                        cshtTurtleX -= cshtCarW + cshtTurtleW
                    End If
                    bytDeathCounter -= CByte(1)
                    sDeathCount()

                    If bytDeathCounter = 0 Then

                        wmpPlayer.Ctlcontrols.stop()
                        btnStart.Enabled = True
                        btnQuit.Enabled = True
                        MsgBox("Game Over")
                        Exit For

                    End If

                End If
                'End of Collision Code

                'Drawing Everything onto our panel and tranforming graphics
                graBuffer.DrawImageUnscaled(bmpBuffer, 0, 0)
                graAlligator.MultiplyTransform(mtxAlligator)
                graCar6thLane.MultiplyTransform(mtxCar6thLane)
                graCar7thLane.MultiplyTransform(mtxCar7thLane)
                Application.DoEvents()

            Else

                graAlligator.ResetTransform()
                shtDistanceTraveledAlligator = 0
                shtCounterAlligator = 0

                graCar6thLane.ResetTransform()
                bmpCarLane6 = CarColor(6)
                shtDistanceTraveled6thLane = 0
                shtCounter6thLane = 0

                graCar7thLane.ResetTransform()
                bmpCarLane7 = CarColor(7)
                shtDistanceTraveled7thLane = 0
                shtCounter7thLane = 0

            End If

            'Finish line
            If cshtTurtleX > 685 Then

                intStop = Environment.TickCount
                intStage2 = intStop - intStart
                lngScore = clngMAX_TIME - (intStage1 + intStage2)
                lngScore += CInt(bytDeathCounter * cintLIFE)

                If lngScore > lngHighScore Then
                    lblInfo.Text = Chr(13) & "New High Score!"
                    lngHighScore = lngScore
                Else
                    lblInfo.Text = Chr(13) & "You made it!"
                End If

                lblCurrent.Text = lngScore.ToString
                lblHigh.Text = lngHighScore.ToString
                wmpPlayer.Ctlcontrols.stop()
                My.Computer.Audio.Play("..\Multimedia\FinishLine.wav")
                MessageBox.Show("Congratulations")
                My.Computer.Audio.Stop()
                btnStart.Enabled = True
                btnQuit.Enabled = True
                Exit For

            End If

            'lblInfo.Text = cshtTurtleX.ToString

        Next j

    End Sub

    '--------------------------------------------------------------------------
    'Description:   KEYDOWN EVENT
    '--------------------------------------------------------------------------
    Private Sub FinalProject_KeyDown(sender As Object,
                                    e As KeyEventArgs) Handles Me.KeyDown

        If e.KeyCode = Keys.Right And cshtTurtleX <
                        (cshtViewWidth - cshtTurtleW - 5) Then
            cshtTurtleX += cshtTurtleMoveX

        ElseIf e.KeyCode = Keys.Left And cshtTurtleX > 0 Then
            cshtTurtleX -= cshtTurtleMoveX

        ElseIf e.KeyCode = Keys.Down Then
            cshtTurtleY += cshtTurtleMoveY

        ElseIf e.KeyCode = Keys.Up Then
            cshtTurtleY -= cshtTurtleMoveY

        End If

    End Sub

    '-------------------------------------------------------------------------------
    'Description:   This function will randomly determine the color of our cars based
    '               on which lane they are in (i.e first lane will only have bitmpas
    '               with cars facing down returned) and return the random bmp color.
    '
    'Called By:     btnStart_Click
    '-------------------------------------------------------------------------------
    Public Function CarColor(ByRef intNum As Integer) As Bitmap

        Dim intRandom As Integer

        'This if for the first lane
        If intNum = 1 Then

            intRandom = Int(CInt((3 * Rnd()) + 1))

            If intRandom = 1 Then
                Return bmpCarRedDown
            ElseIf intRandom = 2 Then
                Return bmpCarBlueDown
            ElseIf intRandom = 3 Then
                Return bmpCarGreenDown
            Else
                Return bmpCarRedDown
            End If

            'This is for the second
        ElseIf intNum = 2 Then
            intRandom = Int(CInt((3 * Rnd()) + 1))

            If intRandom = 1 Then
                Return bmpCarRedUp
            ElseIf intRandom = 2 Then
                Return bmpCarBlueUp
            ElseIf intRandom = 3 Then
                Return bmpCarGreenUp
            Else
                Return bmpCarRedUp
            End If

            'This is for the third Lane
        ElseIf intNum = 3 Then
            intRandom = Int(CInt((3 * Rnd()) + 1))

            If intRandom = 1 Then
                Return bmpCarRedDown
            ElseIf intRandom = 2 Then
                Return bmpCarBlueDown
            ElseIf intRandom = 3 Then
                Return bmpCarGreenDown
            Else
                Return bmpCarRedDown
            End If

            'This is for the fourth lane
        ElseIf intNum = 4 Then
            intRandom = Int(CInt((3 * Rnd()) + 1))

            If intRandom = 1 Then
                Return bmpCarRedDown
            ElseIf intRandom = 2 Then
                Return bmpCarBlueDown
            ElseIf intRandom = 3 Then
                Return bmpCarGreenDown
            Else
                Return bmpCarRedDown
            End If

            'This is the fifth lane
        ElseIf intNum = 5 Then
            intRandom = Int(CInt((3 * Rnd()) + 1))

            If intRandom = 1 Then
                Return bmpCarRedDown
            ElseIf intRandom = 2 Then
                Return bmpCarBlueDown
            ElseIf intRandom = 3 Then
                Return bmpCarGreenDown
            Else
                Return bmpCarRedDown
            End If


            'This is for the sixth lane
        ElseIf intNum = 6 Then
            intRandom = Int(CInt((3 * Rnd()) + 1))

            If intRandom = 1 Then
                Return bmpCarRedDown
            ElseIf intRandom = 2 Then
                Return bmpCarBlueDown
            ElseIf intRandom = 3 Then
                Return bmpCarGreenDown
            Else
                Return bmpCarRedDown
            End If

            'This is for the seventh lane
        ElseIf intNum = 7 Then
            intRandom = Int(CInt((3 * Rnd()) + 1))

            If intRandom = 1 Then
                Return bmpCarRedUp
            ElseIf intRandom = 2 Then
                Return bmpCarBlueUp
            ElseIf intRandom = 3 Then
                Return bmpCarGreenUp
            Else
                Return bmpCarRedUp
            End If
        End If

    End Function

    '-------------------------------------------------------------------------------
    'Description:   This procedure will animate our sprite.
    '
    'Called By:     btnStart_Click
    '-------------------------------------------------------------------------------
    Private Sub pSpriteAnimation(ByVal i As Integer)

        recCurrentFrame = New Rectangle(cshtFrameX, cshtFrameY, cshtTurtleW,
                                        cshtTurtleH)
        graTurtle.DrawImage(bmpTurtle, cshtTurtleX, cshtTurtleY, recCurrentFrame,
                            GraphicsUnit.Pixel)

        If i Mod 20 = 0 Then

            If cshtFrameX >= cshtAnimatedSpriteLength - cshtTurtleW Then

                cshtFrameX = 0

            Else

                cshtFrameX += cshtTurtleW

            End If

        End If

    End Sub

    '-------------------------------------------------------------------------------
    'Description:   This procedure will animate the alligator. NOT CURRENTLY CALLED.
    '
    'Called By:     btnStart_Click
    '-------------------------------------------------------------------------------
    Private Sub pAlligatorAnimation(ByVal i As Integer)

        'Alligator Animation
        recCurrentAlligatorFrame = New Rectangle(cshtAlligatorFrameX,
                                   cshtAlligatorFrameY, cshtAlligatorW,
                                   cshtAlligatorH)

        graAlligator.DrawImage(bmpAlligator, cshtAlligator_X, cshtAlligator_Y,
                               recCurrentAlligatorFrame, GraphicsUnit.Pixel)

        If i Mod 20 = 0 Then

            If cshtAlligatorFrameY >= cshtAnimatedAlligatorLength -
                cshtAlligator_Y Then

                cshtAlligatorFrameY = 0

            Else

                cshtAlligatorFrameY += cshtAlligator_Y

            End If

        End If

        'End of Alligator Animation

    End Sub

    '--------------------------------------------------------------------------
    'Description:   QUIT CLICK EVENT
    '--------------------------------------------------------------------------
    Private Sub btnQuit_Click(sender As Object,
                              e As EventArgs) Handles btnQuit.Click

        Me.Close()

    End Sub

End Class