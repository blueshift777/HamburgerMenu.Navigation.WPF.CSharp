using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System.Threading.Tasks;
using System.Windows;

namespace DesktopApp
{
    internal class Dialogs
    {
        /// <summary>
        /// Show message dialog
        /// </summary>
        /// <param name="title">Title of the view</param>
        /// <param name="message">Message that is displayed to the user</param>
        public static async Task<MessageDialogResult> ShowMessage(
            string message,
            string title = "Message",
            MessageDialogStyle dialogStyle = MessageDialogStyle.Affirmative)
        {
            MetroWindow metroWindow = Application.Current.MainWindow as MetroWindow;
            metroWindow.MetroDialogOptions.ColorScheme = MetroDialogColorScheme.Accented;

            return await metroWindow.ShowMessageAsync(
                title,
                message,
                dialogStyle,
                metroWindow.MetroDialogOptions);
        }

        /// <summary>
        /// Show the login dialog
        /// </summary>
        /// <returns></returns>
        public static async Task<LoginDialogData> ShowLogin()
        {
            MetroWindow metroWindow = Application.Current.MainWindow as MetroWindow;
            return await metroWindow.ShowLoginAsync("Login", "Enter your credentials");
        }

    }
}
