using System;
using System.Windows.Forms;


namespace ConnectFour_Group2
{
	public partial class MainForm : Form
	{
        private static Form previousForm;
		private static MainForm main = null;

		public MainForm()
		{
			if (main != null)
				return;

			main = this;

			InitializeComponent();

            load(new WelcomePage(), false);
        }

        public static void load(Form form, bool isReview)
        {
            if (main == null)
				return;

            if (main.Controls.Count > 0)
                previousForm = (Form)main.Controls[0];

			/* Remove anything and everything. */
			main.Controls.Clear();

			/* Tweak the child form's GUI settings. */
			form.FormBorderStyle = FormBorderStyle.None;

			/* Steal GUI settings from the child for the parent. */
			main.ClientSize = form.ClientSize;
			main.BackColor = form.BackColor;
			main.Icon = form.Icon;
            if (isReview)
            {
                main.Text = "Connect Four - " + form.Text + " - Review";

            }
            else
            {
                main.Text = "Connect Four - " + form.Text;

            }
            /* Add the specified form as a control. */
            form.TopLevel = false;
			main.Controls.Add(form);
			form.Show();
		}

        public static void loadPrevious()
        {
            Form tmp;

            tmp = (Form)main.Controls[0];
            MainForm.load(previousForm, false);
            previousForm = tmp;
        }
    }
}
