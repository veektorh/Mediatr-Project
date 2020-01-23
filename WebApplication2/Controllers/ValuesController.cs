using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.ServiceModel.Security;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using MediatR;
using WebApplication2.Handlers;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IMediator mediator;

        public ValuesController(IMediator mediator)
        {
            this.mediator = mediator;
        }


        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> Get()
        {

            await mediator.Publish(new NotificationMessage() { message = "notification message" });
            return new string[] { "value1", "value2" };
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetParam(int id)
        {

            var res = await mediator.Send(new Ping { });
            Console.WriteLine(res);
            return Ok();
        }


        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            

        }
    }

    

    public static class Security
    {
        public static string ToHmacSha512(this string input, string key)
        {
            if (string.IsNullOrEmpty(input) || string.IsNullOrEmpty(key))
            {
                return null;
            }

            byte[] secretkeyBytes = Encoding.UTF8.GetBytes(key);
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);

            using (var hmac = new HMACSHA512(secretkeyBytes))
            {
                byte[] hashValue = hmac.ComputeHash(inputBytes);
                var res = BitConverter.ToString(hashValue).Replace("-", string.Empty);
                return res.ToLower();
            }
        }
    }
}
