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
        private readonly int _likeID; //Need to be Guid?
        public LikeService(int likeID)
        {
            _likeID = likeID;
        }
        public bool CreateLike(LikeCreate model)
        {
            var entity = new Like()
            {
                LikeID = _likeID,
                LikedPost = model.LikedPost,
                Liker = model.Liker,
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
                        .Where(e => e.LikeID == _likeID)
                        .Select(
                            e =>
                                new LikeListItem
                                {
                                    LikedPost = e.LikedPost,
                                    Liker = e.Liker,
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
                        .Single(e => e.LikeID == likeID && e.LikeID == _likeID);
                return
                    new LikeDetail
                    {
                        LikeID = entity.LikeID,
                        LikedPost = entity.LikedPost,
                        Liker = entity.Liker,
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
                        .Single(e => e.LikeID == model.LikeID && e.LikeID == _likeID);
                entity.LikedPost = model.LikedPost;
                entity.Liker = model.Liker;
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
                        .Single(e => e.LikeID == likeId && e.LikeID == _likeID);
                ctx.Likes.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}