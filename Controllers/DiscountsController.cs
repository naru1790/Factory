using System;
using System.Threading.Tasks;
using Factory.Models;
using Factory.Services;
using Factory.Services.Memberships;
using Microsoft.AspNetCore.Mvc;

namespace Factory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountsController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly Func<MembershipType, IMembership> _memberShipResolver;
        public DiscountsController(IUserService userService, Func<MembershipType, IMembership> memberShipResolver)
        {
            _userService = userService;
            _memberShipResolver = memberShipResolver;
        }

        // GET api/discounts
        [HttpGet]
        public ActionResult<IMembership> Get()
        {
            var user = _userService.Get();
            var membership = _memberShipResolver(MembershipType.Free).GetDiscount();

            return Ok(membership);
        }
    }
}