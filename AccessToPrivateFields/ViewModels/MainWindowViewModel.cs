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
        public MainWindowViewModel() {/* UpdateMethod(); */}
        public void UpdateMethod()
        {
            FieldInfoMethod();
            NestedClassAccessMethod();
        }
        #region поля для WPF
        #region Ex 1
        private string _example1TimeSpan = "TimeSpan1";
        public string Example1TimeSpan { get => _example1TimeSpan; set => Set(ref _example1TimeSpan, value); } 
        private string _example1Result = "sample1";
        public string Example1Result { get => _example1Result; set => Set(ref _example1Result, value); }
        #endregion

        #region Ex 2
        private string _example2TimeSpan = "TimeSpan2";
        public string Example2TimeSpan { get => _example2TimeSpan; set => Set(ref _example2TimeSpan, value); }
        private string _example2Result = "sample2";
        public string Example2Result { get => _example2Result; set => Set(ref _example2Result, value); }
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
            Example1Result = result;
            var EndTime = DateTime.Now;
            var timeSpan = (EndTime - startTime).TotalMilliseconds;
            
            Example1TimeSpan = timeSpan.ToString() + " ms";
        }
        #endregion

        #region Example 2: Nested Class

        private void NestedClassAccessMethod()
        {
            var startTime = DateTime.Now;
            Models.ProjectModel _projectModel = new Models.ProjectModel();
            Models.ProjectModel.NestedClassToGetAccessToPrivateField _nestedClass = new ProjectModel.NestedClassToGetAccessToPrivateField(_projectModel);
            Example2Result = _nestedClass.GetPrivateFieldData();
            var endTime = DateTime.Now;
            Example2TimeSpan = (endTime - startTime)
                .Milliseconds
                .ToString() + " ms";
            
        }
        #endregion
    }
}
