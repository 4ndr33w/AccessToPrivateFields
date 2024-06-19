using AccessToPrivateFields.Models;
using System;
using System.Linq.Expressions;

namespace AccessToPrivateFields.ViewModels
{
    internal class MainWindowViewModel : ViewModels.Base.ViewModelBase
    {
        public MainWindowViewModel() { }
        public void UpdateMethod()
        {
            FieldInfoGetMethod();
            NestedClassAccessGetMethod();
            ExpressionTreesGetMethod();
        }
        #region поля для WPF

        #region Ex 1

        private string _example1Result = "sample1";
        private string _example1TimeSpan = "TimeSpan1";

        public string Example1Result { get => _example1Result; set => Set(ref _example1Result, value); }
        public string Example1TimeSpan { get => _example1TimeSpan; set => Set(ref _example1TimeSpan, value); }

        #endregion

        #region Ex 2

        private string _example2Result = "sample2";
        private string _example2TimeSpan = "TimeSpan2";

        public string Example2Result { get => _example2Result; set => Set(ref _example2Result, value); }
        public string Example2TimeSpan { get => _example2TimeSpan; set => Set(ref _example2TimeSpan, value); }

        #endregion

        #region Ex 3

        private string _example3Result = "sample3";
        private string _example3TimeSpan = "TimeSpan3";

        public string Example3Result { get => _example3Result; set => Set(ref _example3Result, value); }
        public string Example3TimeSpan { get => _example3TimeSpan; set => Set(ref _example3TimeSpan, value); }

        #endregion

        #endregion

        #region Example 1: Field Info

        private void FieldInfoGetMethod()
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
            var endTime = DateTime.Now;
            Example1TimeSpan = TimeSpanCaculating(startTime, endTime);
        }
        #endregion

        #region Example 2: Nested Class

        private void NestedClassAccessGetMethod()
        {
            var startTime = DateTime.Now;
            Models.ProjectModel _projectModel = new Models.ProjectModel();
            Models.ProjectModel.NestedClassToGetAccessToPrivateField _nestedClass = new ProjectModel.NestedClassToGetAccessToPrivateField(_projectModel);
            Example2Result = _nestedClass.GetPrivateFieldData();
            var endTime = DateTime.Now;
            Example2TimeSpan = TimeSpanCaculating(startTime, endTime);
        }

        #endregion

        #region Example 2: Expression Trees
        private void ExpressionTreesGetMethod()
        {
            var startTime = DateTime.Now;

            ProjectModel _projectModel = new Models.ProjectModel();
            ParameterExpression keeperArg = Expression.Parameter(typeof(ProjectModel), $"{_projectModel}"); // argument = ProjectModel _projectModel
            Expression privateFieldAncesor = Expression.Field(keeperArg, "_privateField"); //_projectModel._privateField
            var lambda = Expression.Lambda<Func<ProjectModel, string>>(privateFieldAncesor, keeperArg);
            var func = lambda.Compile();
            Example3Result = func(_projectModel);
            var endTime = DateTime.Now;
            Example3TimeSpan = TimeSpanCaculating(startTime, endTime);
        }

        #endregion

        #region TimeCalculating
        private string TimeSpanCaculating(DateTime startTime, DateTime endTime)
        {
            string timeSpan = (endTime - startTime)
                .TotalMilliseconds
                .ToString() + " ms";

            return timeSpan;
        }
        #endregion
    }
}
