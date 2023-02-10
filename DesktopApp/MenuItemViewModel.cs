using Caliburn.Micro;

namespace DesktopApp
{
    public class MenuItemViewModel : PropertyChangedBase
    {
        private bool _textIsVisible;

        public string IconName { get; set; } = string.Empty ;
        public string Text { get; set; } = string.Empty;
        public string Action { get; set; } = string.Empty; //Example: "[Event MouseDown] = [Action ShowView1]"
        public bool TextIsVisible
        {
            get => _textIsVisible;
            set
            {
                _textIsVisible = value;
                NotifyOfPropertyChange(() => TextIsVisible);
            }
        }

        public MenuItemViewModel(string iconName, string text, string action)
        {
            IconName = iconName;
            Text = text;
            Action = action;

            TextIsVisible = false;
        }

        public void ToggleVisibility()
        {
            TextIsVisible = !TextIsVisible;
        }

    }
}
