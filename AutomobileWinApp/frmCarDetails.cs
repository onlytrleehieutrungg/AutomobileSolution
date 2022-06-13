 `using AutomobileLibrary.BussinessObject;
using AutomobileLibrary.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutomobileWinApp
{
    public partial class frmCarDetails : Form
    {
        public frmCarDetails()
        {
            InitializeComponent();
        }

        public ICarRepository CarRepository { get; set; }
        public Car CarInfo { get; set; }
        public bool InsertOrUpdate { get; set; }

        private void frmCarDetails_Load(object sender, EventArgs e)
        {
            cboManuFacturer.SelectedIndex = 0;
            txtCarID.Enabled = !InsertOrUpdate;
            if (InsertOrUpdate)
            {
                txtCarID.Text = CarInfo.CarId.ToString();
                txtCarName.Text = CarInfo.Carname.ToString();
                txtPrice.Text = CarInfo.Price.ToString();
                txtReleasedYear.Text = CarInfo.ReleasedYear.ToString();
                cboManuFacturer.Text = CarInfo.Manufacturer.ToString();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var car = new Car()
                {
                    CarId = int.Parse(txtCarID.Text),
                    Carname = txtCarName.Text,
                    Manufacturer = cboManuFacturer.Text,
                    Price = decimal.Parse(txtPrice.Text),
                    ReleasedYear = int.Parse(txtReleasedYear.Text)
                };
                if (!InsertOrUpdate)
                {
                    CarRepository.AddCar(car);
                }
                else
                {
                    CarRepository.UpdateCar(car);
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message,InsertOrUpdate==false?"add a new car":"Update a car");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e) => Close();
    }
}
