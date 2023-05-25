using ECommerce.DAL.Reposatory.Repo;
using Microsoft.AspNetCore.Http;

namespace ECommerce.DAL.Reposatory.RepoServices
{
    public class MailingService : IEmailService
    {
        public async Task SendEmailAsync( string mailTo , string body , IList<IFormFile> attachments = null )
        {

        }
    }
}
