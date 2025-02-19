using CommunityToolkit.Mvvm.ComponentModel;


namespace Main.ViewModels;

public partial class ProjectViewModel : ObservableObject
{
    [ObservableProperty]
    private string _title = "Projects";
}
