using BlazorApp6.Server.Data;
using BlazorApp6.Shared;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.IO;

namespace BlazorApp6.Server
{
    public class masterDelatiService : ImasterDetail

    {
        ApplicationDbContext db;
        public masterDelatiService(ApplicationDbContext _db)
        {
            db = _db;
        }

        public string AddMasterDetailsVm(AppointmentServiceVm md)
        {
            Appointment m = new Appointment() { Appointment_ID = md.Appointment.Appointment_ID, Appointment_Name = md.Appointment.Appointment_Name, Date = md.Appointment.Date, Phone = md.Appointment.Phone };
            db.Appointment.Add(m);
            db.SaveChanges();
            db.Entry(m).State = EntityState.Detached;
            foreach (var c in md.Service)
            {
                Service d = new Service()
                {
                    Service_ID = c.Service_ID,
                    Service_Name = c.Service_Name,
                    Appointment_ID = c.Appointment_ID,
                    Service_Fee = c.Service_Fee,
                    Picture = c.Picture,
                    //date = DateTime.Parse(c.date.ToShortDateString()),

                };
                db.Service.Add(d);
            }
            db.SaveChanges();

            return "1";

        }
        public string RemoveMasterDetailsVm(string id)
        {
            List<Service> st5 = db.Service.Where(xx => xx.Appointment_ID == id).ToList();
            db.Service.RemoveRange(st5);
            db.SaveChanges();
            Appointment st6 = db.Appointment.Find(id);
            if (st6 != null)
            {
                db.Appointment.Remove(st6);
            }
            db.SaveChanges();

            return "1";

        }
        public string UpdateMasterDetailsVm(AppointmentServiceVm md)
        {
            RemoveMasterDetailsVm(md.Appointment.Appointment_ID);
            AddMasterDetailsVm(md);
            return "1";
        }

    
    public List<Appointment> GetTwoTables()
        {
        List<Appointment> md = new List<Appointment>();

        md = (from d in db.Appointment select d).ToList();
        //var jo = JsonSerializer.Deserialize<Master>(a);
        return md;

    }
    public AppointmentServiceVm GetTwoTables2(string id)
        {
            AppointmentServiceVm md = new AppointmentServiceVm();
            Appointment a = new Appointment();
            a = (from d in db.Appointment where d.Appointment_ID == id select d).FirstOrDefault();
            md.Appointment = a;
            List<Service> b = new List<Service>();
            b = (from d in db.Service where d.Appointment_ID == id select d).ToList();
            md.Service = b;
            if (a != null) db.Entry(a).State = EntityState.Detached;
            return md;

        }

        public string GenerateCode()
        {
            string a1 = "";
            string b1 = "";

            try
            {
                var a = (from det in db.masters select det.MasterPK.Substring(3)).Max();
                if (a == null)
                    a = "0";
                int b = int.Parse(a.ToString()) + 1;
                if (b < 10)
                {
                    b1 = "000" + b.ToString();
                }
                else if (b < 100)
                {
                    b1 = "00" + b.ToString();
                }
                else if (b < 1000)
                {
                    b1 = "0" + b.ToString();
                }
                else
                {
                    b1 = b.ToString();
                }
                a1 = "AC-" + b1.ToString();
            }
            catch (Exception ex)
            {
                a1 = "AC-0001";
            }
            return a1;
        }
        public string Child_Exists(string id)
        {
            var a = (from p in db.details where p.DetailsPK == id select new { p.DetailsPK, }).FirstOrDefault();
            if (a != null)
                return "1";
            else
                return "0";
        }

        

    }

}
