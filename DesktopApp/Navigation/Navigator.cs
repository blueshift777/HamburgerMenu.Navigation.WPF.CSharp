using Caliburn.Micro;
using System.Threading.Tasks;
using System.Windows;

namespace DesktopApp
{
    internal static class Navigator
    {
        public static async Task ChangeView(PropertyChangedBase viewModel)
        {
            await IoC.Get<IEventAggregator>().PublishOnUIThreadAsync(viewModel);
        }

        public static void ExitApplication()
        {
            Application.Current.Shutdown();
        }
    }
}
