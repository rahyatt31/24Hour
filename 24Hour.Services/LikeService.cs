using _24Hour.Data;
using _24Hour.Models.Like;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace _24Hour.Services
{
    public class LikeService
    {
        private readonly Guid _userID;
        public LikeService(Guid userID)
        {
            _userID = userID;
        }
        public bool CreateLike(LikeCreate model)
        {
            var entity = new Like()
            {
                UserID = model.UserID,
                CreatedUtc = DateTimeOffset.Now
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Likes.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<LikeListItem> GetLikes()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Likes
                        .Where(e => e.UserID == _userID)
                        .Select(
                            e =>
                                new LikeListItem
                                {
                                    LikedPost = e.LikedPost,
                                    CreatedUtc = e.CreatedUtc
                                }
                        );
                return query.ToArray();
            }
        }
        public LikeDetail GetLikeById(int likeID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Likes
                        .Single(e => e.LikeID == likeID && e.UserID == _userID);
                return
                    new LikeDetail
                    {
                        LikeID = entity.LikeID,
                        LikedPost = entity.LikedPost,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }
        public bool UpdateLike(LikeEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Likes
                        .Single(e => e.LikeID == model.LikeID && e.UserID == _userID);
                entity.LikedPost = model.LikedPost;
                //entity.ModifiedUtc = DateTimeOffset.UtcNow;
                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteLike(int likeId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Likes
                        .Single(e => e.LikeID == likeId && e.UserID == _userID);
                ctx.Likes.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}