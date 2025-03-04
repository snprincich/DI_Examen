using CommunityToolkit.Mvvm.ComponentModel;

namespace WPF.ViewModel
{
    public class ViewModelBase : ObservableObject
        {
            public virtual Task LoadAsync() => Task.CompletedTask;
        }
}


