﻿using Microsoft.AspNetCore.Http;

namespace ECommerce.DAL.Reposatory.Repo
{
    public interface IEmailService
    {
        Task SendEmailAsync( string mailTo , string body , IList<IFormFile> attachments = null );
    }
}