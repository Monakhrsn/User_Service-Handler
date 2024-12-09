using System.Text.Json;
using Business.Helpers;
using Business.Interfaces;
using Business.Models;

namespace Business.Services;

public class UserService(IFileService fileService) : IUserService
{
    private readonly IFileService _fileService = fileService;
    private List<BaseUser> _users = [];

    private readonly JsonSerializerOptions _jso = new()
    {
        WriteIndented = true,
        Converters = { new BaseUserConverter() }
    };
    
    public bool AddUser(BaseUser user)
    { 
        try
        {
            user.Id = _users.Count() != 0 ? _users.Last().Id + 1 : 1;
            _users.Add(user);
            
            var json = JsonSerializer.Serialize(_users, _jso);
            _fileService.SaveContentToFile(json);

            return true;
        }
        catch 
        {
            return false;
        }
    }
    
    public IEnumerable<BaseUser> GetAllUsers()
    {
        _users = GetContentFromFile();
        return _users;
    }

    public BaseUser? GetUserById(int id)
    {
        _users = GetContentFromFile();
        var user = _users.FirstOrDefault(u => u.Id == id);
        return user;
    }

    private List<BaseUser> GetContentFromFile()
    {
        var json = _fileService.GetContentFromFile();
        if (string.IsNullOrEmpty(json)) return [];
        var list = JsonSerializer.Deserialize<List<BaseUser>>(json, _jso) ?? [];
        return list;

    }
}