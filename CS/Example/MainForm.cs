using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.Xpf.Core.ServerMode;
using DevExpress.Data.WcfLinq;
using System.Data.Services.Client;
using Example.ServiceReference1;

namespace Example {
    public partial class MainForm : Form {
        private NorthwindEntities context;

        private WcfInstantFeedbackSource wcfInstantSource;

        private Customers newCustomer;

        private Customers customerToEdit;

        public MainForm() {
            InitializeComponent();
            context = new NorthwindEntities(new Uri(@"http://localhost:56848/NorthwindWcfDataService.svc/"));
            wcfInstantSource = new WcfInstantFeedbackSource();
            wcfInstantSource.KeyExpression += "CustomerID";
            wcfInstantSource.GetSource += new EventHandler<GetSourceEventArgs>(wcfInstantSource_GetSource);
            gridControl1.DataSource = wcfInstantSource;
        }

        private void wcfInstantSource_GetSource(object sender, GetSourceEventArgs e) {
            e.Query = context.Customers;
        }

        private void simpleButton1_Click(object sender, EventArgs e) {
            newCustomer = CreateNewCustomer();
            EditCustomer(newCustomer, "Add new customer", CloseAddNewCustomerHandler);
        }

        private void CloseAddNewCustomerHandler(object sender, EventArgs e) {
            if (((EditForm)sender).DialogResult == DialogResult.OK) {
                context.AddToCustomers(newCustomer);
                SaveChandes();
            }
            newCustomer = null;
        }

        private Customers CreateNewCustomer() {
            var newCustomer = new Customers();
            newCustomer.CustomerID = GenerateCustomerID();
            return newCustomer;
        }

        private string GenerateCustomerID() {
            const int IDLength = 5;
            var result = String.Empty;
            var rnd = new Random();
            for (var i = 0; i < IDLength; i++) {
                result += Convert.ToChar(rnd.Next(65, 90));
            }
            return result;
        }

        private void EditCustomer(Customers customer, string windowTitle, FormClosingEventHandler closedDelegate) {
            var frm = new EditForm(customer);
            frm.Text = windowTitle;
            frm.FormClosing += closedDelegate;
            frm.ShowDialog();
        }

        private void SaveChandes() {
            IAsyncResult asyncResult = null;
            try {
                asyncResult = context.BeginSaveChanges(SaveCallback, null);
            }
            catch (Exception ex) {
                context.CancelRequest(asyncResult);
                HandleException(ex);
            }
        }

        private void SaveCallback(IAsyncResult asyncResult) {
            DataServiceResponse response = null;
            try {
                response = context.EndSaveChanges(asyncResult);
            }
            catch (Exception ex) {
                gridControl1.BeginInvoke((MethodInvoker)delegate { context.CancelRequest(asyncResult); });
                HandleException(ex);
                gridControl1.BeginInvoke((MethodInvoker)delegate { DetachFailedEntities(); });
            }
            gridControl1.BeginInvoke((MethodInvoker)delegate { wcfInstantSource.Refresh(); });
        }

        private void DetachFailedEntities() {
            foreach (EntityDescriptor entityDescriptor in context.Entities) {
                if (entityDescriptor.State != EntityStates.Unchanged) {
                    context.Detach(entityDescriptor.Entity);
                }
            }
        }

        private void HandleException(Exception ex) {
            gridControl1.BeginInvoke((MethodInvoker)delegate { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK); });
        }

        private void simpleButton2_Click(object sender, EventArgs e) {
            EditSelectedCustomer(gridView1.FocusedRowHandle);
        }

        private void EditSelectedCustomer(int rowHandle) {
            if (rowHandle < 0) {
                return;
            }
            FindCustomerByIDAndProcess(GetCustomerIDByRowHandle(rowHandle), customer => {
                customerToEdit = customer;
                EditCustomer(customerToEdit, "Edit customer", CloseEditCustomerHandler);
            });
        }

        private string GetCustomerIDByRowHandle(int rowHandle) {
            return (string)gridView1.GetRowCellValue(rowHandle, "CustomerID");
        }

        private void CloseEditCustomerHandler(object sender, EventArgs e) {
            if (((EditForm)sender).DialogResult == DialogResult.OK) {
                context.UpdateObject(customerToEdit);
                SaveChandes();
            }
            customerToEdit = null;
        }

        private void FindCustomerByIDAndProcess(string customerID, Action<Customers> action) {
            var query = (DataServiceQuery<Customers>)context.Customers.Where<Customers>(customer => customer.CustomerID == customerID);
            try {
                query.BeginExecute(FindCustomerByIDCallback, new QueryAction(query, action));
            }
            catch (Exception ex) {
                HandleException(ex);
            }
        }

        private void FindCustomerByIDCallback(IAsyncResult ar) {
            var state = (QueryAction)ar.AsyncState;
            var customers = state.Query.EndExecute(ar);
            foreach (Customers customer in customers) {
                try {
                    gridControl1.BeginInvoke((MethodInvoker)delegate { state.Action(customer); });
                }
                catch (Exception ex) {
                    HandleException(ex);
                }
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e) {
            DeleteSelectedCustomer(gridView1.FocusedRowHandle);
        }

        private void DeleteSelectedCustomer(int rowHandle) {
            if (rowHandle < 0) {
                return;
            }
            if (MessageBox.Show("Do you really want to delete the selected customer?", "Delete Customer", MessageBoxButtons.OKCancel) != DialogResult.OK) {
                return;
            }
            FindCustomerByIDAndProcess(GetCustomerIDByRowHandle(rowHandle), customer => {
                context.DeleteObject(customer);
                SaveChandes();
            });
        }
    }

    public class QueryAction {
        private DataServiceQuery<Customers> query;

        private Action<Customers> action;

        public QueryAction(DataServiceQuery<Customers> query, Action<Customers> action) {
            this.query = query;
            this.action = action;
        }

        public DataServiceQuery<Customers> Query {
            get { return query; }
        }

        public Action<Customers> Action {
            get { return action; }
        }
    }
}
