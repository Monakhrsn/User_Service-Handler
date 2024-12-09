
using Business.Interfaces;
using Business.Services;
using MainApp.Dialogs;

IFileService fileService = new FileService("Data", "content.json");
IUserService userService = new UserService(fileService);
var menu = new MenuDialog(userService);

menu.ViewAllUsersOption();
menu.NewRegularUserOption();
menu.NewAdminUserOption();
menu.ViewAllUsersOption(); 