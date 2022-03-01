using System.Net.Sockets;

namespace Game.NetworkMessages
{
	public static class StreamExtension
	{
		/// <summary>
		/// Sends size of byte array and then array itself.
		/// </summary>
		/// <param name="networkStream"></param>
		/// <param name="bt"></param>
		public static void Write(this NetworkStream networkStream, byte[] bt)
		{
			int len = bt.Length;
			byte[] lenBt = BitConverter.GetBytes(len);
			networkStream.Write(lenBt, 0, lenBt.Length);
			networkStream.Write(bt, 0, len);
		}

		/// <summary>
		/// Reads size of array and then returns the array itself.
		/// </summary>
		/// <param name="networkStream"></param>
		/// <returns></returns>
		public static byte[] Read(this NetworkStream networkStream)
		{
			byte[] lenBt = new byte[sizeof(int)];
			networkStream.Read(lenBt, 0, lenBt.Length);
			int len = BitConverter.ToInt32(lenBt, 0);
			byte[] result = new byte[len];
			networkStream.Read(result, 0, len);
			return result;
		}

	}
}
