using _24Hour.Data;
using _24Hour.Models.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24Hour.Services
{
    public class ProfileService
    {
        private readonly Guid _userID;           // Was a GUID
        public ProfileService(Guid userID)          // Was a GUID
        {
            _userID = userID;
        }
        public bool CreateProfile(ProfileCreate model)
        {
            var entity =
                new Profile()
                {
                    UserID = _userID,
                    Name = model.Name,
                    Email = model.Email,
                    CreatedUtc = DateTimeOffset.Now
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Profiles.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<ProfileListItem> GetProfiles()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Profiles
                        .Where(e => e.UserID == _userID)
                        .Select(
                            e =>
                                new ProfileListItem
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
        public ProfileDetail GetProfileByID(Guid userID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Profiles
                        .Single(e => e.UserID == userID && e.UserID == _userID);
                return
                    new ProfileDetail
                    {
                        UserID = entity.UserID,
                        Name = entity.Name,
                        Email = entity.Email,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }
        public bool UpdateProfile(ProfileEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Profiles
                        .Single(e => e.UserID == model.UserID && e.UserID == _userID);
                entity.Name = model.Name;
                entity.Email = model.Email;
                entity.UserID = model.UserID;
                //entity.ModifiedUtc = DateTimeOffset.UtcNow;
                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteProfile(Guid userID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Profiles
                        .Single(e => e.UserID == userID && e.UserID == _userID);
                ctx.Profiles.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
