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
        private readonly int _commentID; // Need to be Guid?
        public CommentService(int commentID)
        {
            _commentID = commentID;
        }
        public bool CreateComment(CommentCreate model)
        {
            var entity = new Comment()
            {
                CommentID = _commentID,
                CommentText = model.CommentText,
                CommentAuthor = model.CommentAuthor,
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
                        .Where(e => e.CommentID == _commentID)
                        .Select(
                            e =>
                                new CommentListItem
                                {
                                    CommentID = e.CommentID,
                                    CommentText = e.CommentText,
                                    CommentAuthor = e.CommentAuthor,
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
                        .Single(e => e.CommentID == commentID && e.CommentID == _commentID);
                return
                    new CommentDetail
                    {
                        CommentID = entity.CommentID,
                        CommentText = entity.CommentText,
                        CommentAuthor = entity.CommentAuthor,
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
                        .Single(e => e.CommentID == model.CommentID && e.CommentID == _commentID);
                entity.CommentID = model.CommentID;
                entity.CommentText = model.CommentText;
                entity.CommentAuthor = model.CommentAuthor;
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
                        .Single(e => e.CommentID == commentID && e.CommentID == _commentID);
                ctx.Comments.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
