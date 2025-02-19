
using CommunityToolkit.Mvvm.ComponentModel;

namespace MainApp.ViewModels;

public partial class ProjectsViewModel : ObservableObject

{
    [ObservableProperty]
    private string _title = "Projects";
}
