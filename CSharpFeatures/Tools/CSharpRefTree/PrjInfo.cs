using SolutionMaker.Core;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Inspur.GSP.Bom.Builder
{
    internal class PrjInfo
    {
        public PrjInfo()
        {
            PrjRef = new List<PrjInfo>();
            OriginalRef = new List<string>();
            RefError = new List<string>();
            BeRefBy = new List<PrjInfo>();
        }

        public PrjInfo(Assembly ass) : this()
        {

            this.AssemblyName = ass.GetName().Name;

            var refAssemblies = ass.GetReferencedAssemblies().Where(IsMatch);
            if (refAssemblies.Count() == 0) return;
            foreach (var refAss in refAssemblies)
            {
                this.OriginalRef.Add(refAss.Name);
            }


        }

        public PrjInfo(ProjectAnalyzer prjAnalyzer)
        {

        }

        public static bool IsMatch(AssemblyName assemblyName)
        {
            var excludeNames = new string[] { "mscorlib", "DevExpress", "Newtonsoft" };
            if (excludeNames.Any(item => assemblyName.Name.StartsWith(item))
                || assemblyName.Name.StartsWith("System") || assemblyName.Name.StartsWith("Microsoft")) return false;
            if (assemblyName.Name.StartsWith("Inspur") || assemblyName.Name.StartsWith("Genersoft") || assemblyName.Name.Contains("GSP")) return true;


            //Console.WriteLine("AssName��{0} Could Not be recognized", assemblyName.Name);
            return false;
        }

        /// <summary>
        /// ���ɲ��
        /// </summary>
        public string BuildStage { get; set; }
        /// <summary>
        /// ģ��
        /// </summary>
        public string Module { get; set; }
        /// <summary>
        /// ������
        /// </summary>
        public string DevGroup { get; set; }
        /// <summary>
        /// ProjectGuid
        /// </summary>
        public string ProjectId { get; set; }

        private string assemblyName;
        /// <summary>
        /// ����ĳ�������
        /// </summary>
        public string AssemblyName
        {
            get { return assemblyName; }
            set
            {
                assemblyName = value;
                if (assemblyName.StartsWith("Inspur") || assemblyName.StartsWith("Genersoft"))
                {
                    Module = assemblyName.Split('.')[2];
                }
                //else if (assemblyName.StartsWith("Genersoft"))
                //{
                //    Module = assemblyName.Split('.')[2]
                //}
            }
        }
        /// <summary>
        /// csproj �ļ���
        /// </summary>

        public string PrjFileName { get; set; }
        /// <summary>
        /// csproj �ļ�·��(�������ļ���)
        /// </summary>
        public string PrjFilePath { get; set; }

        public string ShortPrjPath => string.IsNullOrEmpty(PrjFullName) ? null : PrjFullName.Substring(Program.BomBuildOption.InitPath.Length);
        /// <summary>
        /// csproj �ļ�����·��
        /// </summary>
        public string PrjFullName
        {
            get
            {
                return Path.Combine(PrjFilePath ?? "", PrjFileName ?? "");
            }
            set
            {
                var absolutPrjPath = Path.Combine(Program.BomBuildOption.InitPath, value);
                if (!File.Exists(absolutPrjPath))
                    throw new FileNotFoundException("Project File Not found.",
                        absolutPrjPath);
                var prjFile = new FileInfo(absolutPrjPath);
                PrjFilePath = prjFile.DirectoryName;
                PrjFileName = prjFile.Name;
            }

        }
        /// <summary>
        /// �������·��
        /// </summary>
        public string AssemblyPath { get; set; }
        /// <summary>
        /// ��Ŀ����
        /// </summary>
        public List<PrjInfo> PrjRef { get; set; }
        /// <summary>
        /// ԭʼ�����ַ���
        /// </summary>
        public List<string> OriginalRef { get; set; }
        /// <summary>
        /// ���������
        /// </summary>
        public List<string> RefError { get; set; }
        /// <summary>
        /// ���õ�ǰ��Ŀ����Ŀ�б�
        /// </summary>
        public List<PrjInfo> BeRefBy { get; set; }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>
        /// A string that represents the current object.
        /// </returns>
        public override string ToString()
        {
            return $"Ass:{AssemblyName};" +
                   //$"\t{OriginalRef.OutputList("Ref")};" +
                   $"\t{RefError.OutputList("Error:\t")}";
        }
        public string ToString(string str)
        {
            return $"Ass:{AssemblyName};" +
                   $"\t{OriginalRef.OutputList("Ref:")};" +
                   $"\t{RefError.OutputList("Error: ")}" +
                   "\n";
        }

        public void Ref(PrjInfo refPrj)
        {
            PrjRef.Add(refPrj);
            refPrj.BeRefBy.Add(this);
        }
    }
}