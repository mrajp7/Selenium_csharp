using OpenQA.Selenium;

namespace CrossMail.Tests.Controls
{
    public class Textbox : Element
    {

        public Textbox(By textbox) : base(selector: textbox) { }

        public void SetText(string text)
        {
            if (isEnabled())
            {
                Driver.FindElement(Selector)
                       .SendKeys(text);
            }
            else
            {
                SendInvalidStateException();
            }
        }

        public void Clear()
        {
            if (isEnabled())
            {
                Driver.FindElement(Selector)
                       .Clear();
            }
            else
            {
                SendInvalidStateException();
            }
        }

        private void SendInvalidStateException() => throw new InvalidElementStateException(message: $"textbox is not enabled to act on - {Text}");
    }
}
