using BindingTypesDemo.Models;

namespace BindingTypesDemo.ViewModels
{
    public class UserViewModel : ViewModelBase
    {
        private User _user;
        
        public UserViewModel(User user)
        {
            _user = user;
        }
        
        public string Name 
        { 
            get => _user.Name; 
            set 
            { 
                if (_user.Name != value) 
                { 
                    _user.Name = value; 
                    OnPropertyChanged(); 
                } 
            } 
        }
        
        public string Email 
        { 
            get => _user.Email; 
            set 
            { 
                if (_user.Email != value) 
                { 
                    _user.Email = value; 
                    OnPropertyChanged(); 
                } 
            } 
        }
        
        public int Age 
        { 
            get => _user.Age; 
            set 
            { 
                if (_user.Age != value) 
                { 
                    _user.Age = value; 
                    OnPropertyChanged(); 
                } 
            } 
        }
        
        public string AvatarColor 
        { 
            get => _user.AvatarColor; 
            set 
            { 
                if (_user.AvatarColor != value) 
                { 
                    _user.AvatarColor = value; 
                    OnPropertyChanged(); 
                } 
            } 
        }
    }
} 