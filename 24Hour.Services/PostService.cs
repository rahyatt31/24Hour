using _24Hour.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _24Hour.Models.Post;
    
    namespace _24Hour.Services
    {
        public class PostService
        {
        //private readonly int _postID; -- Do not actually need -- Was a GUID
        private readonly Guid _userID;
            public PostService(Guid userID)
            {
                _userID = userID;
            }
            public bool CreatePost(PostCreate model)
            {
                var entity =
                    new Post()
                    {
                        //PostID = _postID -- Do not actually need
                        PostTitle = model.PostTitle,
                        PostText = model.PostText,
                        UserID = model.UserID,
                        CreatedUtc = DateTimeOffset.Now,
                    };
                using (var ctx = new ApplicationDbContext())
                {
                    ctx.Posts.Add(entity);
                    return ctx.SaveChanges() == 1;
                }
            }
            public IEnumerable<PostListItem> GetPosts()
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var query =
                        ctx
                            .Posts
                            .Where(e => e.UserID == _userID) //Filters out entities that have a userId that doesn't match the current logged in user
                            .Select(
                                e =>
                                    new PostListItem
                                    {
                                        PostID = e.PostID,
                                        PostTitle = e.PostTitle,
                                        PostText = e.PostText,
                                        UserID = e.UserID,
                                        CreatedUtc = e.CreatedUtc
                                    }
                            );
                    return query.ToArray();
                }
            }
            public PostDetail GetPostByID(int postID)
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var entity =
                        ctx
                            .Posts
                            .Single(e => e.PostID == postID && e.UserID == _userID);
                    return
                        new PostDetail
                        {
                            PostID = entity.PostID,
                            PostTitle = entity.PostTitle,
                            PostText = entity.PostText,
                            UserID = entity.UserID,
                            CreatedUtc = entity.CreatedUtc,
                            ModifiedUtc = entity.ModifiedUtc
                        };
                }
            }
            public bool UpdatePost(PostEdit model)
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var entity =
                        ctx
                            .Posts
                            .Single(e => e.PostID == model.PostID && e.UserID == _userID);
                    entity.PostTitle = model.PostTitle;
                    entity.PostText = model.PostText;
                    entity.UserID = model.UserID;
                    //entity.ModifiedUtc = DateTimeOffset.UtcNow;
                    return ctx.SaveChanges() == 1;
                }
            }
            public bool DeletePost(int postID)
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var entity =
                        ctx
                            .Posts
                            .Single(e => e.PostID == postID && e.UserID == _userID);
                    ctx.Posts.Remove(entity);
                    return ctx.SaveChanges() == 1;
                }
            }
        }
    }
