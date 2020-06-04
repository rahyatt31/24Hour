using _24Hour.Models.Profile;
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
    public class ProfileController : ApiController
    {
        public IHttpActionResult Get()
        {
            ProfileService userService = CreateProfileService();
            var users = userService.GetProfiles();
            return Ok(users);
        }
        public IHttpActionResult Create(ProfileCreate user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateProfileService();
            if (!service.CreateProfile(user))
                return InternalServerError();
            return Ok();
        }

        private ProfileService CreateProfileService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId()); //gets the current user's ID(string, that is a Guid kinda) that is logged in(that we have a token for)
            var userService = new ProfileService(userId);
            return userService;
        }

        public IHttpActionResult Get(Guid id)
        {
            ProfileService userService = CreateProfileService();
            var user = userService.GetProfileByID(id);
            return Ok(user);
        }
        public IHttpActionResult Put(ProfileEdit user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateProfileService();
            if (!service.UpdateProfile(user))
                return InternalServerError();
            return Ok();
        }
        public IHttpActionResult Delete(Guid id)
        {
            var service = CreateProfileService();
            if (!service.DeleteProfile(id))
                return InternalServerError();
            return Ok();
        }
    }
}
