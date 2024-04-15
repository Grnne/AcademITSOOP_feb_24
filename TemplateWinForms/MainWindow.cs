using System;
using System.Windows.Forms;

namespace TemplateWinForms
{
    public partial class MainWindow : Form
    {
        public Presenter Presenter { get; set; }


        public MainWindow()
        {
            InitializeComponent();
            new Presenter(this);
        }




        public event EventHandler myEvent;

        private void button1_Click(object sender, EventArgs e)
        {
            myEvent.Invoke(sender, e);
        }
    }
}
