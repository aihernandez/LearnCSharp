using System;
using System.Diagnostics;
using System.IO;
using System.Net.Sockets;

namespace J9Updater.FileTransferSvc.Ver1
{

    [DebuggerDisplay("File={FileInfo.Name},FileSize={FileSize},TransmitedByteCount={TransmitedByteCount},DealingByteCount={DealingByteCount}")]
    public class FileTransmitState
    {

        /// <summary>
        /// �ļ���
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// �ļ�
        /// </summary>
        public FileInfo FileInfo { get; set; }

        /// <summary>
        /// �ļ���С
        /// </summary>
        public long FileSize { get; set; } = -1;
        /// <summary>
        /// �ļ���
        /// </summary>
        public Stream FileStream { get; set; }
        /// <summary>
        /// �ļ���д�����е����ݻ���
        /// </summary>
        public byte[] Buffer { get; set; }

        /// <summary>
        /// ����
        /// </summary>
        public Socket Connection { get; set; }
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
        public int TotalCount => (int)FileSize / Buffer.Length;

        /// <summary>
        /// ʣ����Ҫ����Ŀ������
        /// </summary>
        public int RemainCount
        {
            get
            {
                return TotalCount - Count;
            }
        }

        /// <summary>
        /// �������״̬
        /// </summary>
        public int TransmitState { get; set; }

        /// <summary>
        /// ���������Ļص�
        /// </summary>
        public Action<FileTransmitState> AfterTransmitCallback { get; set; }


        /// <summary>
        /// �ر������Դ
        /// </summary>
        public void Close()
        {
            Logging.Debug("Closing State...");
            try
            {
                FileStream?.Close();
                if (Connection == null) return;
                if (Connection.Connected)
                {
                    Connection.Shutdown(SocketShutdown.Both);
                }
                Connection.Close();
            }
            catch (Exception e)
            {
                Logging.LogUsefulException(e);
            }

        }
    }
}