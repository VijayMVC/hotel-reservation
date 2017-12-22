using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfService1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {

        spdcEntities5 entities = new spdcEntities5();
        public List<Doctor> GetAllDoctors()
        { 
                return entities.Doctors.ToList(); 
        }
        public responseCls loginForm(loginCls expositions)
        {

            var emp = from e in entities.Logins
                      where e.userName == expositions.userName && e.password == expositions.password
                      select e;


            responseCls res = new responseCls();
            if (emp.Count() > 0)
            {
                res.status = 200;
                res.success = "successfully logged in";
                var firstOne = emp.First();

                dataCls d = new dataCls();
                d.userName = firstOne.userName;
                res.value = d;
            }
            else
            {
                res.status = 400;
                res.success = "invalid username or password";
            }

            return res;
        }
        public responseCls signUpForm(signUps expositions)
        {
            customer app = new customer();

            app.Id = entities.customers.Count() + 1;
            app.fname = expositions.fname;
            app.lname = expositions.lname;
            app.phone = expositions.phone;
            app.gender = expositions.gender;
            app.email = expositions.email;
            app.fax = expositions.fax;
            app.password = expositions.password;

            entities.customers.Add(app);

            Login log = new Login();
            log.Id = entities.Logins.Count() + 1;
            log.custID = (entities.customers.Count() + 1).ToString();
            log.userName = expositions.email;
            log.password = expositions.password;

            entities.Logins.Add(log);

            entities.SaveChanges();

            responseCls res = new responseCls();
            res.status = 400;
            res.success = "successfully sign up";

            return res;
        }
        public responseCls saveAppoinmentMobile(submit expositions)
        {

            Appoinment app = new Appoinment();
            app.Id = entities.Appoinments.Count() + 1;
            app.custID = "123";
            app.docID = expositions.doctor.Id;
            app.time = expositions.time;

            entities.Appoinments.Add(app);

            mobile mob = new mobile();
            mob.Id = entities.mobiles.Count() + 1;
            mob.amount = expositions.amount;
            mob.custID = "123";
            mob.mobile1 = expositions.phone;
            mob.pin = expositions.pin;

            entities.mobiles.Add(mob);

            entities.SaveChanges();

            responseCls res = new responseCls();
            res.status = 400;
            res.success = "Data successfully saved";

            return res;
        }
        public responseCls saveCredits(submit expositions)
        {

            Appoinment app = new Appoinment();
            app.Id = entities.Appoinments.Count() + 1;
            app.custID = "123";
            app.docID = expositions.doctor.Id;
            app.time = expositions.time;

            entities.Appoinments.Add(app);

            credit cre = new credit();
            cre.custID = "123";
            cre.Id = entities.credits.Count() + 1;
            cre.amount = expositions.amount;
            cre.cardName = expositions.cardName;
            cre.cardNo = expositions.cardNo;
            cre.csv = expositions.csv;
            cre.date = expositions.cardYear + '-' + expositions.cardMonth;

            entities.credits.Add(cre);
            sendMail(expositions);
            entities.SaveChanges(); 
            responseCls res = new responseCls();
            res.status = 400;
            res.success = "credit card payment is saved";
            return res;
        }
        public responseCls saveAppoinmentMobileOption(submit expositions)
        {
            responseCls res = new responseCls();
            res.status = 400;
            res.success = "Data successfully saved";

            return res;
        }
        public responseCls saveCreditsOption(submit expositions)
        {
            responseCls res = new responseCls();
            res.status = 400;
            res.success = "Data successfully saved";

            return res;
        }
        public responseCls signUpFormOption(signUps expositions)
        {
            responseCls res = new responseCls();
            res.status = 400;
            res.success = "successfully sign up";

            return res;
        }
        public responseCls loginFormOption(loginCls expositions)
        {
            responseCls res = new responseCls();
            res.status = 400;
            res.success = "successfully sign up";

            return res;
        }  
        
        public void sendMail(submit expositions)
        {
            var fromAddress = new MailAddress("sachila@duosoftware.com");
            var fromPassword = "sachila@33";
            var toAddress = new MailAddress(expositions.email);

            string subject = "Shedule Appoinment";
            string body = "your appoinment is shedule at " + expositions.time + " with " +
                " dr." + expositions.doctor.name + ".<br> Full payment of "+expositions.amount+ " is alredy done and cannot reverse. <br><br> Thank you";


            System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)

            };

            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true,
            })

            smtp.Send(message);
        }
         
    }
    
    [DataContract]
    public class submit
    {
        [DataMember]
        public String Name { get; set; }

        [DataMember]
        public String amount { get; set; }

        [DataMember]
        public String phone { get; set; }

        [DataMember]
        public String pin { get; set; }

        [DataMember]
        public String time { get; set; }

        [DataMember]
        public String type { get; set; }

        [DataMember]
        public doctor doctor { get; set; }

        [DataMember]
        public String cardName { get; set; }

        [DataMember]
        public String cardNo { get; set; }

        [DataMember]
        public String csv { get; set; }

        [DataMember]
        public String date { get; set; }

        [DataMember]
        public String cardYear { get; set; }

        [DataMember]
        public String cardMonth { get; set; }

        [DataMember]
        public String email { get; set; }

    }

    [DataContract]
    public class doctor
    {
        [DataMember]
        public String Id { get; set; }

        [DataMember]
        public String name { get; set; }

        [DataMember]
        public String specialty { get; set; }
    }

    [DataContract]
    public class signUps
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public String fname { get; set; }

        [DataMember]
        public String lname { get; set; }

        [DataMember]
        public String phone { get; set; }

        [DataMember]
        public String gender { get; set; }

        [DataMember]
        public String email { get; set; }

        [DataMember]
        public String fax { get; set; }

        [DataMember]
        public String password { get; set; }
    }

    [DataContract]
    public class responseCls
    {

        [DataMember]
        public String success { get; set; }

        [DataMember]
        public int status { get; set; }

        [DataMember]
        public String message { get; set; }

        [DataMember]
        public dataCls value { get; set; }
    }

    [DataContract]
    public class dataCls
    {
        public string userName { get; set; }
    }

    [DataContract]
    public class loginCls
    {

        [DataMember]
        public String userName { get; set; } 

        [DataMember]
        public String password { get; set; }
    }

}
