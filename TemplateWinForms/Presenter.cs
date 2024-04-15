using System;

namespace TemplateWinForms
{
    public class Presenter
    {
         private Model _model;
         private MainWindow _view;

        public Presenter(MainWindow view)
        {
            _view = view;
            view.Presenter = this;
            _model = new Model();
            _view.myEvent += Handler1;
           
        }


        void Handler1(object sender, EventArgs e)
        {
            _view.textBox1.Text = _model.Method();
        }

    }


}
