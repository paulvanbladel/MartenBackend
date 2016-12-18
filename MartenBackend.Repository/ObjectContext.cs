using Marten;

namespace MartenBackend.Repository
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