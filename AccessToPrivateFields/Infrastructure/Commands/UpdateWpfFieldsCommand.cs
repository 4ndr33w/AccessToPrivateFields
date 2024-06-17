using AccessToPrivateFields.ViewModels;
using AccessToPrivateFields.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessToPrivateFields.Infrastructure.Commands
{
    internal class UpdateWpfFieldsCommand : Base.CommandBase
    {
        public override bool CanExecute(object parameter) => true;
        //{
        //    throw new NotImplementedException();
        //}

        public override void Execute(object parameter)
        {
            var mainWindowViewModel = ((parameter as MainWindow).DataContext as MainWindowViewModel);
            mainWindowViewModel.UpdateMethod();
        }
    }
}
