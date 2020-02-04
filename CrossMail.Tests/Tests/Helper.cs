using CrossMail.Tests.Enum;
using CrossMail.Tests.Page;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System;
using OpenQA.Selenium;

namespace CrossMail.Tests
{
    class Email 
    {
        public AddressDetails Address;
        public string Subject;
        public string Body;
        public Attachment AttachmentDetails;
        public Label LabelDetails;
    }

    class AddressDetails
    {
        public string To;
        public string From;
        public string CC;
        public string BCC;
    }

    class Attachment
    {
        public bool isAttachmentRequired;
        public string AttachmentFilePath;
    }

    class Label
    {
        public bool isLabelRequired;
        public LabelCategory LabelName;
    }

    class Helper
    {
        Login loginPage = new Login();
        Inbox inboxPage = new Inbox();
        Compose composePage = new Compose();
        public string executionPath = Path.GetDirectoryName(Application.ExecutablePath);

        public void LoginToGmail(string username, string password)
        {
            loginPage.UserNametb.WaitForElement(WaitForElement.Min);
            loginPage.UserNametb.SetText(username);
            loginPage.UsernameNextbtn.Click();

            loginPage.Passwordtb.WaitForElement(WaitForElement.Max);
            loginPage.Passwordtb.SetText(password);
            loginPage.PasswordNextbtn.Click();
        }

        public void ToggleInboxTab(TabCategory tab)
        {
            switch(tab)
            {
                case TabCategory.Social:
                    inboxPage.SocialCategorytab.Click();
                    break;
                case TabCategory.Promotions:
                    inboxPage.PromotionsCategorytab.Click();
                    break;
                case TabCategory.Primary:
                    inboxPage.PrimaryCategorytab.Click();
                    break;
            }
            Thread.Sleep(3000);
        }

        public void SendEmail(Email email)
        {
            inboxPage.ComposeBtn.Click();

            composePage.To.SetText(email.Address.To);
            composePage.Subject.SetText(email.Subject);
            composePage.Body.SetText(email.Body);
            //composePage.Optionbtn.Click();

            if(email.LabelDetails.isLabelRequired)
            {
                SetLabel(email.LabelDetails.LabelName);
            }

            if (email.AttachmentDetails.isAttachmentRequired)
            {
                AddAttachment(email.AttachmentDetails.AttachmentFilePath);
            }

            composePage.Sendbtn.WaitForElement(Enum.WaitForElement.Avg);
            composePage.Sendbtn.Click();
        }

        public void SetLabel(LabelCategory label)
        {
            composePage.Optionbtn.Click();
            composePage.LabelOption.Click();
            composePage.LabelSearchtb.WaitForElement(Enum.WaitForElement.Avg);
            Thread.Sleep(2000);
            switch (label)
            {
                case LabelCategory.Social:
                    composePage.LabelSearchtb.SetText(LabelCategory.Social.ToString());
                    composePage.LabelSocialCombobox.Click();
                    break;
                case LabelCategory.Forums:
                    composePage.LabelSearchtb.SetText(LabelCategory.Forums.ToString());
                    composePage.LabelForumsCombobox.Click();
                    break;
                case LabelCategory.Promotions:
                    composePage.LabelSearchtb.SetText(LabelCategory.Promotions.ToString());
                    composePage.LabelPromotionsCombobox.Click();
                    break;
                case LabelCategory.Updates:
                    composePage.LabelSearchtb.SetText(LabelCategory.Updates.ToString());
                    composePage.LabelUpdatesCombobox.Click();
                    break;
                default:
                    break;

            }
            //SendKeys.SendWait(@"{Enter}");
            Thread.Sleep(500);
        }

        public void AddAttachment(string attachmentPath)
        {
            composePage.Attchmentbtn.Click();
            Thread.Sleep(1000);
            SendKeys.SendWait(executionPath + attachmentPath);
            SendKeys.SendWait(@"{Enter}");
            
            Thread.Sleep(10000);
        }

        public bool isUserLogged(string username)
        {
            inboxPage.setUserAccountSelector(username);
            inboxPage.LoggedInbtn.WaitForElement(Enum.WaitForElement.Avg);
            try
            {
                return inboxPage.LoggedInbtn.isEnabled();
            }
            catch
            {
                return false;
            }
        }

        public void FindEmailAndOpen(string subject)
        {
            var timeout = DateTime.Now.AddMinutes(3); //wait for 3 minuted for the email to be received
            var mailItemFound = false;
            while (DateTime.Now < timeout && !mailItemFound)
            {
                try
                {
                    //inboxPage.Refreshbtn.Click();
                    inboxPage.setInboxMailItemSelector(subject);
                    inboxPage.InboxMailItem.WaitForElement(WaitForElement.Max);
                    mailItemFound = true;
                    inboxPage.InboxMailItem.Click();
                    Thread.Sleep(2000);
                }
                catch
                {
                    //if email not found click on Refresh
                    //inboxPage.Refreshbtn.Click();
                }
            }
            if (mailItemFound == false)
            {
                throw new ElementNotInteractableException($"The email item is not found {subject}");
            }
        }

    }
}
