using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using BindingTypesDemo.Commands;
using BindingTypesDemo.Models;

namespace BindingTypesDemo.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private UserViewModel? _selectedUser;
        private string _searchText = string.Empty;
        private string _themeColorName = "蓝色主题";
        private bool _isAdvancedViewEnabled = false;
        
        public MainViewModel()
        {
            // 初始化用户集合
            UserViewModels = new ObservableCollection<UserViewModel>();
            
            // 添加示例用户
            AddSampleUsers();
            
            // 初始化命令
            AddUserCommand = new RelayCommand(AddUser);
            RemoveUserCommand = new RelayCommand(RemoveUser, CanRemoveUser);
            ToggleThemeCommand = new RelayCommand(ToggleTheme);
            ToggleAdvancedViewCommand = new RelayCommand(ToggleAdvancedView);
        }
        
        // 用户集合
        public ObservableCollection<UserViewModel> UserViewModels { get; }
        
        // 当前选中的用户
        public UserViewModel? SelectedUser
        {
            get => _selectedUser;
            set
            {
                if (SetProperty(ref _selectedUser, value))
                {
                    CommandManager.InvalidateRequerySuggested();
                }
            }
        }
        
        // 搜索文本
        public string SearchText
        {
            get => _searchText;
            set => SetProperty(ref _searchText, value);
        }
        
        // 主题名称
        public string ThemeColorName
        {
            get => _themeColorName;
            set => SetProperty(ref _themeColorName, value);
        }
        
        // 是否启用高级视图
        public bool IsAdvancedViewEnabled
        {
            get => _isAdvancedViewEnabled;
            set => SetProperty(ref _isAdvancedViewEnabled, value);
        }
        
        // 命令
        public ICommand AddUserCommand { get; }
        public ICommand RemoveUserCommand { get; }
        public ICommand ToggleThemeCommand { get; }
        public ICommand ToggleAdvancedViewCommand { get; }
        
        // 添加示例用户
        private void AddSampleUsers()
        {
            UserViewModels.Add(new UserViewModel(new User 
            { 
                Name = "张三", 
                Email = "zhangsan@example.com", 
                Age = 28,
                AvatarColor = "#3498db"
            }));
            
            UserViewModels.Add(new UserViewModel(new User 
            { 
                Name = "李四", 
                Email = "lisi@example.com", 
                Age = 32,
                AvatarColor = "#e74c3c"
            }));
            
            UserViewModels.Add(new UserViewModel(new User 
            { 
                Name = "王五", 
                Email = "wangwu@example.com", 
                Age = 25,
                AvatarColor = "#2ecc71"
            }));
            
            if (UserViewModels.Count > 0)
                SelectedUser = UserViewModels[0];
        }
        
        // 添加用户方法
        private void AddUser(object? parameter)
        {
            var newUser = new UserViewModel(new User
            {
                Name = "新用户",
                Email = "new@example.com",
                Age = 30,
                AvatarColor = "#9b59b6"
            });
            
            UserViewModels.Add(newUser);
            SelectedUser = newUser;
        }
        
        // 判断是否可以移除用户
        private bool CanRemoveUser(object? parameter)
        {
            return SelectedUser != null;
        }
        
        // 移除用户方法
        private void RemoveUser(object? parameter)
        {
            if (SelectedUser != null)
            {
                UserViewModels.Remove(SelectedUser);
                SelectedUser = UserViewModels.Count > 0 ? UserViewModels[0] : null;
            }
        }
        
        // 切换主题
        private void ToggleTheme(object? parameter)
        {
            if (ThemeColorName == "蓝色主题")
            {
                ThemeColorName = "绿色主题";
                
                // 更改资源字典中的资源
                var greenBrush = new System.Windows.Media.SolidColorBrush(
                    (System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#27ae60"));
                var lightGreenBrush = new System.Windows.Media.SolidColorBrush(
                    (System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#2ecc71"));
                    
                Application.Current.Resources["PrimaryBrush"] = greenBrush;
                Application.Current.Resources["AccentBrush"] = lightGreenBrush;
                
                // 输出调试信息确认资源已更新
                System.Diagnostics.Debug.WriteLine("Theme changed to Green");
            }
            else
            {
                ThemeColorName = "蓝色主题";
                
                // 恢复原始资源
                var blueBrush = new System.Windows.Media.SolidColorBrush(
                    (System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#2c3e50"));
                var lightBlueBrush = new System.Windows.Media.SolidColorBrush(
                    (System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#3498db"));
                    
                Application.Current.Resources["PrimaryBrush"] = blueBrush;
                Application.Current.Resources["AccentBrush"] = lightBlueBrush;
                
                // 输出调试信息确认资源已更新
                System.Diagnostics.Debug.WriteLine("Theme changed to Blue");
            }
        }
        
        // 切换高级视图
        private void ToggleAdvancedView(object? parameter)
        {
            IsAdvancedViewEnabled = !IsAdvancedViewEnabled;
        }
    }
} 