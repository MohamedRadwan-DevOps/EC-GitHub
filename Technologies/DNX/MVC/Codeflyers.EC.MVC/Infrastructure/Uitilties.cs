using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Codeflyers.EC.MVC.Infrastructure
{
    public class Uitilties
    {
        public static byte[] ObjectToByteArray(dynamic obj)
        {
            if (obj == null)
                return null;
            var bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }
        }
    }
}
