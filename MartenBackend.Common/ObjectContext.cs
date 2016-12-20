using Marten;

namespace MartenBackend.Common
{
    public class ObjectContext
    {
        private DocumentStore _store;
        public ObjectContext(string connectionString)
        {
            _store = DocumentStore.For(configure =>
           {
               configure.Connection(connectionString);
           });
        }
        public DocumentStore GetStore()
        {
            return _store;
        }
    }
}