using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
namespace nunit_selenium.Utils
{
    public class DropdownUtils
    {
        private readonly IWebElement _element;

        public DropdownUtils(IWebElement element)
        {
            _element = element;
        }

        public void SelectByText(string text)
        {
            if (_element.Enabled)
            {
                var dropdownSelection = new SelectElement(_element);
                dropdownSelection.SelectByText(text);
            }
        }

        public void SelectByValue(string value)
        {
            if (_element.Enabled)
            {
                var dropdownSelection = new SelectElement(_element);
                dropdownSelection.SelectByValue(value);
            }
        }

        public void SelectByIndex(int index)
        {
            if (_element.Enabled)
            {
                var dropdownSelection = new SelectElement(_element);
                dropdownSelection.SelectByIndex(index);
            }
        }

        public int GetIndexOfSelectedValue()
        {
            var index = -1;
            var dropdownSelection = new SelectElement(_element);
            var slectedValue = dropdownSelection.SelectedOption.Text;
            for (var i = 0; i < dropdownSelection.Options.Count; i++)
            {
                if (!dropdownSelection.Options[i].Text.Equals(slectedValue)) continue;
                index = i;
                break;
            }

            return index;
        }

        public string GetTextOfSelectedValue()
        {
            var dropdownSelection = new SelectElement(_element);
            return dropdownSelection.SelectedOption.Text;
        }
    }
}