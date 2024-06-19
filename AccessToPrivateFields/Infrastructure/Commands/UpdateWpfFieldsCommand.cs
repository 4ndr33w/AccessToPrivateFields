using AccessToPrivateFields.ViewModels;
using AccessToPrivateFields.Views;

namespace AccessToPrivateFields.Infrastructure.Commands
{
    internal class UpdateWpfFieldsCommand : Base.CommandBase
    {
        public override bool CanExecute(object parameter) => true;

        public override void Execute(object parameter)
        {
            var mainWindowViewModel = ((parameter as MainWindow).DataContext as MainWindowViewModel);
            mainWindowViewModel.UpdateMethod();
        }
    }
}
