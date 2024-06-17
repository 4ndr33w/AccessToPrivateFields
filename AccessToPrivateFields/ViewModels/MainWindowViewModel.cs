using AccessToPrivateFields.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessToPrivateFields.ViewModels
{
    internal class MainWindowViewModel : ViewModels.Base.ViewModelBase
    {
        public MainWindowViewModel() { OnStartup(); }
        private void OnStartup()
        {
            FieldInfoMethod();
        }
        #region поля для WPF
        #region Ex 1
        private string _example1TimeSpan;
        public string Example1TimeSpan { get { return _example1TimeSpan; } set { _example1TimeSpan = value; OnPropertyChanged("TimeSpan1"); } }
        private string _example1Result = "sample1";
        public string Example1Result { get { return _example1Result; } set { _example1Result = value; OnPropertyChanged("Result1"); } }
        #endregion        
        
        #endregion
        #region Example 1: Field Info

        private void FieldInfoMethod()
        {
            var startTime = DateTime.Now;

            Models.ProjectModel _projectModel = new Models.ProjectModel();
            string result = String.Empty;

            System.Reflection.FieldInfo fieldInfo = typeof(ProjectModel)
                .GetField("_privateField", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);

            if (fieldInfo != null)
            {
                result = (string)fieldInfo.GetValue(_projectModel);
            }
            var EndTime = DateTime.Now;
            var timeSpan = (EndTime - startTime).TotalMilliseconds;
            Example1Result = result;
            Example1TimeSpan = timeSpan.ToString() + " ms";
        }
        #endregion
    }
}
