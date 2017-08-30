using SuperSocket.ProtoBase;
using System.Text;

public class MyReceiveFilter : TerminatorReceiveFilter<StringPackageInfo>
{
    //TODO
    public MyReceiveFilter() : base(Encoding.UTF8.GetBytes("\r\n"))
    {

    }

    public override StringPackageInfo ResolvePackage(IBufferStream bufferStream)
    {
        BufferStream buff = (BufferStream)bufferStream;
        int length = (int)buff.Length;
        string data = buff.ReadString(length, UTF8Encoding.UTF8);
        if (data != null && data != "")
        {
          //  UnityEngine.Debug.Log("data:" + data);
            string[] titleArray = data.Split(' ');
            if (titleArray.Length >= 2)
            {
                string key = titleArray[0];
                string body = data.Substring(key.Length + 1);
                //string[] strArray = body.Split(':');
                StringPackageInfo sp = new StringPackageInfo(key, body, null);
                return sp;
            }
        }
        return null;
    }
}
