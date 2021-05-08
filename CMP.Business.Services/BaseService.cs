using System;

namespace CMP.Business.Services
{
    public class BaseService : IDisposable
    {
        public BaseService()
        {

        }
       
        #region IDisposable Support

        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }

        #endregion
    }
}
