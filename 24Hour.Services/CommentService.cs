using _24Hour.Data;
using _24Hour.Models.Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace _24Hour.Services
{
    public class CommentService
    {
        private readonly Guid _userID; // Need to be Guid?
        public CommentService(Guid userID)
        {
            _userID = userID;
        }
        public bool CreateComment(CommentCreate model)
        {
            var entity = new Comment()
            {
                CommentText = model.CommentText,
                UserID = model.UserID,
                CommentPost = model.CommentPost,
                CreatedUtc = DateTimeOffset.Now
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Comments.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<CommentListItem> GetComments()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Comments
                        .Where(e => e.UserID == _userID)
                        .Select(
                            e =>
                                new CommentListItem
                                {
                                    CommentID = e.CommentID,
                                    CommentText = e.CommentText,
                                    UserID = e.UserID,
                                    CreatedUtc = e.CreatedUtc
                                }
                        );
                return query.ToArray();
            }
        }
        public CommentDetail GetCommentByID(int commentID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Comments
                        .Single(e => e.CommentID == commentID && e.UserID == _userID);
                return
                    new CommentDetail
                    {
                        CommentID = entity.CommentID,
                        CommentText = entity.CommentText,
                        UserID = entity.UserID,
                        CommentPost = entity.CommentPost,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }
        public bool UpdateComment(CommentEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Comments
                        .Single(e => e.CommentID == model.CommentID && e.UserID == _userID);
                entity.CommentID = model.CommentID;
                entity.CommentText = model.CommentText;
                entity.UserID = model.UserID;
                entity.CommentPost = model.CommentPost;
                //entity.ModifiedUtc = DateTimeOffset.UtcNow;
                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteComment(int commentID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Comments
                        .Single(e => e.CommentID == commentID && e.UserID == _userID);
                ctx.Comments.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
