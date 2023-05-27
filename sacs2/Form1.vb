Imports System.IO
Imports System.Net.Http
Imports Newtonsoft.Json
Imports System.Net
Imports Newtonsoft.Json.Linq

Public Class Form1
    Private Const ApiUrl As String = "https://www.cheatslips.com/api/v1"
    Private ApiToken As String = ""
    Private namesAndValues As New Dictionary(Of String, List(Of String))()

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        SearchGames(TextBox1.Text)
    End Sub

    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True ' Suppress the default Enter key behavior
            SearchGames(TextBox1.Text)
        End If
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        Dim selectedGame As String = ListBox1.SelectedItem?.ToString()
        If Not String.IsNullOrEmpty(selectedGame) Then
            GetTitleIdAndBuilds(selectedGame)
            Me.Text = selectedGame
        End If
    End Sub

    Private Sub SearchGames(keyword As String)
        Dim games As List(Of Game) = GetGamesByKeyword(keyword)

        If games IsNot Nothing AndAlso games.Count > 0 Then
            ListBox1.DisplayMember = "Name"
            ListBox1.DataSource = games
        Else
            ListBox1.DataSource = Nothing
            MessageBox.Show("No games found.")
        End If
    End Sub

    Private Function GetGamesByKeyword(keyword As String) As List(Of Game)
        Dim games As List(Of Game) = Nothing

        Using client As New HttpClient()
            client.DefaultRequestHeaders.Add("X-API-TOKEN", ApiToken)

            Dim response = client.GetAsync($"{ApiUrl}/cheats/find/{keyword}").Result
            If response.IsSuccessStatusCode Then
                Dim jsonResponse = response.Content.ReadAsStringAsync().Result
                Dim cheatsResponse = JsonConvert.DeserializeObject(Of CheatsResponse)(jsonResponse)

                If cheatsResponse IsNot Nothing AndAlso cheatsResponse.Games IsNot Nothing AndAlso cheatsResponse.Games.Count > 0 Then
                    games = cheatsResponse.Games.Select(Function(game) New Game With {
                    .Name = game.Name,
                    .Slug = game.Slug
                }).ToList()
                End If
            End If
        End Using

        Return games
    End Function


    Private Sub GetTitleIdAndBuilds(gameName As String)
        Using client As New HttpClient()
            client.DefaultRequestHeaders.Add("X-API-TOKEN", ApiToken)

            Dim response = client.GetAsync($"{ApiUrl}/cheats/find/{Uri.EscapeDataString(gameName)}").Result
            If response.IsSuccessStatusCode Then
                Dim jsonResponse = response.Content.ReadAsStringAsync().Result
                Dim cheatsResponse = JsonConvert.DeserializeObject(Of CheatsResponse)(jsonResponse)

                If cheatsResponse IsNot Nothing AndAlso cheatsResponse.Games IsNot Nothing AndAlso cheatsResponse.Games.Count > 0 Then
                    Dim game = cheatsResponse.Games(0)
                    TextBox2.Text = game.Cheats.FirstOrDefault()?.TitleId

                    Dim builds As New List(Of String)()
                    For Each cheat In game.Cheats
                        If Not String.IsNullOrEmpty(cheat.Build) AndAlso Not builds.Contains(cheat.Build) Then
                            builds.Add(cheat.Build)
                        End If
                    Next

                    ComboBox1.DataSource = builds
                End If
            End If
        End Using
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ApiToken = GetTokenFromApi()
    End Sub

    Private Function GetTokenFromApi() As String
        Dim token As String = ""

        Using client As New HttpClient()
            Dim response = client.GetAsync($"{ApiUrl}/token").Result
            If response.IsSuccessStatusCode Then
                Dim jsonResponse = response.Content.ReadAsStringAsync().Result
                Dim tokenObj = JsonConvert.DeserializeObject(Of TokenResponse)(jsonResponse)
                token = tokenObj.Token
            End If
        End Using

        Return token
    End Function

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        ' Check if CheckBox1 is checked
        If CheckBox1.Checked = True Then
            ' Clear ListBox2
            ListBox3.Items.Clear()
        Else
            ' Clear ListBox2 and ListBox3
            ListBox2.Items.Clear()
            ListBox3.Items.Clear()
        End If

        ' Open a file dialog to select a text file
        Dim openFileDialog As New OpenFileDialog()
        openFileDialog.Filter = "Text Files (*.txt)|*.txt"
        openFileDialog.RestoreDirectory = True ' Add this line to reset the dialog's initial directory

        If openFileDialog.ShowDialog() = DialogResult.OK Then
            ' Read the selected file and extract names and values
            Dim filePath As String = openFileDialog.FileName
            Dim fileName As String = Path.GetFileName(filePath)

            ' Update the title of Form1 with the file name
            Me.Text = $"{fileName} - {filePath}"

            Dim lines() As String = File.ReadAllLines(filePath)

            Dim currentName As String = Nothing

            ' Clear the dictionary namesAndValues
            namesAndValues.Clear()

            For Each line As String In lines
                If line.Trim() = String.Empty Then
                    ' Skip blank lines
                    Continue For
                ElseIf line.StartsWith("[") AndAlso line.EndsWith("]") Then
                    ' Extract the name from lines in the format [Name]
                    currentName = line.TrimStart("["c).TrimEnd("]"c)
                    namesAndValues(currentName) = New List(Of String)()
                ElseIf currentName IsNot Nothing Then
                    ' Add the value to the current name's list
                    namesAndValues(currentName).Add(line.Trim())
                End If
            Next


            ' Populate ListBox1 with the extracted names
            ListBox2.Items.AddRange(namesAndValues.Keys.ToArray())
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ' Get the selected names from ListBox2
        Dim selectedNames As New List(Of String)()

        For Each item As Object In ListBox2.SelectedItems
            selectedNames.Add(item.ToString())
        Next

        ' Add the selected names to ListBox2
        ListBox3.Items.AddRange(selectedNames.ToArray())
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        ' Create a copy of the selected items
        Dim selectedItems As New List(Of Object)()

        For Each selectedItem As Object In ListBox3.SelectedItems
            selectedItems.Add(selectedItem)
        Next

        ' Remove the selected name and its associated values from ListBox3
        For Each selectedItem As Object In selectedItems
            ListBox3.Items.Remove(selectedItem)

            ' Also remove the associated name and values from the dictionary
            Dim selectedName As String = selectedItem.ToString()
            If namesAndValues.ContainsKey(selectedName) Then
                namesAndValues.Remove(selectedName)
            End If
        Next
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        ' Open a file dialog to specify the save location
        Dim saveFileDialog As New SaveFileDialog()
        saveFileDialog.Filter = "buildID (*.txt)|*.txt"

        ' Set the initial file name in the save dialog based on the selected item in ComboBox1
        If ComboBox1.SelectedItem IsNot Nothing Then
            Dim recommendedFileName As String = ComboBox1.SelectedItem.ToString()
            saveFileDialog.FileName = recommendedFileName
        End If

        If saveFileDialog.ShowDialog() = DialogResult.OK Then
            ' Get the selected names from ListBox3
            Dim selectedNames As New List(Of String)()

            For Each item As Object In ListBox3.Items
                selectedNames.Add(item.ToString())
            Next

            ' Write the selected names and their associated values to the selected file
            Dim filePath As String = saveFileDialog.FileName
            Dim lines As New List(Of String)()

            For Each name As String In selectedNames
                If namesAndValues.ContainsKey(name) Then
                    ' Add a newline before each name
                    If lines.Count > 0 Then
                        lines.Add(String.Empty)
                    End If

                    lines.Add($"[{name}]")
                    lines.AddRange(namesAndValues(name))
                End If
            Next

            File.WriteAllLines(filePath, lines)
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click




        ' Create a new instance of the custom dialog form
        CreditsForm.Show()

        '     Dim customMessageBox As New CustomMessageBox()

        ' Set the position of the custom dialog based on the mouse or Form1 location
        '     CustomMessageBox.StartPosition = FormStartPosition.Manual
        '     customMessageBox.Location = MousePosition ' or Me.Location for Form1 location

        ' Show the custom dialog
        '     CustomMessageBox.ShowDialog()
    End Sub

    Public Class CustomMessageBox
        Inherits Form

        Public Sub New()
            ' Set the properties of the custom dialog form
            Me.Text = "Credits"
            Me.FormBorderStyle = FormBorderStyle.FixedDialog
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.ShowInTaskbar = False
            Me.AutoSize = True

            ' Add controls to the custom dialog form
            Dim label As New Label()
            label.Text = "Devoloped by Type0dev" & Environment.NewLine & "aka CriminalMuppet" & Environment.NewLine & "Using cheatslips.com API"
            label.AutoSize = True
            label.Location = New Point(10, 10)

            Dim button As New Button()
            button.Text = "OK"
            button.DialogResult = DialogResult.OK
            button.Location = New Point(10, label.Bottom + 30)

            ' Set the width of the form to accommodate the label text
            Dim maxWidth As Integer = Math.Max(label.Width + 50, button.Width + 50)
            Me.ClientSize = New Size(maxWidth, button.Bottom + 10)

            Me.Controls.Add(label)
            Me.Controls.Add(button)
        End Sub
    End Class

    Private Async Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Try
            Dim titleId As String = TextBox2.Text.Trim()
            Dim build As String = ComboBox1.Text.Trim()
            Dim url As String = $"https://raw.githubusercontent.com/HamletDuFromage/switch-cheats-db/master/cheats/{titleId}.json"

            Dim httpClient As HttpClient = New HttpClient()
            Dim jsonContent As String = Await httpClient.GetStringAsync(url)

            Dim jsonObj As JObject = JObject.Parse(jsonContent)

            Dim matchingBuild As JProperty = jsonObj.Properties().FirstOrDefault(Function(prop) String.Equals(prop.Name, build, StringComparison.OrdinalIgnoreCase))

            If matchingBuild IsNot Nothing Then
                Dim cheatCodes = matchingBuild.Value.ToObject(Of Dictionary(Of String, String))

                ' Clear ListBox2 before populating it
                ListBox2.Items.Clear()

                ' Clear the namesAndValues dictionary
                namesAndValues.Clear()

                For Each entry In cheatCodes
                    Dim cheatName As String = entry.Key.TrimStart("["c).TrimEnd("]"c) ' Remove the surrounding brackets
                    Dim cheatCodeRaw As String = entry.Value
                    Dim cheatCode As String = cheatCodeRaw.Substring(cheatCodeRaw.IndexOf(vbLf)).Trim()

                    ' Add the cheat name and cheat code to namesAndValues dictionary
                    If Not namesAndValues.ContainsKey(cheatName) Then
                        namesAndValues(cheatName) = New List(Of String)()
                    End If
                    namesAndValues(cheatName).Add(cheatCode)

                    ' Add the cheat name to ListBox2
                    ListBox2.Items.Add(cheatName)
                Next
            Else
                ' Build not found, show a message box
                MessageBox.Show("Selected build not found. Switching to the next available build.", "Build Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information)

                ' Update ComboBox1 with the next available build
                Dim builds As List(Of String) = ComboBox1.DataSource
                Dim currentIndex As Integer = builds.FindIndex(Function(b) String.Equals(b, build, StringComparison.OrdinalIgnoreCase))

                If currentIndex < builds.Count - 1 Then
                    ' Select the next build in ComboBox1
                    ComboBox1.SelectedIndex = currentIndex + 1
                ElseIf builds.Count > 0 Then
                    ' Select the first build in ComboBox1
                    ComboBox1.SelectedIndex = 0
                End If

                ' Perform the same logic as before to update ListBox2 with the selected build
                build = ComboBox1.Text.Trim()

                matchingBuild = jsonObj.Properties().FirstOrDefault(Function(prop) String.Equals(prop.Name, build, StringComparison.OrdinalIgnoreCase))

                If matchingBuild IsNot Nothing Then
                    Dim cheatCodes = matchingBuild.Value.ToObject(Of Dictionary(Of String, String))

                    ' Clear ListBox2 before populating it
                    ListBox2.Items.Clear()

                    ' Clear the namesAndValues dictionary
                    namesAndValues.Clear()

                    For Each entry In cheatCodes
                        Dim cheatName As String = entry.Key.TrimStart("["c).TrimEnd("]"c) ' Remove the surrounding brackets
                        Dim cheatCodeRaw As String = entry.Value
                        Dim cheatCode As String = cheatCodeRaw.Substring(cheatCodeRaw.IndexOf(vbLf)).Trim()

                        ' Add the cheat name and cheat code to namesAndValues dictionary
                        If Not namesAndValues.ContainsKey(cheatName) Then
                            namesAndValues(cheatName) = New List(Of String)()
                        End If
                        namesAndValues(cheatName).Add(cheatCode)

                        ' Add the cheat name to ListBox2
                        ListBox2.Items.Add(cheatName)
                    Next
                End If
                ' Clear listbox's and reset data
                ListBox2.Items.Clear()
                namesAndValues.Clear()
            End If
        Catch ex As Exception
            ' Show a message box with the error message
            MessageBox.Show(ex.Message, "There was a issue with selected titleid/build or it doesnt exist:", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub TextBox1_Enter(sender As Object, e As EventArgs) Handles TextBox1.Enter
        If TextBox1.Text = "Enter game name here" Then
            TextBox1.Text = String.Empty
        End If
    End Sub

    Private Sub TextBox1_Leave(sender As Object, e As EventArgs) Handles TextBox1.Leave
        If TextBox1.Text = String.Empty Then
            TextBox1.Text = "Enter game name here"
        End If
    End Sub

End Class

Public Class Game
    Public Property Name As String
    Public Property Slug As String

    Public Overrides Function ToString() As String
        Return Name
    End Function
End Class

Public Class CheatsResponse
    Public Property Count As Integer
    Public Property Pagination As Pagination
    Public Property Games As List(Of GameWithCheats)
End Class

Public Class Pagination
    Public Property Start As Integer
    Public Property [End] As Integer
    Public Property LimitedTo As Integer
End Class

Public Class GameWithCheats
    Public Property Name As String
    Public Property Slug As String
    Public Property Count As Integer
    Public Property Cheats As List(Of Cheat)
    Public Property TitleId As String ' Add the TitleId property
End Class

Public Class Cheat
    Public Property Build As String
    Public Property TitleId As String
    Public Property Credits As String
End Class

Public Class TokenResponse
    Public Property Token As String
End Class
