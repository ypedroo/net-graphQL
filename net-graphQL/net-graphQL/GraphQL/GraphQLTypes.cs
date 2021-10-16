using HotChocolate.Types;
using net_graphQL.Models;

namespace net_graphQL.GraphQL
{
    public class Types
    {
        public class ProjectType : ObjectType<Project>
        {
        }

        public class TimeLogType : ObjectType<TimeLog>
        {
        }
    }
}