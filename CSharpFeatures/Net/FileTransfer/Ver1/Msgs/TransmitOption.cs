using System;

namespace J9Updater.FileTransferSvc.Ver1.Msgs
{
    /// <summary>
    /// �������
    /// ����Э��˫������Ϣ��ʽ�ʹ������
    /// </summary>
    [Flags]
    public enum TransmitOption
    {
        /// <summary>
        /// X'00 00':Ĭ�ϣ��޸�������
        /// </summary>
        None = 0x00,
        /// <summary>
        /// X'00 01':ʹ�������֤
        /// </summary>
        NeedAuth = 0x01,
        /// <summary>
        /// X'00 02':��Ϣ���ݼ��ܣ�AES�㷨���Գ���Կ���ܣ�
        /// </summary>
        Encryption = 0x02,
        /// <summary>
        /// X'00 04':��Ҫ���ֻỰ
        /// </summary>
        Session = 0x04,
        /// <summary>
        /// X'00 08':����ѹ������
        /// </summary>
        Zip = 0x08,
        /// <summary>
        /// X'00 16':����ͨѶ������Ҫ������Ӧ
        /// </summary>
        OneWay = 0x10
    }
}