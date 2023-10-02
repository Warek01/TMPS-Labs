namespace TMPS_Labs.Domain.Services; 

public abstract class FileService : IFileService {
  protected IFs Fs;

  protected FileService(IFs fs) => Fs = fs;

  public abstract void SaveToFile(string fileName, string text);
}
