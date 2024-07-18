using CustomerManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.DTO
{
    /*
    public class UserDTO{
        
        public string UserName {get;set;}
        public string Phone {get;set;}
        public string Email {get;set;}
        public string Password {get;set;}
        public string Address {get;set;}
        public bool IsActive {get;set;}
        public string GenderName {get;set;}
        public string RoleName {get;set;}
        public DateTimeOffset CreatedDate {get;set;}

    public UserDTO(string userName, string phone, string email, string password, string address, bool isActive, string Gender, string Role, DateTimeOffset createdDate)
        {
            UserName = userName;
            Phone = phone;
            Email = email;
            Password = password;
            Address = address;
            IsActive = isActive;
            GenderName = Gender;
            RoleName = Role;
            CreatedDate = createdDate;
        }
    }
    */
    public record CreateUserDTO(
        string UserName,
        string Phone,
        string Email,
        string Password,
        string Address,
        bool IsActive,
        int CreatedBy,
        int GenderId,
        int RoleId
    );
    public record UpdateUserDTO(
        int UserId,
        string UserName,
        string Phone,
        string Email,
        string Password,
        string Address,
        bool IsActive,
        int GenderId,
        int RoleId
    );
    public record UserDTO(
        string UserName,
        string Phone,
        string Email,
        string Address,
        string Gender,
        string Role,
        DateTimeOffset CreatedDate
    );
}