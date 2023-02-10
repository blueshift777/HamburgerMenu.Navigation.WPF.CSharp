using Caliburn.Micro;

namespace DesktopApp
{
    internal class ChangeViewMessage
    {
        public PropertyChangedBase ViewModel { get; set; }

        public ChangeViewMessage(PropertyChangedBase viewModel)
        {
            ViewModel = viewModel;
        }
    }
}
