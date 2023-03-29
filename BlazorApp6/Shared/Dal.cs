using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BlazorApp6.Shared
{
    public class Master
    {
        [Key]
        public string MasterPK { get; set; }
        public string FK { get; set; }
        public virtual ICollection<Details>? details { get; set; }
    }
    public class Details
    {
        [Key]
        public string DetailsPK { get; set; }
        [ForeignKey("master")]
        public string FK { get; set; }
        public string otherFields { get; set; }
        public virtual Master? master { get; set; }
    }

    public class MasterDetailsVm
    {
        public MasterDetailsVm()
        {
            this.master = new Master();
            this.details = new List<Details>();
            /* do nothing */
        }
        public Master master { get; set; }
        public List<Details> details { get; set; }
    }

    public class Appointment
    {
        [Key]
        public string Appointment_ID { get; set; }
        public string Appointment_Name { get; set; }
        public DateTime? Date { get; set; }
        public string Phone { get; set; }
        public IList<Service>? Service { get; set; }
    }
    public class Service
    {
        [Key]
        public string Service_ID { get; set; }
        public string Service_Name { get; set; }
        [ForeignKey("Appointment")]
        public string Appointment_ID { get; set; }
        public string Service_Fee { get; set; }
        public string Picture { get; set; }
        public Appointment Appointment { get; set; }
    }
    public class AppointmentServiceVm
    {
        public AppointmentServiceVm()
        {
            this.Appointment = new Appointment();
            this.Service = new List<Service>();
        }
        public Appointment Appointment { get; set; }
        public List<Service> Service { get; set; }
    }

    public class ImageFile
    {
        public string base64data { get; set; }
        public string contentType { get; set; }
        public string fileName { get; set; }
    }

}
