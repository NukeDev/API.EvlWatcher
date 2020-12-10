using api.evl.watch.Models;
using api.evl.watch.Models.User;
using api.evl.watch.Utils;
using System;
using System.Data.SqlClient;
using System.Net.Http;
using System.Web.Http;

namespace api.evl.watch.Controllers
{
    public class UserController : ApiController
    {
        [HttpPost]
        [ActionName("register")]
        public HttpResponseMessage Register([FromBody] TS_Users user)
        {
            if ( !user.VerifyRegistrationCamps() )
            {
                ErrorUtils.SetError(new ErrorType("Please verify your input data. Something went wrong!", _errorCode: ErrorTypeCode.InvalidUserRegisteringData), Request);
                throw new Exception("Invalid E-Mail Format or Empty user informations!");
            }

            try
            {
                using ( var ctx = new EvlWatchContext() )
                {
                    ctx.ExecuteStoreCommand("EXEC dbo.usr_InsertNewUser @username, @password, @email",
                    new SqlParameter("username", user.Username),
                    new SqlParameter("password", new PasswordUtils(user.Password).HashPassword()),
                    new SqlParameter("email", user.Email));

                    return Request.CreateResponse(new DefaultResponseModel<string>(this, System.Net.HttpStatusCode.OK)
                    {
                        Data = "Successfully Registered! Please Verify your E-Mail Address, a link was sent to it!"
                    });
                }
            }
            catch(Exception)
            {
                ErrorUtils.SetError(new ErrorType("Please verify your input data. Something went wrong!", _errorCode: ErrorTypeCode.InvalidUserRegisteringData), Request);
                throw new Exception("Please, check your E-Mail Address or Username, maybe it's already registered! Or try again later.");
            }
        }
    }
}