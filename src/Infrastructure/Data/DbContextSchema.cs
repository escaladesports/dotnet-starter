using CleanArchitecture.Application.Common.Interfaces;

namespace CleanArchitecture.Infrastructure.Persistence
{
    public class DbContextSchema : IDbContextSchema
    {
        public string Schema { get; }

        public DbContextSchema(IUser currentUserService)
        {
            this.Schema = currentUserService.Schema;
        }
    }
}