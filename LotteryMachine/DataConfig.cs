using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotteryMachine
{
    [Serializable]
    class DataConfig : IDisposable
    {
        bool disposed = false;

        public string Label1 { get; set; }
        public string Label1Content { get; set; }
        public string Label2 { get; set; }
        public string Label2Content { get; set; }
        public string Label3 { get; set; }
        public string Label3Content { get; set; }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {

            }
            disposed = true;
        }
    }
}
