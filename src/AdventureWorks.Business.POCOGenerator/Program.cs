using CodegenCS;
using System;
using System.IO;

namespace AdventureWorks.Business.POCOGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            string projectFolder = System.IO.Path.Combine(CodegenCS.Utils.IO.GetCurrentDirectory().FullName, @"..\AdventureWorks.Business");
            CodegenContext context = new CodegenContext(outputFolder: projectFolder + "\\GeneratedCode");
            Generator generator = new Generator(
                context: context,
                createConnection: () => new System.Data.SqlClient.SqlConnection(@"
                    Data Source=LENOVOFLEX5\SQLEXPRESS;
                    Initial Catalog=AdventureWorks;
                    Integrated Security=True;
                    Application Name=EntityFramework POCO Generator"
                ),
                targetFrameworkVersion: 4.72m
                );
            generator.GenerateMultipleFiles(); // generates in memory

            // since no errors, first modify csproj, then we save all files

            // Generate all files and add each into to the csproj
            MSBuildProjectEditor editor = new MSBuildProjectEditor(projectFilePath: projectFolder + @"\AdventureWorks.Business.csproj");
            //string templateFile = Path.Combine(CodegenCS.Utils.IO.GetCurrentDirectory().FullName);
            foreach (var o in context.OutputFilesAbsolute)
                editor.AddItem(itemPath: o.Key, itemType: o.Value.ItemType);
            editor.Save();
            context.SaveFiles(deleteOtherFiles: true);
        }
    }
}
