using GambleMaticApi.DatabaseEntities;

using GambleMaticCommLib;

using Microsoft.AspNetCore.Mvc;

namespace GambleMaticApi
{
    public static class AuthenticationEndpoints
    {


        public static IEndpointRouteBuilder MapAuthenticationEndpoints(this IEndpointRouteBuilder endpoints)
        {


            var authEndpointGroup = endpoints.MapGroup("/api/v1/auth").WithTags("Authentication");

            authEndpointGroup.MapPost("/login", async Task<ApiResult<string>> ([FromServices] JwtHelper jwtHelper, [FromBody]LoginRequestDto loginRequest) =>
                {
                    ApiResult<string> response = new();
                    //TODO: implement, this is just for demo purposes
                    if (loginRequest.Username == "test" && loginRequest.Password == "password")
                    {

                        response.Payload = await jwtHelper.GetTokenString();
                        response.Message = "Login successful";
                        return response;
                    }

                    response.Error = new ApiError(errorMessage: " Invalid login attempt.");

                    return response;
                });


            //TODO: Add authorization to this endpoint
            authEndpointGroup.MapPost("/updateUserInformation", async Task<ApiResult<string>> (
                [FromBody] ModifyUserDataDto modifyUserData,
                [FromServices] DatabaseManager _dbManager) =>
            {
                ApiResult<string> response = new ApiResult<string>();
                //TODO: implement, this is just for demo purposes
                UserEntity userEntity = new UserEntity
                {
                    Username = modifyUserData.Username,
                    Email = modifyUserData.Email,
                    RealName = modifyUserData.RealName,
                    IsAdmin = modifyUserData.IsAdmin
                };


                //TODO: update user in database
                response.Payload = "User information updated successfully";

                return response;
            });


            return endpoints;
        }


       
    }
}
