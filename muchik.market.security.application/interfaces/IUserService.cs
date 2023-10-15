using muchik.market.security.application.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace muchik.market.security.application.interfaces
{
    public interface IUserService
    {
        void SignUp(CreateUserDto userDto);
        SignInResponseDto SignIn(SignInRequestDto signInRequestDto);
        ICollection<UserDto> GetAllUsers();
    }
}
