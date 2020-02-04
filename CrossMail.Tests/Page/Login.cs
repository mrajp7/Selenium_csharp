using CrossMail.Tests.Controls;
using OpenQA.Selenium;

namespace CrossMail.Tests.Page
{
    public class Login
    {
        #region Selectors

        By userName = By.Id("identifierId");
        By userNameNext = By.Id("identifierNext");
        By password = By.XPath("//*[@name=\"password\"]");
        By passwordNext = By.Id("passwordNext");

        #endregion

        #region Elements

        public Textbox UserNametb { get; set; }
        public Button UsernameNextbtn { get; set; }
        public Textbox Passwordtb { get; set; }
        public Button PasswordNextbtn { get; set; }

        #endregion

        #region Constructor
        public Login()
        {
            UserNametb = new Textbox(userName);
            UsernameNextbtn = new Button(userNameNext);
            Passwordtb = new Textbox(password);
            PasswordNextbtn = new Button(passwordNext);
        }
        #endregion

    }
}
