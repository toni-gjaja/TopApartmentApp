using DatabaseLib.MODELS;
using DatabaseLib.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Administration
{
    public partial class NewApartment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["administrator"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                LoadDropDowns(); 
            }

        }

        private void LoadDropDowns()
        {
            try
            {
                IList<ApartmentOwner> owners = ((IRepo)Application["database"]).GetApartmentOwners();

                apOwner.DataSource = from o in owners
                                     select new ListItem()
                                     {
                                         Text = o.Name,
                                         Value = o.Id.ToString()
                                     };
                apOwner.DataBind();

                IList<City> cities = ((IRepo)Application["database"]).GetAllCities();


                apCity.DataSource = from c in cities
                                    select new ListItem()
                                    {
                                        Text = c.CityName,
                                        Value = c.Id.ToString()
                                    };
                apCity.DataBind();


            }
            catch (Exception)
            {

                Response.Redirect("Error.aspx");

            }


        }

        protected void DropdownValidation(object sender, ServerValidateEventArgs e)
        {
            if (e.Value == "--odaberi--")
                e.IsValid = false;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Dashboard.aspx");
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {

            int owner = ((IRepo)Application["database"]).GetOwnerId(apOwner.Items[apOwner.SelectedIndex].Text);
            int status = Int32.Parse(apStatus.SelectedValue);
            int city = ((IRepo)Application["database"]).GetCityId(apCity.Items[apCity.SelectedIndex].Text);
            string address = apAddress.Text;
            string name = apName.Text;
            string nameEng = apNameEng.Text;
            string price = apPrice.Text;
            string maxAdults = apMaxAdults.Text;
            string maxChildren = apMaxChildren.Text;
            string rooms = apRooms.Text;
            string beachDistance = apBeachDistance.Text;

            List<int> params1 = new List<int> { owner, status, city };
            List<string> params2 = new List<string> { address, name, nameEng, price, maxAdults, maxChildren, rooms, beachDistance };

            try
            {
                ((IRepo)Application["database"]).CreateNewApartment(params1, params2);
            }
            catch (Exception)
            {

                Response.Redirect("Error.aspx");
            }

            Response.Redirect("Dashboard.aspx");


        }
    }
}