namespace AccessToPrivateFields.Models
{
    internal class ProjectModel
    {
        private string _privateField = "Private Field Text";

        public class NestedClassToGetAccessToPrivateField
        {
            private readonly ProjectModel _project;
            public NestedClassToGetAccessToPrivateField(ProjectModel project)
            {
                this._project = project;
            }
            public string GetPrivateFieldData() => this._project._privateField;
        }
    }
}
