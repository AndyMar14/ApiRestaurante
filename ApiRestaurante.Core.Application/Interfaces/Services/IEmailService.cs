using ApiRestaurante.Core.Application.Dtos.Email;
using ApiRestaurante.Core.Domain.Settings;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.Core.Application.Interfaces.Services
{
    public interface IEmailService
    {
        public MailSettings _mailSettings { get; }
        Task SendAsync(EmailRequest request);
    }
}
