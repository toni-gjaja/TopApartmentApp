using DatabaseLib.DAL;
using DatabaseLib.MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Administration
{
    public partial class Reservations : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["administrator"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            LoadReservations();
            LoadUnRegUserReservations();
        }

        private void LoadReservations()
        {
            IList<Reservation> reservations = ((IRepo)Application["database"]).GetReservations();

            if (reservations.Count == 0)
            {
                AllRegUserReservations.Visible = false;
                ReservationAlert.Visible = true;
            }
            else
            {
                RegUserResRepeater.DataSource = reservations;
                RegUserResRepeater.DataBind();
            }

        }

        protected void LinkButton_Click(object sender, EventArgs e)
        {

            int reservationId = Convert.ToInt32((sender as LinkButton).CommandArgument);
            Session["ReservationId"] = reservationId;
            ChosenResIdTb.Text = reservationId.ToString();
            List<int> ids = new List<int>();
            try
            {
                ids = ((IRepo)Application["database"]).GetReservationDetails(reservationId);

                Apartment apartment = ((IRepo)Application["database"]).SelectApartment(ids[0]);

                User user = ((IRepo)Application["database"]).GetUser(ids[1]);

                LoadApartment(apartment);
                LoadUser(user);

                AllRegUserReservations.Visible = false;
                AllUnRegUserReservations.Visible = false;
                ChosenReservation.Visible = true;

            }
            catch (Exception)
            {

                Response.Redirect("Error.aspx");
            }

        }

        private void LoadUser(User user)
        {
            uId.Text = user.Id.ToString();
            uName.Text = user.Name;
            uPhone.Text = user.PhoneNumber;
            uAddress.Text = user.Address;
            uMail.Text = user.Mail;
        }

        private void LoadApartment(Apartment apartment)
        {
            apId.Text = apartment.Id.ToString();
            apName.Text = apartment.Name;
            apOwner.Text = apartment.Owner.Name;
            apCity.Text = apartment.City.CityName;
            apAddress.Text = apartment.Address;
            apPrice.Text = apartment.Price;

        }

        private void LoadUnRegUserReservations()
        {
            IList<UnRegUserReservation> reservations = ((IRepo)Application["database"]).GetUnRegUserReservations();

            if (reservations.Count == 0)
            {
                AllRegUserReservations.Visible = false;
                UnRegReservationAlert.Visible = true;
            }
            else
            {
                UnRegUserRepeater.DataSource = reservations;
                UnRegUserRepeater.DataBind();
            }


        }

        protected void UnReg_LinkButton_Click(object sender, EventArgs e) 
        {
            int reservationId = Convert.ToInt32((sender as LinkButton).CommandArgument);
            Session["ReservationId"] = reservationId;
            ChosenResIdTb.Text = reservationId.ToString();

            try
            {
                UnRegUserReservation reservation = ((IRepo)Application["database"]).SelectUnRegUserReservation(reservationId);

                Apartment apartment = ((IRepo)Application["database"]).SelectApartment(reservation.ApartmentId);

                UnregisteredUser unRegUser = reservation.User;

                LoadApartment(apartment);
                LoadUnRegUser(unRegUser);

                AllRegUserReservations.Visible = false;
                AllUnRegUserReservations.Visible = false;
                ChosenReservation.Visible = true;
            }
            catch (Exception)
            {

                Response.Redirect("Error.aspx");
            }

        }

        private void LoadUnRegUser(UnregisteredUser unRegUser)
        {
            uId.Text = "Unregistered";
            uName.Text = unRegUser.Name;
            uPhone.Text = unRegUser.Phone;
            uAddress.Text = unRegUser.Address;
            uMail.Text = unRegUser.Email;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            AllRegUserReservations.Visible = true;
            AllUnRegUserReservations.Visible = true;
            ChosenReservation.Visible = false;
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int id = (int)Session["ReservationId"];
            ((IRepo)Application["database"]).DeleteReservation(id);
            Response.Redirect("Reservations.aspx");
        }

    }
}