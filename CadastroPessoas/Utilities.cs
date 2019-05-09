using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CadastroPessoas
{
    public class Utilities
    {
        public static void ResetAllControls(Control form)
        {
            foreach (Control control in form.Controls)
            {
                if (control is TextBox)
                {
                    TextBox textBox = (TextBox)control;
                    textBox.Text = null;
                }

                if (control is CheckBox)
                {
                    CheckBox checkBox = (CheckBox)control;
                    checkBox.Checked = false;
                }

            }
        }
    }
}