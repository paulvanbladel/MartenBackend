using Marten;
using System;

namespace MartenBackend.Common
{
    public class CustomMartenLogger : IMartenLogger
    {
        public void SchemaChange(string sql)
        {
            Console.WriteLine("Executing schema change with following DDL:");
            Console.WriteLine(sql);
            Console.WriteLine();
        }

        public IMartenSessionLogger StartSession(IQuerySession session)
        {
            return new CustomSessionLogger();
        }
    }
}
