using System.Collections.Generic;

namespace TemplateWinForms
{
    internal interface IModel
    {
        List<int> GetButtonsStates();
        int GetButtonState();
    }
}
