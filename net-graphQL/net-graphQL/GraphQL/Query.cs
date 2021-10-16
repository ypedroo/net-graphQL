using System.Linq;
using net_graphQL.Database;
using net_graphQL.Models;

namespace net_graphQL.GraphQL
{
    public class Query
    {
        private readonly TimeGraphContext dbContext;

        public Query(TimeGraphContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IQueryable<Project> Projects => dbContext.Projects;
        public IQueryable<TimeLog> TimeLogs => dbContext.TimeLogs;
    }
}