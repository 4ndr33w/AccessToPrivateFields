using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessToPrivateFields.Models
{
    internal class ProjectModel
    {
        private string _privateField = "Private Field Text";

        private static string _privateStaticField = "Private Static Field Of NonStatic Class";

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

    internal static class StaticProjectModel
    {
        private static string _privateStaticField = "Private Static Field Of Static Class";
    }
}
