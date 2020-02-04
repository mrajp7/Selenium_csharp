using CrossMail.Tests.Controls;
using OpenQA.Selenium;

namespace CrossMail.Tests.Page
{
    public class Compose
    {

        #region Selectors

        By toText = By.Name("to");
        By subjectText = By.Name("subjectbox");
        By composeRegion = By.XPath("//div[@role='textbox'  and @aria-label='Message Body']");
        By optionsButton = By.XPath("//div[@role='button' and @data-tooltip='More options']");
        By labelOption = By.XPath("//div[@role='menuitem']/div[text()='Label']");
        By labelSearchText = By.XPath("//input[@type='text' and @aria-label='Label-as menu open']");
        By labelSocialCombo = By.XPath("//div[@role='menuitemcheckbox' and @title='Social']/div/span/b");
        By labelForumsCombo = By.XPath("//div[@role='menuitemcheckbox' and @title='Forums']");
        By labelUpdatesCombo = By.XPath("//div[@role='menuitemcheckbox' and @title='Updates']");
        By labelPromotionsCombo = By.XPath("//div[@role='menuitemcheckbox' and @title='Promotions']");
        By attachButton = By.XPath("//div[@role='button' and @data-tooltip='Attach files']");
        By sendButton = By.XPath("//*[@role='button' and text()='Send']");

        #endregion

        #region Elements

        public Textbox To { get; set; }
        public Textbox Subject { get; set; }
        public Textbox Body { get; set; }
        public Button Optionbtn { get; set; }
        public Button LabelOption { get; set; }
        public Textbox LabelSearchtb { get; set; }
        public Button LabelSocialCombobox { get; set; }
        public Button LabelForumsCombobox { get; set; }
        public Button LabelPromotionsCombobox { get; set; }
        public Button LabelUpdatesCombobox { get; set; }
        public Button Attchmentbtn { get; set; }
        public Button Sendbtn { get; set; }

        #endregion

        #region Constructor
        public Compose()
        {
            To = new Textbox(textbox: toText);
            Subject = new Textbox(textbox: subjectText);
            Body = new Textbox(textbox: composeRegion);
            Optionbtn = new Button(button: optionsButton);
            LabelOption = new Button(button: labelOption);
            LabelSearchtb = new Textbox(textbox: labelSearchText);
            LabelSocialCombobox = new Button(button: labelSocialCombo);
            LabelForumsCombobox = new Button(button: labelForumsCombo);
            LabelPromotionsCombobox = new Button(button: labelPromotionsCombo);
            LabelUpdatesCombobox = new Button(button: labelUpdatesCombo);
            Attchmentbtn = new Button(button: attachButton);
            Sendbtn = new Button(button: sendButton);
        }
        #endregion

    }
}
