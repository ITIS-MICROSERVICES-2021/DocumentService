using System;
using DocumentService.Dto;

namespace DocumentService.Services
{
    public class UserService : IUserService
    {
        //TODO: Реализовать взятие юзера с UserService
        public UserDto GetDocumentUser(Guid userId)
        {
            return new UserDto
            {
                AuthorFullName = "Иванов Иван Иванович",
                BossFullName = "Петров Пётр Петрович"
            };
        }
    }
}
