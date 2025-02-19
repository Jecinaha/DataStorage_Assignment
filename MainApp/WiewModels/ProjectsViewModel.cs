using CommunityToolkit.Mvvm.ComponentModel;

namespace MainApp.WiewModels;

public partial class ProjectsViewModel : ObservableObject

{
    [ObservableProperty]
    private string _text = "Projects";
}
