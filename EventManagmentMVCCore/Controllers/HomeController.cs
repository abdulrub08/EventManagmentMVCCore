using Dapper;
using Event.DAL.Repositories;
using Event.DOM;
using EventManagmentMVCCore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Diagnostics;

namespace EventManagmentMVCCore.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAccount _accountService;
        private readonly IDapperRepositry _dapper;
        public HomeController(ILogger<HomeController> logger,
            IAccount accountService,IDapperRepositry dapper)
        {
            _logger = logger;
            _accountService = accountService; 
            _dapper = dapper;
        }
        #region Dapper Code with DataBase
        [HttpPost(nameof(Create))]
        public async Task<int> Create(Venue data)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("Id", data.VenueID, DbType.Int32);
            var result = await Task.FromResult(_dapper.Insert<int>("[dbo].[SP_Add_Article]"
                , dbparams,
                commandType: CommandType.StoredProcedure));
            return result;
        }
        [HttpGet(nameof(GetById))]
        public async Task<Venue> GetById(int Id)
        {
            var result = await Task.FromResult(_dapper.Get<Venue>($"Select * from [Dummy] where Id = {Id}", null, commandType: CommandType.Text));
            return result;
        }
        [HttpDelete(nameof(Delete))]
        public async Task<int> Delete(int Id)
        {
            var result = await Task.FromResult(_dapper.Execute($"Delete [Dummy] Where Id = {Id}", null, commandType: CommandType.Text));
            return result;
        }
        [HttpGet(nameof(Count))]
        public Task<int> Count(int num)
        {
            var totalcount = Task.FromResult(_dapper.Get<int>($"select COUNT(*) from [Dummy] WHERE Age like '%{num}%'", null,
                    commandType: CommandType.Text));
            return totalcount;
        }
        [HttpPatch(nameof(Update))]
        public Task<int> Update(Venue data)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("Id", data.VenueID);
            dbPara.Add("Name", data.VenueName, DbType.String);

            var updateArticle = Task.FromResult(_dapper.Update<int>("[dbo].[SP_Update_Article]",
                            dbPara,
                            commandType: CommandType.StoredProcedure));
            return updateArticle;
        }
        #endregion
        public IActionResult Index()
        {
           Registration registration = _accountService.GetLogedinUserByUserIDPassword("Admin", "123456");
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}