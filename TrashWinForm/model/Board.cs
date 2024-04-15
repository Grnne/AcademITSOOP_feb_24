using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrashWinForm.model
{
    public class Board
    {
        public static ObservableCollection<MinefieldButton> Minefield_DB { get; private set; }
            = new ObservableCollection<MinefieldButton>() { new MinefieldButton(), new MinefieldButton(), new MinefieldButton() };


        public static void AddButton(Button button)
        { 
            Minefield_DB.Add(new MinefieldButton(button));
        }

    }
}
