namespace GlomerularIdentifier;

public interface IAppState
{
    string Message { get; set; }
    int Count { get; set; }

    double ZoomLevel { get; set; }
    DateTime LastStorageSaveTime { get; set; }
}