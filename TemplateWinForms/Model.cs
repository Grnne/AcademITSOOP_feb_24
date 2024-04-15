using System.Collections.Generic;
using System.Linq;

namespace TemplateWinForms
{
    internal class Model : IModel
    {
        public List<int> ButtonStates { get; set; }

        public List<int> GetButtonsStates()
        {
            return ButtonStates;
        }

        public int GetButtonState()
        {
            return ButtonStates.First();
        }

        public string Method()
        {
            return "test";
        }
    }
}
