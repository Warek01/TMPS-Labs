using System.Diagnostics;
using System.Text;

namespace TMPS_Labs.Domain.Services;

public class LinuxFs : IFs {
  public void CreateFile(string fileName) {
    Exec($"touch {fileName}");
  }

  public void CreateDirectory(string dirName) {
    Exec($"mkdir {dirName}");
  }

  public void AllowReadWriteExecute(string path) {
    Exec($"chmod u+rwx {path}");
  }

  public void WriteToFile(string fileName, string text) {
    IEnumerable<string> lines = text.Split("\n");
    foreach (string part in lines) {
      Exec($"echo {part} >> {fileName}");
    }
  }

  public void Remove(string fileName) {
    Exec($"rm -rf {fileName}");
  }

  private static void Exec(string cmd) {
    string escapedArgs = cmd
      .Replace("\"", "\\\"")
      .Replace("'","\\'")
      .Replace("(", "\\(")
      .Replace(")", "\\)");

    using Process process = new();

    process.StartInfo = new ProcessStartInfo {
      RedirectStandardOutput = true,
      UseShellExecute        = false,
      CreateNoWindow         = true,
      WindowStyle            = ProcessWindowStyle.Hidden,
      FileName               = "/bin/bash",
      Arguments              = $"-c \"{escapedArgs}\"",
      StandardOutputEncoding = Encoding.Unicode,
    };

    process.Start();
    process.WaitForExit();
  }
}
