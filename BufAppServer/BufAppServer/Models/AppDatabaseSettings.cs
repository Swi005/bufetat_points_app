namespace BufAppServer.Models;

public class AppDatabaseSettings
{
    public string ConnectionString { get; set; } = null!;

    public string DatabaseName { get; set; } = null!;

    public string UserCollectionName { get; set; } = null!;
    public string AdminCollectionName { get; set; } = null!;
    public string BrukerCollectionName { get; set; } = null!;
    public string EventCollectionName { get; set; } = null!;
}