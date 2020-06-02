using _24Hour.Models.Reply;
using _24Hour.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _24HourProject.Controllers
{
    public class ReplyController : ApiController
    {
        public IHttpActionResult Get()
        {
            ReplyService replyService = CreateReplyService();
            var replies = replyService.GetReplies();
            return Ok(replies);
        }
        public IHttpActionResult Post(ReplyCreate reply)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateReplyService();
            if (!service.CreateReply(reply))
                return InternalServerError();
            return Ok();
        }
        private ReplyService CreateReplyService()
        {
            var replyId = Int32.Parse(User.Identity.GetUserId());
            var replyService = new ReplyService(replyId);
            return replyService;
        }
        public IHttpActionResult Get(int id)
        {
            ReplyService replyService = CreateReplyService();
            var reply = replyService.GetReplyByID(id);
            return Ok(reply);
        }
        public IHttpActionResult Put(ReplyEdit reply)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateReplyService();
            if (!service.UpdateReply(reply))
                return InternalServerError();
            return Ok();
        }
        public IHttpActionResult Delete(int id)
        {
            var service = CreateReplyService();
            if (!service.DeleteReply(id))
                return InternalServerError();
            return Ok();
        }
    }
}