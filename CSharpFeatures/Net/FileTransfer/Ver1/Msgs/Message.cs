using System;

namespace J9Updater.FileTransferSvc.Ver1.Msgs
{
    public abstract class Message
    {
        protected Message()
        {
        }

        protected Message(byte[] rawMsg)
        {
            if ((rawMsg[0] & Ver) == 0)
                throw new Exception("��ϢЭ��汾����");
        }
        protected byte Ver = 0x10;
        public string SessionId { get; set; }
        public MessageType Type { get; protected set; }
        public abstract byte[] ToBytes();
        public static Message CreateMessage(byte[] rawMsg)
        {
            var msgType = GetMsgType(rawMsg);
            switch (msgType)
            {
                case MessageType.Handshake:
                    return new HandshakeMessage(rawMsg);
                case MessageType.Request:
                    return new RequestMessage(rawMsg);
                case MessageType.Response:
                    return new ResponseMessage(rawMsg);
                default:
                    throw new NotSupportedException($"��Ϣ����{msgType}��֧��");
            }
        }

        private static MessageType GetMsgType(byte[] rawMsg)
        {
            //ȡ��λ����Ϣ����
            var byteType = (byte)(rawMsg[0] & 0x0f);

            return Util.ReadByteToEnum<MessageType>(byteType);
        }
    }
}