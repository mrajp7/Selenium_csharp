using OpenQA.Selenium;

namespace CrossMail.Tests.Controls
{
    public class Button : Element
    {

        public Button(By button) : base(selector: button) { }

        public override void Click()
        {
            if (isEnabled())
            {
                Driver.FindElement(Selector).Click();
            }
            else
            {
                SendInvalidStateException();
                return;
            }
        }

        private void SendInvalidStateException() => throw new InvalidElementStateException(message: $"button is not enabled to perform action - {Text}");
    }
}
