﻿using Metcom.CardPay3.ApplicationCore.Interfaces;
using System.Threading.Tasks;

namespace Metcom.CardPay3.Infrastructure.Services
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string message)
        {
            // TODO: Wire this up to actual email sending logic via SendGrid, local SMTP, etc.
            return Task.CompletedTask;
        }
    }
}
