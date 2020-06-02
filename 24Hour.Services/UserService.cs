using _24Hour.Data;
using _24Hour.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24Hour.Services
{
    public class UserService
    {
        private readonly Guid _userID;           // Was a GUID
        public UserService(Guid userID)          // Was a GUID
        {
            _userID = userID;
        }
        public bool CreateUser(UserCreate model)
        {
            var entity =
                new User()
                {
                    UserID = _userID,
                    Name = model.Name,
                    Email = model.Email,
                    CreatedUtc = DateTimeOffset.Now
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Users.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<UserListItem> GetUsers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Users
                        .Where(e => e.UserID == _userID)
                        .Select(
                            e =>
                                new UserListItem
                                {
                                    UserID = e.UserID,
                                    Name = e.Name,
                                    Email = e.Email,
                                    CreatedUtc = e.CreatedUtc
                                }
                        );
                return query.ToArray();
            }
        }
        public UserDetail GetUserByID(Guid userID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Users
                        .Single(e => e.UserID == userID && e.UserID == _userID);
                return
                    new UserDetail
                    {
                        UserID = entity.UserID,
                        Name = entity.Name,
                        Email = entity.Email,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }
        public bool UpdateUser(UserEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Users
                        .Single(e => e.UserID == model.UserID && e.UserID == _userID);
                entity.Name = model.Name;
                entity.Email = model.Email;
                entity.UserID = model.UserID;
                //entity.ModifiedUtc = DateTimeOffset.UtcNow;
                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteUser(Guid userID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Users
                        .Single(e => e.UserID == userID && e.UserID == _userID);
                ctx.Users.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
