using System.Collections.Generic;
using System.Threading.Tasks;
using API.Entities;

namespace API.Interfaces
{
    public interface IUserRepository
    {
        //methods that we're going to support

        void Update(AppUser user); // update the tracking status in entity framework

        Task<bool> SaveAllAsync();

        Task <IEnumerable<AppUser>> GetUsersAsync();

        Task <AppUser> GetUserByIdAsync(int id);
        Task<AppUser> GetUserByUsernameAsync(string username);
    }
}