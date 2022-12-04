using BLL.DTO;
using BLL.Services;
using FoodService.Models.ViewModels;
using System.Net;
using System.Net.Mail;

namespace FoodService.Models
{
    public class EmailManager
    {
        public static Task<int> SendConfirmCodeAsync(string password,string from,string to)
        {
            return Task.Run(() =>
            {
                Random rand = new Random();
                int confirmCode = rand.Next(19738, 95782);

                MailAddress sender = new MailAddress(from, "Cafe Angular Manager");
                MailAddress recipient = new MailAddress(to);
                using (MailMessage message = new MailMessage(from, to))
                {
                    message.IsBodyHtml = true;
                    message.Body = $@"
                     <div>
                         <h2 style='font-style:Calibri;font-size:24px;display:inline-block'>Cafe Angular Manager:</h2>
                         <h3 style='font-style:Calibri;font-size:24px'>Для подтверждения регистрации, укажиет код: {confirmCode}</h3>
                     </div>
                     ";
                    using (SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587))
                    {
                        smtpClient.EnableSsl = true;
                        smtpClient.Credentials = new NetworkCredential(from, password);
                        smtpClient.Send(message);
                    }
                }
                return confirmCode;
            });
           
        }
        public static Task SendOrderAsync(string password, string from, CreateOrderViewModel model,FoodManager service) 
        {
            return Task.Run(() =>
            {
                try
                {
                    MailAddress sender = new MailAddress(from, "Cafe Angular Manager");
                    MailAddress recipient = new MailAddress(model.Order.Email);
                    using (MailMessage message = new MailMessage(from, model.Order.Email))
                    {
                        message.IsBodyHtml = false;
                        string part1 = @$"                     
        Заказ {model.Order.Id}

Aдрес: {model.Order.Address}
Номер телефона: {model.Order.NumberPhone}
Дата: {DateTime.Today.Day}.{DateTime.Today.Month}.{DateTime.Today.Year}
               
        Содержимое заказа:";
                        string part2 = "";
                        foreach (var item in model.OrderItems)
                        {
                            FoodDTO food = service.Get((int)item.FoodId);
                            part2 += $"\n{item.Quantity}x {food.Name}";
                        }
                        message.Body = part1 + part2;
                        using (SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587))
                        {
                            smtpClient.EnableSsl = true;
                            smtpClient.Credentials = new NetworkCredential(from, password);
                            smtpClient.Send(message);
                        }
                    }
                }
                catch { }
                    
            });
        }
    }
}
