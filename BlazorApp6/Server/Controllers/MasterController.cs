using BlazorApp6.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorApp6.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MasterController : ControllerBase
    {
        private readonly ImasterDetail _ImasterDetail;
        public MasterController(ImasterDetail masterDetail)
        {
            _ImasterDetail = masterDetail;
        }
        [HttpGet]
        public async Task<List<Appointment>> Get()
        {
            return await Task.FromResult(_ImasterDetail.GetTwoTables());
        }
        [HttpGet("{id}")]
        public AppointmentServiceVm Get(string id)
        {

            AppointmentServiceVm masterDelati = _ImasterDetail.GetTwoTables2(id);
            return masterDelati;

        }
        [HttpPost]
        public string AddMasterDetailsVm(AppointmentServiceVm md2)
        {
            _ImasterDetail.AddMasterDetailsVm(md2);
            return "1";

        }
        [HttpPut]
        public string UpdateMasterDetailsVm(AppointmentServiceVm md)
        {
            _ImasterDetail.UpdateMasterDetailsVm(md);
            return "2";
        }
        [HttpDelete("{id}")]
        public string RemoveMasterDetailsVm(string id)
        {
            _ImasterDetail.RemoveMasterDetailsVm(id);
            return "1";
        }
    }

}
