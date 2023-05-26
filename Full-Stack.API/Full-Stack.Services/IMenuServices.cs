using Full_Stack.Model.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Full_Stack.Services
{
    public interface IMenuServices
    {
        Task<List<MenuGetResponse>> GetAll();
        Task<MenuGetResponse> GetById(int id);
        Task<List<MenuGetResponse>> GetAllSubmenu(int Id);
        Task<MenuCreateResponse> CreateMenu(MenuCreateRequest menuCreateRequest);
        Task<MenuUpdateResponse> UpdateMenu(int Id, MenuUpdateRequest menuUpdateRequest);
        Task<bool> DeleteMenu(int Id);
    }
}
