using _24Hour.Models.Like;
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
    public class LikeController : ApiController
    {
        public IHttpActionResult Get()
        {
            LikeService likeService = CreateLikeService();
            var likes = likeService.GetLikes();
            return Ok(likes);
        }
        public IHttpActionResult Post(LikeCreate like)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateLikeService();
            if (!service.CreateLike(like))
                return InternalServerError();
            return Ok();
        }
        private LikeService CreateLikeService()
        {
            var likeID = Int32.Parse(User.Identity.GetUserId());
            var likeService = new LikeService(likeID);
            return likeService;
        }
        public IHttpActionResult Get(int id)
        {
            LikeService likeService = CreateLikeService();
            var like = likeService.GetLikeById(id);
            return Ok(like);
        }
        public IHttpActionResult Put(LikeEdit like)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateLikeService();
            if (!service.UpdateLike(like))
                return InternalServerError();
            return Ok();
        }
        public IHttpActionResult Delete(int id)
        {
            var service = CreateLikeService();
            if (!service.DeleteLike(id))
                return InternalServerError();
            return Ok();
        }
    }
}
