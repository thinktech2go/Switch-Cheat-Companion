Imports Microsoft.Win32
Imports System.Diagnostics
Imports System.Media

Public Class CreditsForm
    Inherits Form

    Public Sub New()

        SystemSounds.Exclamation.Play()

        ' Set the properties of the credits form
        Me.FormBorderStyle = FormBorderStyle.None
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Size = New Size(300, 200) ' Adjust the size according to your preference

        ' Create a dictionary to store the credits and website URLs
        Dim creditsAndUrls As New Dictionary(Of String, String)()
        creditsAndUrls.Add("Type_0_Dev dev ;)", "https://github.com/thinktech2go")
        creditsAndUrls.Add("HamletDuFromage - Maintaining good database ", "https://github.com/HamletDuFromage/switch-cheats-db/")
        creditsAndUrls.Add("cheatslips - for there API", "http://www.dev3.com")
        creditsAndUrls.Add("Awesome peeps at GBA add/request thread", "https://gbatemp.net/forums/cheat-codes-add-and-request.412/")


        ' Add labels and link labels for each credit entry
        For Each entry In creditsAndUrls
            ' Add a label to display the credit text
            Dim creditLabel As New Label()
            creditLabel.Text = entry.Key
            creditLabel.AutoSize = True
            creditLabel.TextAlign = ContentAlignment.MiddleCenter
            creditLabel.Dock = DockStyle.Top

            ' Add the credit label to the credits form
            Me.Controls.Add(creditLabel)

            ' Add a link label for the website
            Dim linkLabel As New LinkLabel()
            linkLabel.Text = entry.Value
            linkLabel.LinkArea = New LinkArea(0, linkLabel.Text.Length)
            linkLabel.AutoSize = True
            linkLabel.Dock = DockStyle.Top
            linkLabel.TextAlign = ContentAlignment.MiddleCenter
            linkLabel.Links(0).LinkData = entry.Value ' Store the URL as link data

            ' Attach an event handler to the link label's LinkClicked event
            AddHandler linkLabel.LinkClicked, AddressOf LinkLabel_LinkClicked

            ' Add the link label to the credits form
            Me.Controls.Add(linkLabel)
        Next

        ' Add a button to exit the form
        Dim exitButton As New Button()
        exitButton.Text = "Exit"
        exitButton.DialogResult = DialogResult.OK
        exitButton.Dock = DockStyle.Bottom
        exitButton.AutoSize = True

        ' Set the background color of the exit button
        exitButton.BackColor = Color.Cyan

        ' Attach an event handler to the button's Click event
        AddHandler exitButton.Click, AddressOf ExitButton_Click

        ' Add the button to the credits form
        Me.Controls.Add(exitButton)
    End Sub

    Private Sub ExitButton_Click(sender As Object, e As EventArgs)
        ' Close the form when the exit button is clicked
        Me.Close()
    End Sub

    Private Sub LinkLabel_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        ' Open the website URL in the default browser when the link is clicked
        Try
            Dim browserPath As String = getDefaultBrowser()
            Process.Start(browserPath, e.Link.LinkData.ToString())
        Catch ex As Exception
            MessageBox.Show("Unable to open the website.")
        End Try
    End Sub

    Private Function getDefaultBrowser() As String
        Dim browser As String = String.Empty
        Dim key As RegistryKey = Nothing
        Try
            key = Registry.ClassesRoot.OpenSubKey("HTTP\shell\open\command", False)

            ' Trim off quotes
            browser = key.GetValue(Nothing).ToString().ToLower().Replace("""", "")
            If Not browser.EndsWith("exe") Then
                ' Get rid of everything after the ".exe"
                browser = browser.Substring(0, browser.LastIndexOf(".exe") + 4)
            End If
        Finally
            If key IsNot Nothing Then
                key.Close()
            End If
        End Try
        Return browser
    End Function
End Class
