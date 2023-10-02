namespace TMPS_Labs.Domain.Services; 

public interface IFileService {
  void SaveToFile(string fileName, string text);
}
