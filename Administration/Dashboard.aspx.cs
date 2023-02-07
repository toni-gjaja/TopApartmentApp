using DatabaseLib.MODELS;
using DatabaseLib.DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Administration
{

    public partial class Dashboard : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {

            
            if (Session["administrator"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            IList<Apartment> apartments = ((IRepo)Application["database"]).SelectApartments();

            ApartmentsRepeater.DataSource = apartments;
            ApartmentsRepeater.DataBind();

            btnAddNewApartment.Visible = true;
            btnAddNewOwner.Visible = true;


        }

        protected void LinkButton_Click(object sender, EventArgs e)
        {
            btnAddNewApartment.Visible = false;
            btnAddNewOwner.Visible = false;
            int apartmentId = Convert.ToInt32((sender as LinkButton).CommandArgument);
            Session["ApartmentId"] = apartmentId;
            var apartment = ((IRepo)Application["database"]).SelectApartment(apartmentId);
            LoadSelectedApartment(apartment);

        }

        private void LoadSelectedApartment(Apartment apartment)
        {
            AllApartments.Visible = false;
            SelectedApartment.Visible = true;

            apCurrentStatus.Text = apartment.ApartmentStatus.Name;
            apAddress.Text = apartment.Address;
            apName.Text = apartment.Name;
            apNameEng.Text = apartment.NameEng;
            apPrice.Text = apartment.Price;
            apMaxAdults.Text = apartment.MaxAdults;
            apMaxChildren.Text = apartment.MaxChildren;
            apRooms.Text = apartment.TotalRooms;
            apBeachDistance.Text = apartment.BeachDistance;

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            AllApartments.Visible = true;
            SelectedApartment.Visible = false;
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = GetApartmentIdFromSession();

            string status = apStatus.Text;
            int s = 0;

            try
            {
                s = CheckStatus(status);
                if (s == 0)
                {
                    Response.Redirect("Error.aspx");
                }
            }
            catch (Exception)
            {

                Response.Redirect("Error.aspx");
                Console.WriteLine("Apartment status error");

            }

            string address = apAddress.Text;
            string name = apName.Text;
            string nameEng = apNameEng.Text;
            string price = apPrice.Text;
            string maxAdults = apMaxAdults.Text;
            string maxChildren = apMaxChildren.Text;
            string rooms = apRooms.Text;
            string beachDistance = apBeachDistance.Text;

            List<string> apParameters = new List<string> { address, name, nameEng, price, maxAdults, maxChildren, rooms, beachDistance };

            try
            {
                ((IRepo)Application["database"]).UpdateApartment(id, s, apParameters);
            }
            catch (Exception)
            {

                Response.Write("<script LANGUAGE='JavaScript' >alert('Ažuriranje nije moguće, pokušajte ponovo')</script>");
                AllApartments.Visible = true;
                SelectedApartment.Visible = false;
                Console.WriteLine("Update not possible, cast issue");

            }
            Response.Write("<script LANGUAGE='JavaScript' >alert('Uspješno ažuriranje')</script>");
            Response.Redirect("Dashboard.aspx");

        }

        private int GetApartmentIdFromSession()
        {
            int id = 0;
            try
            {
                id = (int)Session["ApartmentId"];
            }
            catch (Exception)
            {

                Response.Redirect("Error.aspx");
                Console.WriteLine("Apartment ID cant be read from current session");

            }
            return id;
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int id = GetApartmentIdFromSession();

            try
            {
                ((IRepo)Application["database"]).DeleteApartment(id);
            }
            catch (Exception)
            {

                Response.Redirect("Error.aspx");
                Console.WriteLine("Selected apartment cant be deleted");
            }

            Response.Redirect("Dashboard.aspx");


        }

        private int CheckStatus(string status)
        {
            switch (status)
            {
                case "Zauzeto":
                    return 1;
                case "Rezervirano":
                    return 2;
                case "Slobodno":
                    return 3;
            }
            return 0;
        }

        protected void btnAddNewApartment_Click(object sender, EventArgs e)
        {
            Response.Redirect("NewApartment.aspx");
        }

        protected void btnAddNewOwner_Click(object sender, EventArgs e)
        {
            Response.Redirect("NewOwner.aspx");
        }
    }

}