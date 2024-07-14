using DisconnectedMode.ViewModel;

namespace DisconnectedMode.Messages;

public class ChangeViewModelMessage : Message
{
    public BaseViewModel ViewModel { get; set; }

    public ChangeViewModelMessage(BaseViewModel viewModel)
    {
        ViewModel = viewModel;
    }
}