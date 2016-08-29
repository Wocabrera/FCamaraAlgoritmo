using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationStreamRead {
  public class MyStream : IStream {

    public MyStream(byte[] b) {
      byteArray = b;
      this.stream = new MemoryStream(byteArray, 0, byteArray.Length);
    }

    public byte[] byteArray { get; set; }
    public Stream stream { get; set; }

    public string u = String.Empty;
    public char getNext() {
      return (Char)stream.ReadByte();
    }

    public bool hasNext() {
      if (byteArray.Length > stream.Position)
        return true;
      return false;
    }

  }
}
