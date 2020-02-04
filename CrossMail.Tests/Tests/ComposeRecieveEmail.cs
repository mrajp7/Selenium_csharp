using CrossMail.Tests.Enum;
using CrossMail.Tests.Page;
using System;
using Xunit;

namespace CrossMail.Tests
{
    public class ComposeRecieveEmail : Testbase
    {
        #region Members

        readonly Helper helper = new Helper();
        readonly Inbox inboxPage = new Inbox();

        #endregion

        #region Tests

        [Fact]
        public void SendAndReceiveEmailTypeLabelSocial()
        {
            var random_val = new Random().Next(1, 100000);
            var attachmentPath = @"\Tests\Testdata\dummydoc.txt";

            LoadGmail();
            helper.LoginToGmail(Config["username"], Config["password"]);

            // Assert whether the user logged in and in home screen.
            Assert.True(helper.isUserLogged(Config["username"]));

            // Compose Email
            var email = new Email
            {
                Address = new AddressDetails
                {
                    To = $"{Config["username"]}@gmail.com",
                    From = "",
                    BCC = "",
                    CC = ""
                },
                Subject = $"This is a sample subject - {random_val}",
                Body = $"This is body with data - {random_val}",
                LabelDetails = new Label
                {
                    isLabelRequired = true,
                    LabelName = LabelCategory.Social
                },
                AttachmentDetails = new Attachment
                {
                    isAttachmentRequired = true,
                    AttachmentFilePath = attachmentPath,
                }

            };

            helper.SendEmail(email: email);

            // Navigate to Social tab
            helper.ToggleInboxTab(TabCategory.Social);

            helper.FindEmailAndOpen(email.Subject);

            // Verify the content of the email
            inboxPage.MailBody.WaitForElement(WaitForElement.Avg);
            Assert.Equal(email.Body, inboxPage.MailBody.Text);
            Assert.Equal("dummydoc.txt", inboxPage.AttachmentBody.Text);
         
        }

        #endregion
    }
}
