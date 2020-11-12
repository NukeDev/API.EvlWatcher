using System.Data.EntityClient;
using System.Data.Objects;
using System.Data.Objects.DataClasses;

[assembly: EdmSchemaAttribute()]
namespace api.evl.watch
{

    public partial class EvlWatchContext : ObjectContext
    {

        public EvlWatchContext() : base("name=EvlWatchContext", "EvlWatchContext")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }


        public EvlWatchContext(string connectionString) : base(connectionString, "EvlWatchContext")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }


        public EvlWatchContext(EntityConnection connection) : base(connection, "EvlWatchContext")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }

        partial void OnContextCreated();
    }
}
