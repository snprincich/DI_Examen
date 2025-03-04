using WPF.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Controls;


namespace WPF.View;
public partial class DashboardView : UserControl
{
    public DashboardView()
    {
        InitializeComponent();
    }

    private void MyDataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
    {
        App.Current.Services.GetService<DashboardViewModel>().MyDataGrid_CellEditEnding(sender, e);
    }
}
