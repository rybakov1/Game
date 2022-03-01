using Newtonsoft.Json.Bson;
using Newtonsoft.Json;

namespace Game.NetworkMessages
{
    public class Message
    {
        public float PosX { get; set; }
        public float PosY { get; set; }
        public int PlayerHp { get; set; }

        public byte[] ToByteArray()
		{
            return (byte[])this;
		}

        public static Message FromByteArray(byte[] bt)
		{
            return (Message)bt;
		}

        public static explicit operator Message(byte[] bt)
        {
            Message msg;
            MemoryStream ms = new(bt);
            BsonDataReader reader = new(ms);
            JsonSerializer serializer = new();
            msg = serializer.Deserialize<Message>(reader);
            return msg;
        }

        public static explicit operator byte[](Message msg)
        {
            MemoryStream ms = new();
            BsonDataWriter writer = new(ms);
            JsonSerializer serializer = new();
            serializer.Serialize(writer, msg);
            return ms.ToArray();
        }



        }
}
