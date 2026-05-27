using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Core
{
    public class ResourceManager : IDisposable
    {
        private StreamWriter writer;
        private bool disposed = false;

        public ResourceManager(string filePath)
        {
            writer = new StreamWriter(filePath, true);
            writer.WriteLine("ResourceManager started: " + DateTime.Now);
        }

        public void WriteLog(string message)
        {
            if (disposed)
            {
                throw new ObjectDisposedException("ResourceManager");
            }

            writer.WriteLine(DateTime.Now + ": " + message);
        }

        public void Dispose()
        {
            if (!disposed)
            {
                writer.WriteLine("ResourceManager disposed: " + DateTime.Now);
                writer.Close();
                writer.Dispose();
                disposed = true;
            }
        }
    }
}
