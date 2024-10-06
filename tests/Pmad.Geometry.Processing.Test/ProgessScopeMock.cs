using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pmad.ProgressTracking;

namespace Pmad.Geometry.Processing.Test
{
    class ProgessScopeMock : IProgressScope, IProgressInteger
    {
        public int Total;

        public int Done;

        public CancellationToken CancellationToken => throw new NotImplementedException();

        public IProgressInteger CreateInteger(string name, int total)
        {
            Total = total;
            return this;
        }

        public IProgressLong CreateLong(string name, long total)
        {
            throw new NotImplementedException();
        }

        public IProgressPercent CreatePercent(string name)
        {
            throw new NotImplementedException();
        }

        public IProgressScope CreateScope(string name, int estimatedChildrenCount = 0)
        {
            throw new NotImplementedException();
        }

        public IProgressScope CreateScope(string name, int estimatedChildrenCount, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public IProgressBase CreateSingle(string name)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {

        }

        public void Failed(Exception ex)
        {
            throw new NotImplementedException();
        }

        public void Report(string value)
        {
            throw new NotImplementedException();
        }

        public void Report(int value)
        {
            throw new NotImplementedException();
        }

        public void ReportOneDone()
        {
            Interlocked.Increment(ref Done);
        }

        public void WriteLine(string message)
        {
            throw new NotImplementedException();
        }
    }
}
