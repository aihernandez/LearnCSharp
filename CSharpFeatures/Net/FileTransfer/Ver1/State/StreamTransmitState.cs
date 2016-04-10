using System;
using System.Diagnostics;
using System.IO;

namespace J9Updater.FileTransferSvc.Ver1
{
    [DebuggerDisplay("Size={Size},TransmitedByteCount={TransmitedByteCount},DealingByteCount={DealingByteCount}")]
    internal class StreamTransmitState
    {
        /// <summary>
        /// �ļ���С
        /// </summary>
        public long Size { get; set; }
        /// <summary>
        /// �ļ���
        /// </summary>
        public Stream Stream { get; set; }
        /// <summary>
        /// �ļ���д�����е����ݻ���
        /// </summary>
        public byte[] Buffer { get; set; }
        /// <summary>
        /// �Ѿ�ִ�еĴ������������
        /// </summary>
        public int Count { get; set; }
        /// <summary>
        /// �Ѿ�������ֽ���
        /// </summary>
        public int TransmitedByteCount { get; set; }

        /// <summary>
        /// ʵ���Ѿ�������ֽ���
        /// </summary>
        public int DealingByteCount { get; set; }
        /// <summary>
        /// ʵ���Ѿ�ִ�д���Ŀ������
        /// </summary>
        public int TotalCount => (int)(Size / Buffer.Length);

        /// <summary>
        /// ʣ����Ҫ����Ŀ������
        /// </summary>
        public int RemainCount => TotalCount - Count;

        /// <summary>
        /// �������״̬
        /// </summary>
        public int TransmitState { get; set; }

        /// <summary>
        /// ���������Ļص�
        /// </summary>
        public Action<StreamTransmitState> AfterTransmitCallback { get; set; }
    }
}