using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;

namespace J9Updater.AppUpgradeClient
{
    [Serializable]
    public class IndexFile : ISerializable
    {
        public string AppName { get; set; }
        public Version Version { get; set; }
        public string AppBasePath { get; set; }
        public string ExecName { get; set; }
        public List<FileDetail> Files { get; set; } = new List<FileDetail>();
        public List<string> GetFileNames() => Files.Select(item => Path.Combine(AppBasePath, item.Name)).ToList();

        public IndexFile()
        {
        }

        protected IndexFile(SerializationInfo info, StreamingContext context)
        {
            this.Version = new Version(info.GetString("Version"));
            //Files =info.
        }
        /// <summary>
        /// ʹ�ý�Ŀ��������л������������� <see cref="T:System.Runtime.Serialization.SerializationInfo"/>��
        /// </summary>
        /// <param name="info">Ҫ������ݵ� <see cref="T:System.Runtime.Serialization.SerializationInfo"/>��</param><param name="context">�����л���Ŀ�꣨��μ� <see cref="T:System.Runtime.Serialization.StreamingContext"/>����</param><exception cref="T:System.Security.SecurityException">���÷�û����Ҫ���Ȩ�ޡ�</exception>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Version", this.Version.ToString());
            info.AddValue("FileDetail", this.Files);
        }
    }
}