using CrossMail.Tests.Controls;
using OpenQA.Selenium;

namespace CrossMail.Tests.Page
{
    public class Inbox
    {
        #region Selectors

        By composeButton = By.XPath("//*[@role='button' and text()='Compose']");
        By socialCategory = By.XPath("//div[@role='tab' and @aria-label='Social']");
        By primaryCategory = By.XPath("//div[@role='tab' and @aria-label='Primary']");
        By promotionsCategory = By.XPath("//div[@role='tab' and @aria-label='Promotions']");
        By emailArea = By.XPath("//div[@role='main']");
        By emailSubject = By.XPath("//div[@role='main']//h2");
        By emailBody = By.XPath("//div[@role='main']//div[@dir]");
        By attachmentImage = By.XPath("//img[@alt='Attachments']");
        By labelsButton = By.XPath("//div[@role='button' and @data-tooltip='Labels']");
        By selectedLabel = By.XPath("//div[@role='menuitemcheckbox' and @aria-checked='true']");
        By refreshButton = By.XPath("//*[@role='button' and @aria-label='Refresh']");
        By mailBodyContent = By.XPath("//div[@class='adn ads']/div/div/div[@class='ii gt']/div/div[@dir='ltr']");
        By attachmentBodyArea = By.XPath("//div[@class='adn ads']/div/div/div[@class='hq gt a10']/div[@class='aQH']/span/a/div/div/div/div/div/div[@class='aQA']/span");

        #endregion

        #region Elements
        public Button LoggedInbtn { get; set; }
        public Button ComposeBtn { get; set; }
        public Button SocialCategorytab { get; set; }
        public Button PrimaryCategorytab { get; set; }
        public Button PromotionsCategorytab { get; set; }
        public Button InboxMailItem { get; set; }
        public Button EmailArea { get; set; }
        public Button EmailSubject { get; set; }
        public Button EmailBody { get; set; }
        public Button AttachmentImage { get; set; }
        public Button Labelsbtn { get; set; }
        public Button SelectedLabel { get; set; }
        public Button Refreshbtn { get; set; }
        public Element MailBody { get; set; }
        public Element AttachmentBody { get; set; }

        #endregion

        #region Constructor
        public Inbox()
        {
            ComposeBtn = new Button(button: composeButton);
            SocialCategorytab = new Button(button: socialCategory);
            PrimaryCategorytab = new Button(button: primaryCategory);
            PromotionsCategorytab = new Button(button: promotionsCategory);
            //InboxMailItem = new Button(button: inboxMailitems);
            EmailArea = new Button(button: emailArea);
            EmailSubject = new Button(button: emailSubject);
            EmailBody = new Button(button: emailBody);
            AttachmentImage = new Button(button: attachmentImage);
            Labelsbtn = new Button(button: labelsButton);
            SelectedLabel = new Button(button: selectedLabel);
            Refreshbtn = new Button(button: refreshButton);
            MailBody = new Element(selector: mailBodyContent);
            AttachmentBody = new Element(selector: attachmentBodyArea);
        }
        #endregion

        #region Selector Initialization
        public void setUserAccountSelector(string username)
        {
            LoggedInbtn = new Button(By.XPath("//a[contains(@role, 'button') and  contains(@aria-label,'" + username + "@gmail.com')]"));
        }

        public void setInboxMailItemSelector(string subject)
        {
            InboxMailItem = new Button(By.XPath("//div[@class='Cp']/div/table/tbody/tr/td/div/div/div/span/span[contains(text(),'" + subject + "')]"));
        }
        #endregion

    }
}
