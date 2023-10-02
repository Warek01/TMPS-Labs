namespace TMPS_Labs.Domain.Services;

public interface IFs {
  void CreateFile(string            fileName);
  void CreateDirectory(string       dirName);
  void AllowReadWriteExecute(string pathName);
  void WriteToFile(string           fileName, string text);
  void Remove(string                fileName);
}
