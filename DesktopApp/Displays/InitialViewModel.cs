using Caliburn.Micro;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DesktopApp
{
    public class InitialViewModel : Conductor<PropertyChangedBase>, IHandle<PropertyChangedBase>
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();

        public bool MenuButtonsAreVisible { get; private set; }
        public MenuItemViewModel MenuItem { get; set; } = new MenuItemViewModel("Application", "Navigation", "[Event MouseDown] = [Action ShowView1]");

        public BindableCollection<MenuItemViewModel> MenuItemViewModelSet { get; set; } = new BindableCollection<MenuItemViewModel>();

        public InitialViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _eventAggregator.SubscribeOnPublishedThread(this);
        }

        protected override void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);

            MenuButtonsAreVisible = false;
        }

        public void ToggleMenu()
        {
            MenuItem.ToggleVisibility();

            MenuItemViewModelSet.ToList().ForEach(mi => mi.ToggleVisibility());
        }
        public async Task ShowView1()
        {
            await Navigator.ChangeView(new NavigationViewModel());
        }

        public async Task ShowMainMenuAsync()
        {
            await ActivateItemAsync(new MainMenuViewModel(), _cancellationTokenSource.Token);
        }

        public async Task ShowSettingsAsync()
        {
            _ = await Dialogs.ShowMessage("Cannot show the Settings view because it is not implemented", "Not Implemented");
        }

        public async Task HandleAsync(PropertyChangedBase viewModel, CancellationToken cancellationToken)
        {
            await ActivateItemAsync(viewModel, cancellationToken);
        }

        public void ExitApplication()
        {
            Navigator.ExitApplication();
        }
    }
}
