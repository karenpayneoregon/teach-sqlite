using SampleApp3.Properties;

namespace SampleApp3.Classes;

/// <summary>
/// Custom dialogs
/// </summary>
public class Dialogs
{

    /// <summary>
    /// Information dialog centered to an owner
    /// </summary>
    /// <param name="owner">Control or form to center on</param>
    /// <param name="heading">Heading text or an empty string</param>
    /// <param name="text">Text to display</param>
    /// <param name="buttonText">To override OK as the button text</param>
    public static void Information(Control owner, string heading, string text, string buttonText = "Ok")
    {

        TaskDialogButton okayButton = new(buttonText);

        TaskDialogPage page = new()
        {
            Caption = "Information",
            SizeToContent = true,
            Heading = heading,
            Footnote = new TaskDialogFootnote() { Text = "Code sample by Karen Payne" },
            Text = text,
            Icon = new TaskDialogIcon(Resources.blueInformation_32),
            Buttons = [okayButton]
        };

        TaskDialog.ShowDialog(owner, page);

    }

    /// <summary>
    /// Used for development to display exception information
    /// </summary>
    /// <param name="exception">Exception thrown</param>
    /// <param name="buttonText">optional text for button</param>
    public static void ExceptionMessageBox(Exception exception, string buttonText = "Continue")
    {

        TaskDialogButton singleButton = new(buttonText);

        var text = $"Encountered the following\n{exception.Message}";


        TaskDialogPage page = new()
        {
            Caption = "Something went wrong",
            SizeToContent = true,
            Heading = text,
            Icon = TaskDialogIcon.Error,
            Buttons = [singleButton]
        };

        TaskDialog.ShowDialog(page);

    }
    /// <summary>
    /// For asking a question with No as the default button
    /// </summary>
    /// <param name="owner">Control to center on</param>
    /// <param name="heading">Text to display</param>
    /// <returns>true or false</returns>
    public static bool Question(Control owner, string heading)
    {

        TaskDialogButton yesButton = new("Yes") { Tag = DialogResult.Yes };
        TaskDialogButton noButton = new("No") { Tag = DialogResult.No };

        var buttons = new TaskDialogButtonCollection
        {
            noButton,
            yesButton
        };

        TaskDialogPage page = new()
        {
            Caption = "Question",
            SizeToContent = true,
            Heading = heading,
            Icon = new TaskDialogIcon(Resources.QuestionBlue),
            Buttons = buttons
        };

        var result = TaskDialog.ShowDialog(owner, page);

        return (DialogResult)result.Tag! == DialogResult.Yes;

    }
}
