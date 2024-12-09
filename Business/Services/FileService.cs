using Business.Interfaces;

namespace Business.Services;

public class FileService(string directoryPath, string fileName) : IFileService
{
    private readonly string _directoryPath = directoryPath;
    private readonly string _filePath = Path.Combine(directoryPath, fileName);

        public void SaveContentToFile(string content)
        {
            if (!Directory.Exists(_directoryPath))
                Directory.CreateDirectory(_directoryPath);
            
            File.WriteAllText(_filePath, content);
        }
        
        public string GetContentFromFile()
        {
            return File.Exists(_filePath) ? File.ReadAllText(_filePath) : null!;
        }
}