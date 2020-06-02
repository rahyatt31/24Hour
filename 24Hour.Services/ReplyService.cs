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
        private readonly int _replyID; // Need to be Guid?
        public ReplyService(int replyID)
        {
            _replyID = replyID;
        }
        public bool CreateReply(ReplyCreate model)
        {
            var entity = new Reply()
            {
                ReplyID = _replyID,
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
                        .Where(e => e.ReplyID == _replyID)
                        .Select(
                            e =>
                                new ReplyListItem
                                {
                                    ReplyID = _replyID,
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
                        .Single(e => e.ReplyID == replyID && e.ReplyID == _replyID);
                return
                    new ReplyDetail
                    {
                        ReplyID = _replyID,
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
                        .Single(e => e.ReplyID == model.ReplyID && e.ReplyID == _replyID);
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
                        .Single(e => e.ReplyID == replyID && e.ReplyID == _replyID);
                ctx.Replies.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}

