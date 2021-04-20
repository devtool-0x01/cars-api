
namespace dotnet5api.Data
{
  public static class DbInitializer
  {
    public static void Initialize(HyperdriveDbContext context)
    {
      context.Database.EnsureCreated();
    }
  }
}