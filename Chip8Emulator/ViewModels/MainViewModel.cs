using CommunityToolkit.Mvvm.ComponentModel;

namespace Chip8Emulator.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty]
    private string _greeting = "Welcome to Avalonia!";
}
