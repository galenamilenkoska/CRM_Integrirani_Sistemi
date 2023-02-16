using Microsoft.AspNetCore.Mvc;
using MailKit.Net.Imap;
using MailKit.Security;
using MailKit;
using System.Collections.Generic;
using MimeKit;
using StudentCRM.Domain.DomainModels;

namespace MyWebApi.Controllers
{
    [ApiController]
    [Route("api/messages")]
    public class MessagesController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                using (var client = new ImapClient())
                {
                    // Connect to the IMAP server
                    client.Connect("outlook.office365.com", 993, SecureSocketOptions.SslOnConnect);

                    // Authenticate with the server
                    client.Authenticate("mkovacheska@outlook.com", "Mina!001");

                    // Get the INBOX folder
                    var inbox = client.Inbox;
                    inbox.Open(FolderAccess.ReadOnly);

                    // Get the messages from the INBOX folder
                    var messages = new List<Message>();
                    for (int i = 0; i < inbox.Count; i++)
                    {
                        var mimeMessage = inbox.GetMessage(i);

                        var message = new Message
                        {
                            sender = mimeMessage.From.ToString(),
                            recipients = mimeMessage.To.ToString(),
                            subject = mimeMessage.Subject,
                            body = mimeMessage.TextBody,
                            // set the student and professor properties as needed
                        };
                        messages.Add(message);
                    }

                    // Disconnect from the server
                    client.Disconnect(true);

                    return Ok(messages);
                }
            }
            catch (ImapProtocolException ex)
            {
                // Handle connection errors
                return BadRequest(ex.Message);
            }
            catch (AuthenticationException ex)
            {
                // Handle authentication errors
                return BadRequest("Invalid credentials");
            }
        }
    }
       
    
}