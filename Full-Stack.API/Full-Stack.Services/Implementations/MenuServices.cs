using Full_Stack.DataAccess;
using Full_Stack.Entity;
using Full_Stack.Model.Menu;
using Full_Stack.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Full_Stack.Services.Implementations
{
    public class MenuServices : IMenuServices
    {
        private IMenuRepository _menuRepository;
        private ApplicationDbContext _appContext;
        public MenuServices(IMenuRepository menuRepository, ApplicationDbContext appContext)
        {
            _menuRepository = menuRepository;
            _appContext = appContext;
        }

        public async Task<MenuCreateResponse> CreateMenu(MenuCreateRequest menuCreateRequest)
        {
            if(menuCreateRequest.Id == 0)
            {
                var menu = new Menu
                {
                    ParentID = menuCreateRequest.ParentID,
                    Name = menuCreateRequest.Name,
                };
                _menuRepository.Add(menu);
                _menuRepository.SaveChanges();

                var menuResponse = new MenuCreateResponse
                {
                    Id = menu.Id,
                    ParentID = menu.ParentID,
                    Name = menu.Name,
                };
                return await Task.FromResult(menuResponse);
            }
            else
            {
                return new MenuCreateResponse();
            }
        }

        public Task<bool> DeleteMenu(int Id)
        {
           var menu = _menuRepository.FindByCondition(c => c.Id == Id).FirstOrDefault(); 
            if(menu!=null)
            {
                _menuRepository.Remove(menu);
                _menuRepository.SaveChanges();
            }
            return Task.FromResult(false);
        }

        public async Task<List<MenuGetResponse>> GetAll()
        {
            var listmenu = _menuRepository.FindByCondition(c=>c.ParentID==null).Select(c => new MenuGetResponse
            {
                Id=c.Id,
                ParentID=c.ParentID,
                Name=c.Name,
            }).ToList();
            return await Task.FromResult(listmenu);
        }
        public async Task<List<MenuGetResponse>> GetAllSubmenu(int Id)
        {
            var listmenu = _menuRepository.FindByCondition(c => c.ParentID == Id).Select(c => new MenuGetResponse
            {
                Id = c.Id,
                ParentID = c.ParentID,
                Name = c.Name,
            }).ToList();
            return await Task.FromResult(listmenu);
            
        }

        public async Task<MenuGetResponse> GetById(int Id)
        {
            var menu = _menuRepository.FindByCondition(c=>c.ParentID==Id).Select(c => new MenuGetResponse
            {
                Id = c.Id,
                ParentID = c.ParentID,
                Name = c.Name,
            }).FirstOrDefault();
            return await Task.FromResult(menu);
        }

        public async Task<MenuUpdateResponse> UpdateMenu(int Id, MenuUpdateRequest menuUpdateRequest)
        {
            if (Id > 0)
            {
                var menu=_menuRepository.FindByCondition(c=>c.Id==Id ).FirstOrDefault();
                if(menu != null)
                {
                    var meNu = new Menu
                    {
                        Id = Id,
                        ParentID = menuUpdateRequest.ParentID,
                        Name = menuUpdateRequest.Name,
                    };
                    _menuRepository.Update(meNu);
                    _menuRepository.SaveChanges();

                    var menuResponse = new MenuUpdateResponse
                    {
                        Id = meNu.Id,
                        ParentID = meNu.ParentID,
                        Name = meNu.Name,
                    };
                    return await Task.FromResult(menuResponse);
                }
                return new MenuUpdateResponse();
            }
            else
            {
                return new MenuUpdateResponse();    
            }
        }
    }
}
