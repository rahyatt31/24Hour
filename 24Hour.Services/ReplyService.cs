using _24Hour.Data;
using _24Hour.Models.Reply;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace _24Hour.Services
{
    public class ReplyService
    {
        private readonly Guid _userID; // Need to be Guid?
        public ReplyService(Guid userID)
        {
            _userID = userID;
        }
        public bool CreateReply(ReplyCreate model)
        {
            var entity = new Reply()
            {
                ReplyTitle = model.ReplyTitle,
                ReplyText = model.ReplyText,
                UserID = model.UserID,
                CreatedUtc = DateTimeOffset.Now
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Replies.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<ReplyListItem> GetReplies()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Replies
                        .Where(e => e.UserID == _userID)
                        .Select(
                            e =>
                                new ReplyListItem
                                {
                                    ReplyID = e.ReplyID,
                                    ReplyTitle = e.ReplyTitle,
                                    ReplyText = e.ReplyText,
                                    UserID = e.UserID,
                                    CreatedUtc = e.CreatedUtc
                                }
                        );
                return query.ToArray();
            }
        }
        public ReplyDetail GetReplyByID(int replyID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Replies
                        .Single(e => e.ReplyID == replyID && e.UserID == _userID);
                return
                    new ReplyDetail
                    {
                        ReplyID = entity.ReplyID,
                        ReplyTitle = entity.ReplyTitle,
                        ReplyText = entity.ReplyText,
                        UserID = entity.UserID,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }
        public bool UpdateReply(ReplyEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Replies
                        .Single(e => e.ReplyID == model.ReplyID && e.UserID == _userID);
                entity.ReplyID = model.ReplyID;
                entity.ReplyTitle = model.ReplyTitle;
                entity.ReplyText = model.ReplyText;
                entity.UserID = model.UserID;
                //entity.ModifiedUtc = DateTimeOffset.UtcNow;
                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteReply(int replyID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Replies
                        .Single(e => e.ReplyID == replyID && e.UserID == _userID);
                ctx.Replies.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}

