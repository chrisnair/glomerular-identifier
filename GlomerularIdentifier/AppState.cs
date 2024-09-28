namespace GlomerularIdentifier;

public class AppState : IAppState
{
    public string Message { get; set; } =  string.Empty;
    public int Count { get; set; }

    public double ZoomLevel { get; set; }
    public DateTime LastStorageSaveTime { get; set; }
}