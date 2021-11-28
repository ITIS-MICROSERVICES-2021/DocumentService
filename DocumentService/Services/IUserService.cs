using System;
using DocumentService.Dto;

namespace DocumentService.Services
{
    public interface IUserService
    {
        public UserDto GetDocumentUser(Guid userId);
    }
}
