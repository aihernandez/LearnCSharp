namespace J9Updater.FileTransferSvc.Ver1
{
    public enum ResponseStatus
    {

        /// <summary>
        /// X'10':������Ϣִ�гɹ���������δ��ɣ���Ҫ����������Ϣ��һ�������ļ��ϴ����أ�
        //	�����ļ��ϴ�����������ͨ���󷵻�, ֪ͨ�Է��������Ѿ����ý����ļ���׼��
        /// </summary>
        Ready = 0x10,
        /// <summary>
        /// X'20':�ɹ����Է����ִ�У��ļ��ϴ��������ش�״̬��
        /// </summary>
        Succeed = 0x20,
        /// <summary>
        /// X'30':У��ʧ��, ��Ҫ�ط��ϴ����������
        /// </summary>
        TransferError = 0x30,
        /// <summary>
        /// X'40':�ͻ��˴��� ͨ��MSG�ṩ��Ϣ����ԭ�� 
        /// </summary>
        ClientError = 0x40,
        /// <summary>
        /// X'50':����˴���
        /// </summary>
        ServerError = 0x50


    }
}