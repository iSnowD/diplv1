using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;


namespace WebApplication6.Model
{
    public interface IRepository
    {
        #region Role
        IQueryable<Role> Roles { get; }

        bool CreateRole(Role instance);

        bool UpdateRole(Role instance);

        bool RemoveRole(int idRole);

        #endregion


        #region User

        IQueryable<User> Users { get; }

        bool CreateUser(User instance);

        bool UpdateUser(User instance);

        bool RemoveUser(int idUser);
        User GetUser(string email);
        User Login(string email, string password);
        #endregion


        #region UserRole

        IQueryable<UserRole> UserRoles { get; }

        bool CreateUserRole(UserRole instance);

        bool UpdateUserRole(UserRole instance);

        bool RemoveUserRole(int idUserRole);

        
        #endregion



        #region News
        IQueryable<News> News { get; }
        bool CreateNew(News instance);

        bool UpdateNew(News instance);

        bool RemoveNew(int idNewr);


        #endregion

        #region Visits

        IQueryable<Visits> Visits { get; }

        bool CreateVisit(Visits instance);

        bool UpdateVisit(Visits instance);

        bool RemoveVisit(int idUser);

        #endregion

        IQueryable<ServiceType> Services { get; }
        IQueryable<Times> Times { get; }
    }
}