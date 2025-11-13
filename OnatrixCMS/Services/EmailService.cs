using Azure;
using Azure.Communication.Email;

namespace OnatrixCMS.Services;

public class EmailService(EmailClient emailClient, IConfiguration configuration)
{
    private readonly IConfiguration _configuration = configuration;
    private readonly EmailClient _emailClient = emailClient;

    public async Task SendEmail(string recipientAddresss, string subject, string plainContent, string htmlContent)
    {
        try
        {
            var emailMessage = new EmailMessage(
                senderAddress: _configuration["ACS:SenderAddress"],
                recipients: new EmailRecipients([new(recipientAddresss)]),
                content: new EmailContent(subject)
                {
                    PlainText = plainContent,
                    Html = htmlContent
                });

            var emailSendOperation = await _emailClient.SendAsync(WaitUntil.Started, emailMessage);
        }
        catch {  }
    }
}
