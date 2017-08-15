namespace Inspur.Gsp.CSharpIntroduction.Demo.OO
{
    /// <summary>
    /// ����è
    /// </summary>
    public class MachineCat : Cat, IChange
    {

        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="name"></param>
        public MachineCat(string name) : base(name)
        {

        }

        /// <summary>
        /// �������
        /// </summary>
        /// <param name="thing"></param>
        public object Change(string thing)
        {
            return $"Take out a {thing} from pocket";
        }
    }
}