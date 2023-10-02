namespace TMPS_Labs.Domain.Services;

public class SimpleFileService : FileService {
  public SimpleFileService(IFs fs) : base(fs) { }

  public override void SaveToFile(string fileName, string text) {
    string path = $"Generated/{fileName}";
    Fs.Remove("Generated");
    Fs.CreateDirectory("Generated");
    Fs.CreateFile(path);
    Fs.AllowReadWriteExecute(path);
    Fs.WriteToFile(path, text);
  }
}
