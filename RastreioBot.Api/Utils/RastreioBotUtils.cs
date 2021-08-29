using RastreioBot.Api.Models.Api.Users;
using RastreioBot.Api.Models.Users;

namespace RastreioBot.Api.Utils
{
    public static class RastreioBotUtils
    {
        public static UserApi ConvertUserToUserApi(User user)
        {
            return new UserApi
            {
                Name = user.Name,
                Token = user.UserToken
            };
        }

        public static User ConvertUserApiToUser(UserApi user)
        {
            return new User
            {
                Name = user.Name,
                UserToken = user.Token
            };
        }
    }
}