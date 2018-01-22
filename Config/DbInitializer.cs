using Microsoft.EntityFrameworkCore;

namespace poptwit
{
    public static class DbInitializer
    {
        public static void Initialize(PopContext context)
        {
            context.Database.EnsureCreated();
            context.Database.Migrate();
        }
    }
}