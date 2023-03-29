using BlazorApp6.Shared;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorApp6.Server
{
    public interface ImasterDetail
    {
        public string AddMasterDetailsVm(AppointmentServiceVm md2);
        public string RemoveMasterDetailsVm(string id);
        public string UpdateMasterDetailsVm(AppointmentServiceVm md);
        public List<Appointment> GetTwoTables();
        public AppointmentServiceVm GetTwoTables2(string id);
        public string GenerateCode();
        public string Child_Exists(string id);
       
    }

}
