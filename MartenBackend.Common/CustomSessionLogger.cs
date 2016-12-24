using Marten;
using System;
using Marten.Services;
using Npgsql;
using System.Linq;
namespace MartenBackend.Common
{
    public class CustomSessionLogger : IMartenSessionLogger
    {
        public void LogFailure(NpgsqlCommand command, Exception ex)
        {
            Console.WriteLine("Postgresql comamnd failed");
            Console.WriteLine(command.CommandText);
            Console.WriteLine(ex);
        }

        public void LogSuccess(NpgsqlCommand command)
        {
            Console.WriteLine($"CommandText= {command.CommandText}");
            Console.WriteLine("Parameters");
            foreach (NpgsqlParameter parameter in command.Parameters)
            {
                Console.WriteLine($"Parameter {parameter.ParameterName} = {parameter.Value}");
            }
            Console.WriteLine("SQL Statements");
            foreach (NpgsqlStatement statement in command.Statements)
            {
                Console.WriteLine(statement.SQL);
            }
        }

        public void RecordSavedChanges(IDocumentSession session, IChangeSet commit)
        {
            var lastCommit = commit;
            Console.WriteLine($"Persisted {lastCommit.Updated.Count()} updates, " +
                $"{lastCommit.Inserted.Count()} inserted and {lastCommit.Deleted.Count()} deletions");
        }
    }
}
