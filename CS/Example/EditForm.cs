using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Example.ServiceReference1;

namespace Example {
    public partial class EditForm : Form {
        public EditForm(Customers customer) {
            InitializeComponent();
            teComN.DataBindings.Add("EditValue", customer, "CompanyName");
            teConN.DataBindings.Add("EditValue", customer, "ContactName");
            teAdd.DataBindings.Add("EditValue", customer, "Address");
            teC.DataBindings.Add("EditValue", customer, "Country");
        }
    }
}
