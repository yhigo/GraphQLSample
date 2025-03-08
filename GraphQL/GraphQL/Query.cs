namespace GraphQLSample.API.GraphQL
{

    [GraphQLDescription("Queries for the book library")]
    public class Query
    {
        [GraphQLDescription("Get all books in the library")]
        public long GetLongValue()
        {
            return 42;
        }
    }
}
