namespace Business.Interfaces;

public interface IFileService
{
    string GetContentFromFile();
    void SaveContentToFile(string content);
}