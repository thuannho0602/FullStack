using Full_Stack.Model.Menu;
using Full_Stack.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Full_Stack.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenusController : BaseController
    {
        private readonly IMenuServices _menuServices;
        public MenusController(IMenuServices menuServices)
        {
            _menuServices = menuServices;
        }
        [HttpPost]
        public async Task<MenuCreateResponse>Create(MenuCreateRequest menuCreateRequest)
        {
            return await _menuServices.CreateMenu(menuCreateRequest);
        }
        [HttpPut("{Id}")]
        public async Task<MenuUpdateResponse>Update(int Id,MenuUpdateRequest menuUpdateRequest)
        {
            return await _menuServices.UpdateMenu(Id, menuUpdateRequest);
        }
        [HttpDelete("{Id}")]
        public async Task<bool>DeleteMenu(int Id)
        {
            return await _menuServices.DeleteMenu(Id);
        }
        [HttpGet]
        public async Task<IEnumerable<MenuGetResponse>> GetAll()
        {
            return await _menuServices.GetAll();
        }
        [HttpGet("{Id}")]
        public async Task<MenuGetResponse> GetById(int Id)
        {
            return await _menuServices.GetById(Id);
        }
        [HttpGet("Submenu/{Id}")]
        public async Task<IEnumerable<MenuGetResponse>> GetAllSubmenu(int Id)
        {
            return await _menuServices.GetAllSubmenu(Id);
        }
    }
}
