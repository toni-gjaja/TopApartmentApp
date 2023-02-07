using System;
using DatabaseLib.MODELS;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLib.DAL
{
    public interface IRepo
    {
        /* Apartment */

        List<ApSearch> GetApartmentsForAutoComplete(string name);
        IList<Apartment> SelectApartments();
        void CreateNewApartment(List<int> params1, List<string> params2);
        void UpdateApartment(int id, int status, List<string> apParameters);
        Apartment SelectApartment(int id);
        void DeleteApartment(int id);

        int GetApartmentStars(int id);

        IList<AssignedTag> GetTagsForApartment(int id);

        int GetApIdByName(string name);

        void AddTagToApartment(int apId, int tagId);

        /*User*/
        IList<User> SelectUsers();
        User GetUser(int id);

        /*AppUser*/
        IList<AppUser> GetAppUsers();
        AppUser GetAppUser(int id);

        int CreateAppUser(AppUser user);

        IList<ApartmentReview> GetUserReviews(int id);

        IList<Reservation> GetUserReservations(int id);

        /*New apartment help methods*/
        IList<ApartmentOwner> GetApartmentOwners();
        IList<City> GetAllCities();

        void CreateNewOwner(string name);

        int GetOwnerId(string name);
        int GetCityId(string name);

        /*Reservations*/
        IList<Reservation> GetReservations();

        IList<UnRegUserReservation> GetUnRegUserReservations();

        UnRegUserReservation SelectUnRegUserReservation(int id);

        List<int> GetReservationDetails(int reservationId);

        void DeleteReservation(int reservationId);

        /*Tags*/

        IList<UnusedTag> SelectUnusedTags();

        IList<AssignedTag> SelectAssignedTags();

        void DeleteTag(int id);

        IList<TagType> GetTagTypes();

        int GetTagTypeId(string name);

        void InsertTag(int id, string nameCro, string nameEng);

        IList<string> GetTagNames();

        int GetTagIdByName(string name);

        /*Reviews*/

        IList<ApartmentReview> GetApartmentReviews(int id);

        void LeaveReview(ApartmentReview review);

        


    }
}
