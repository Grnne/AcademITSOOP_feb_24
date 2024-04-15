

using System.Windows.Forms;

namespace TrashWinForm
{
    public class MinefieldButton
    {
        public Button MButton  { get; set; }

        public MinefieldButton()
        {
            MButton = new Button();
        }

        public MinefieldButton(Button minefieldButton)
        {
            MButton = minefieldButton;
        }
    }
}
