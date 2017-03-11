using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FriendsApi.Controllers
{
    [Route("api/[controller]")]
    public class FriendsController : Controller
    {
        [HttpGet]
        public string Get(string value)
        {
            const string pattern = @"(?<payload>.+)(してみた|しました)";
            var match = Regex.Match(value, pattern);
            if(!match.Success)
            {
                return "へーきへーき！フレンズによってとくいなことちがうから！";
            }
            return $"きみは{match.Groups["payload"]}できるフレンズなんだね！すっごーい！";
        }
    }
}