using System;
using DatabaseLib.MODELS;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.ApplicationBlocks.Data;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Xml.Linq;

namespace DatabaseLib.DAL
{
    public class DatabaseRepo : IRepo
    {

        private static string CS = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;

        /*Apartment methods*/

        public List<ApSearch> GetApartmentsForAutoComplete(string name)
        {
            var search = SqlHelper.ExecuteDataset(CS, nameof(GetApartmentsForAutoComplete), name).Tables[0];

            List<ApSearch> result = new List<ApSearch>();

            foreach (DataRow row in search.Rows)
            {
                result.Add(

                    new ApSearch
                    {
                        Id = (int)row["Id"],
                        Name = (string)row["Name"]
                    }

                    );
            }

            return result;


        }

        public void CreateNewApartment(List<int> params1, List<string> params2)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("OwnerId", params1[0]),
                new SqlParameter("StatusId", params1[1]),
                new SqlParameter("CityId", params1[2]),
                new SqlParameter("Address", params2[0]),
                new SqlParameter("Name", params2[1]),
                new SqlParameter("NameEng", params2[2]),
                new SqlParameter("Price", params2[3]),
                new SqlParameter("MaxAdults", params2[4]),
                new SqlParameter("MaxChildren", params2[5]),
                new SqlParameter("TotalRooms", params2[6]),
                new SqlParameter("BeachDistance", params2[7]),

            };


            SqlHelper.ExecuteNonQuery(CS, CommandType.StoredProcedure, nameof(CreateNewApartment), parameters);
        }

        public void DeleteApartment(int id)
        {
            SqlHelper.ExecuteNonQuery(CS, nameof(DeleteApartment), id);
        }

        public Apartment SelectApartment(int id)
        {
            var tblAapartment = SqlHelper.ExecuteDataset(CS, nameof(SelectApartment), id).Tables[0];
            DataRow row = tblAapartment.Rows[0];
            return new Apartment
            {
                Id = (int)row["ApartmentId"],
                Owner = new ApartmentOwner
                {
                    Id = (int)row["OwnerId"],
                    Name = row["OwnerName"].ToString()
                },
                ApartmentStatus = new ApartmentStatus
                {
                    Id = (int)row["StatusId"],
                    Name = row["StatusName"].ToString(),
                    NameEng = row["StatusNameEng"].ToString()
                },
                City = new City
                {
                    Id = (int)row["CityId"],
                    CityName = row["CityName"].ToString()
                },
                Address = row["ApartmentAdress"].ToString(),
                Name = row["ApartmentName"].ToString(),
                NameEng = row["ApartmentNameEng"].ToString(),
                Price = row[nameof(Apartment.Price)].ToString().Substring(0, 3),
                MaxAdults = row[nameof(Apartment.MaxAdults)].ToString(),
                MaxChildren = row[nameof(Apartment.MaxChildren)].ToString(),
                TotalRooms = row[nameof(Apartment.TotalRooms)].ToString(),
                BeachDistance = row[nameof(Apartment.BeachDistance)].ToString()
            };
        }

        public IList<Apartment> SelectApartments()
        {
            IList<Apartment> apartments = new List<Apartment>();
            var tblApartments = SqlHelper.ExecuteDataset(CS, nameof(SelectApartments)).Tables[0];
            foreach (DataRow row in tblApartments.Rows)
            {
                apartments.Add(
                    new Apartment
                    {
                        Id = (int)row["ApartmentId"],
                        Owner = new ApartmentOwner
                        {
                            Id = (int)row["OwnerId"],
                            Name = row["OwnerName"].ToString()
                        },
                        ApartmentStatus = new ApartmentStatus
                        {
                            Id = (int)row["StatusId"],
                            Name = row["StatusName"].ToString(),
                            NameEng = row["StatusNameEng"].ToString()
                        },
                        City = new City
                        {
                            Id = (int)row["CityId"],
                            CityName = row["CityName"].ToString()
                        },
                        Address = row["ApartmentAdress"].ToString(),
                        Name = row["ApartmentName"].ToString(),
                        NameEng = row["ApartmentNameEng"].ToString(),
                        Price = row[nameof(Apartment.Price)].ToString().Substring(0, 3),
                        MaxAdults = row[nameof(Apartment.MaxAdults)].ToString(),
                        MaxChildren = row[nameof(Apartment.MaxChildren)].ToString(),
                        TotalRooms = row[nameof(Apartment.TotalRooms)].ToString(),
                        BeachDistance = row[nameof(Apartment.BeachDistance)].ToString()
                    }
                );
            }
            return apartments;
        }

        public void UpdateApartment(int id, int status, List<string> apParameters)
        {

            SqlParameter[] parameters = {
                    new SqlParameter("Id", id),
                    new SqlParameter("StatusId", status),
                    new SqlParameter("Address", apParameters[0]),
                    new SqlParameter("Name", apParameters[1]),
                    new SqlParameter("NameEng",apParameters[2]),
                    new SqlParameter("Price", apParameters[3]),
                    new SqlParameter("MaxAdults", apParameters[4]),
                    new SqlParameter("MaxChildren", apParameters[5]),
                    new SqlParameter("TotalRooms", apParameters[6]),
                    new SqlParameter("BeachDistance", apParameters[7])
                };

            SqlHelper.ExecuteNonQuery(CS, CommandType.StoredProcedure, nameof(UpdateApartment), parameters);


        }

        public int GetApartmentStars(int id)
        {

            IList<int> stars = new List<int>();
            var tblStars = SqlHelper.ExecuteDataset(CS, nameof(GetApartmentStars), id).Tables[0];
            foreach (DataRow row in tblStars.Rows)
            {
                stars.Add((int)row["Stars"]);
            }

            int average = 0;

            if (stars.Count == 0)
            {
                return 0;
            }
            else
            {
                foreach (int star in stars)
                {
                    average += star;
                }

                return average / stars.Count;
            }

        }

        public IList<AssignedTag> GetTagsForApartment(int id)
        {
            IList<AssignedTag> tags = new List<AssignedTag>();
            var tblTags = SqlHelper.ExecuteDataset(CS,nameof(GetTagsForApartment), id).Tables[0];
            foreach (DataRow row in tblTags.Rows)
            {
                tags.Add(

                    new AssignedTag
                    {
                        Id = (int)row["Id"],
                        Name = (string)row["Name"],
                        Type = (string)row["Type"],
                        ApartmentName = (string)row["ApartmentName"]

                    }

                );
            }

            return tags;
        }

        public int GetApIdByName(string name)
        {
            var id = SqlHelper.ExecuteDataset(CS, nameof(GetApIdByName), name).Tables[0];
            foreach(DataRow row in id.Rows)
            {
                return (int)row["Id"];
            }
            return 0;
        }

        public void AddTagToApartment(int apId, int tagId)
        {
            SqlHelper.ExecuteNonQuery(CS, nameof(AddTagToApartment), apId, tagId);
        }

        /*New apartment help methods*/

        public IList<ApartmentOwner> GetApartmentOwners()
        {

            IList<ApartmentOwner> owners = new List<ApartmentOwner>();
            var tblOwners = SqlHelper.ExecuteDataset(CS, nameof(GetApartmentOwners)).Tables[0];
            foreach (DataRow row in tblOwners.Rows)
            {
                owners.Add(

                    new ApartmentOwner
                    {
                        Id = (int)row["Id"],
                        Name = row["Name"].ToString(),
                    });

            }

            return owners;

        }

        public IList<City> GetAllCities()
        {
            IList<City> cities = new List<City>();
            var tblCities = SqlHelper.ExecuteDataset(CS, nameof(GetAllCities)).Tables[0];
            foreach (DataRow row in tblCities.Rows)
            {
                cities.Add(

                    new City
                    {
                        Id = (int)row["Id"],
                        CityName = (string)row["Name"]
                    }
                );
            }

            return cities;
        }

        public void CreateNewOwner(string name)
        {
            SqlHelper.ExecuteNonQuery(CS, nameof(CreateNewOwner), name);
        }

        public int GetOwnerId(string name)
        {
            var tblOwner = SqlHelper.ExecuteDataset(CS, nameof(GetOwnerId), name).Tables[0];

            foreach (DataRow row in tblOwner.Rows)
            {
                return (int)row["Id"];
            }

            return 0;
        }

        public int GetCityId(string name)
        {
            var tblCity = SqlHelper.ExecuteDataset(CS, nameof(GetCityId), name).Tables[0];

            foreach (DataRow row in tblCity.Rows)
            {
                return (int)row["Id"];
            }

            return 0;


        }

        /*User methods*/

        public IList<User> SelectUsers()
        {
            IList<User> users = new List<User>();
            var tblUsers = SqlHelper.ExecuteDataset(CS, nameof(SelectUsers)).Tables[0];
            foreach (DataRow row in tblUsers.Rows)
            {
                users.Add(

                    new User
                    {
                        Id = (int)row["Id"],
                        Name = (string)row["UserName"],
                        PhoneNumber = (string)row["PhoneNumber"],
                        PhoneNumberConfirmed = Convert.ToBoolean(row["PhoneNumberConfirmed"]) == true ? "Da" : "Ne",
                        Address = (string)row["Address"],
                        Mail = (string)row["Email"],
                        MailConfirmed = Convert.ToBoolean(row["EmailConfirmed"]) == true ? "Da" : "Ne",
                    }
                );
            }

            return users;
        }

        public User GetUser(int id)
        {
            var tblUser = SqlHelper.ExecuteDataset(CS, nameof(GetUser), id).Tables[0];
            DataRow row = tblUser.Rows[0];
            return new User
            {
                Id = (int)row["Id"],
                Name = (string)row["UserName"],
                PhoneNumber = (string)row["PhoneNumber"],
                PhoneNumberConfirmed = Convert.ToBoolean(row["PhoneNumberConfirmed"]) == true ? "Da" : "Ne",
                Address = (string)row["Address"],
                Mail = (string)row["Email"],
                MailConfirmed = Convert.ToBoolean(row["EmailConfirmed"]) == true ? "Da" : "Ne",
            };
        }

        /*App user methods*/

        public IList<AppUser> GetAppUsers()
        {
            IList<AppUser> users = new List<AppUser>();
            var tblUsers = SqlHelper.ExecuteDataset(CS, nameof(GetAppUsers)).Tables[0];
            foreach (DataRow row in tblUsers.Rows)
            {
                users.Add(new AppUser
                {
                    Id = (int)row[nameof(AppUser.Id)],
                    Email = row[nameof(AppUser.Email)].ToString(),
                    PasswordHash = row[nameof(AppUser.PasswordHash)].ToString(),
                    PhoneNumber = row[nameof(AppUser.PhoneNumber)].ToString(),
                    UserName = row[nameof(AppUser.UserName)].ToString(),
                    Address = row[nameof(AppUser.Address)].ToString()
                });
            }
            return users;
        }

        public AppUser GetAppUser(int id)
        {
            var tblUser = SqlHelper.ExecuteDataset(CS, nameof(GetAppUser), id).Tables[0];
            DataRow row = tblUser.Rows[0];
            return new AppUser
            {
                Id = (int)row[nameof(User.Id)],
                Email = row[nameof(AppUser.Email)].ToString(),
                PasswordHash = row[nameof(AppUser.PasswordHash)].ToString(),
                PhoneNumber = row[nameof(AppUser.PhoneNumber)].ToString(),
                UserName = row[nameof(AppUser.UserName)].ToString(),
                Address = row[nameof(AppUser.Address)].ToString()
            };
        }

        public int CreateAppUser(AppUser user)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@Email",user.Email),
                new SqlParameter("@PasswordHash",user.PasswordHash),
                new SqlParameter("@PhoneNumber",user.PhoneNumber),
                new SqlParameter("@UserName",user.UserName),
                new SqlParameter("@Address",user.Address),
                new SqlParameter("Id",SqlDbType.Int),
            };

            parameters[parameters.Length - 1].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(CS, nameof(CreateAppUser), parameters);
            int.TryParse(parameters[parameters.Length - 1].ToString(), out int id);
            return id;
        }

        public IList<ApartmentReview> GetUserReviews(int id)
        {
            IList<ApartmentReview> reviews = new List<ApartmentReview>();
            var tblReviews = SqlHelper.ExecuteDataset(CS, nameof(GetUserReviews), id).Tables[0];
            foreach (DataRow row in tblReviews.Rows)
            {
                reviews.Add(

                    new ApartmentReview
                    {
                        ApartmentId = (int)row["ApartmentId"],
                        UserId = (int)row["UserId"],
                        Details = row["Details"].ToString(),
                        Stars = (int)row["Stars"]

                    }
                    );
            }

            return reviews;
        }

        public IList<Reservation> GetUserReservations(int id)
        {
            IList<Reservation> reservations = new List<Reservation>();
            var tblReservations = SqlHelper.ExecuteDataset(CS, nameof(GetUserReservations),id).Tables[0];
            foreach (DataRow row in tblReservations.Rows)
            {
                reservations.Add(

                    new Reservation
                    {
                        Id = (int)row["Id"],
                        ApartmentId = (int)row["ApartmentId"],
                        ApartmentName = (string)row["ApartmentName"],
                        Details = (string)row["Details"],
                        UserId = (int)row["UserId"],
                        UserName = (string)row["UserName"]
                    }
                    );
            }

            return reservations;
        }



        /*Reservation methods*/

        public IList<Reservation> GetReservations()
        {
            IList<Reservation> reservations = new List<Reservation>();
            var tblReservations = SqlHelper.ExecuteDataset(CS, nameof(GetReservations)).Tables[0];
            foreach (DataRow row in tblReservations.Rows)
            {
                reservations.Add(

                    new Reservation
                    {
                        Id = (int)row["Id"],
                        ApartmentId = (int)row["ApId"],
                        ApartmentName = (string)row["ApName"],
                        Details = (string)row["Details"],
                        UserId = (int)row["UsrId"],
                        UserName = (string)row["UserName"]
                    }
                    );
            }

            return reservations;
        }

        public IList<UnRegUserReservation> GetUnRegUserReservations()
        {
            IList<UnRegUserReservation> reservations = new List<UnRegUserReservation>();
            var tblReservations = SqlHelper.ExecuteDataset(CS, nameof(GetUnRegUserReservations)).Tables[0];
            foreach (DataRow row in tblReservations.Rows)
            {
                reservations.Add(

                    new UnRegUserReservation
                    {
                        Id = (int)row["Id"],
                        ApartmentId = (int)row["ApartmentId"],
                        ApartmentName = (string)row["Name"],
                        Details = (string)row["Details"],
                        User = new UnregisteredUser
                        {
                            Name = (string)row["UserName"],
                            Email = (string)row["UserEmail"],
                            Phone = (string)row["UserPhone"],
                            Address = (string)row["UserAddress"]
                        }
                    }
                    );
            }

            return reservations;
        }

        public List<int> GetReservationDetails(int reservationId)
        {
            List<int> details = new List<int>();
            var tblDetails = SqlHelper.ExecuteDataset(CS, nameof(GetReservationDetails), reservationId).Tables[0];
            int apId = 0;
            int usrId = 0;
            foreach (DataRow row in tblDetails.Rows)
            {
                apId = (int)row["ApartmentId"];
                usrId = (int)row["UserId"];
            }

            details.Add(apId);
            details.Add(usrId);

            return details;
        }

        public void DeleteReservation(int reservationId)
        {
            SqlHelper.ExecuteNonQuery(CS, nameof(DeleteReservation), reservationId);
        }

        public UnRegUserReservation SelectUnRegUserReservation(int id)
        {
            var tblReservation = SqlHelper.ExecuteDataset(CS, nameof(SelectUnRegUserReservation), id).Tables[0];
            DataRow row = tblReservation.Rows[0];
            return new UnRegUserReservation
            {
                Id = (int)row["Id"],
                ApartmentId = (int)row["ApartmentId"],
                ApartmentName = (string)row["Name"],
                Details = (string)row["Details"],
                User = new UnregisteredUser
                {
                    Name = (string)row["UserName"],
                    Email = (string)row["UserEmail"],
                    Phone = (string)row["UserPhone"],
                    Address = (string)row["UserAddress"]
                }
            };
        }

        /*Tag methods*/

        public IList<UnusedTag> SelectUnusedTags()
        {
            IList<UnusedTag> unusedTags = new List<UnusedTag>();
            var tblUnusedTags = SqlHelper.ExecuteDataset(CS, nameof(SelectUnusedTags)).Tables[0];
            foreach (DataRow row in tblUnusedTags.Rows)
            {

                unusedTags.Add(

                    new UnusedTag
                    {
                        Id = (int)row["Id"],
                        Name = (string)row["Name"],
                        Type = (string)row["TypeName"]
                    }
                    );
  
            }

            return unusedTags;
        }

        public IList<AssignedTag> SelectAssignedTags()
        {
            List<AssignedTag> assignedTags = new List<AssignedTag>();
            var tblAssignedTags = SqlHelper.ExecuteDataset(CS, nameof(SelectAssignedTags)).Tables[0];
            foreach (DataRow row in tblAssignedTags.Rows)
            {

                assignedTags.Add(

                    new AssignedTag
                    {
                        Id = (int)row["Id"],
                        Name = (string)row["TagName"],
                        Type = (string)row["TypeName"],
                        ApartmentName = (string)row["ApName"]
                    }
                    );

            }

            return assignedTags;

        }

        public void DeleteTag(int id)
        {
            SqlHelper.ExecuteNonQuery(CS, nameof(DeleteTag), id);
        }

        public IList<TagType> GetTagTypes()
        {
            IList<TagType> tagTypes = new List<TagType>();
            var tblTagTypes = SqlHelper.ExecuteDataset(CS, nameof(GetTagTypes)).Tables[0];
            foreach (DataRow row  in tblTagTypes.Rows)
            {
                tagTypes.Add(

                    new TagType
                    {
                        Id= (int)row["Id"],
                        Name = row["Name"].ToString()
                    }
                    );
            }

            return tagTypes;
        }

        public int GetTagTypeId(string name)
        {

            var typeId = SqlHelper.ExecuteDataset(CS, nameof(GetTagTypeId), name).Tables[0];

            foreach (DataRow row in typeId.Rows)
            {
                return (int)row["Id"];
            }

            return 0;

        }

        public void InsertTag(int id, string nameCro, string nameEng)
        {
            SqlHelper.ExecuteNonQuery(CS, nameof(InsertTag), id, nameCro, nameEng);
        }

        public IList<string> GetTagNames()
        {
            IList<string> tagNames = new List<string>();
            var tblTagNames = SqlHelper.ExecuteDataset(CS, nameof(GetTagNames)).Tables[0];

            foreach (DataRow row in tblTagNames.Rows)
            {
                tagNames.Add(row["Name"].ToString());
            }


            return tagNames;

        }

        public int GetTagIdByName(string name)
        {
            var id = SqlHelper.ExecuteDataset(CS, nameof(GetTagIdByName), name).Tables[0];
            foreach(DataRow row in id.Rows)
            {
                return (int)row["Id"];
            }
            return 0;
        }

        /*Apartment reviews*/

        public IList<ApartmentReview> GetApartmentReviews(int id)
        {
            IList<ApartmentReview> reviews = new List<ApartmentReview>();
            var tblReviews = SqlHelper.ExecuteDataset(CS, nameof(GetApartmentReviews),id).Tables[0];
            foreach (DataRow row in tblReviews.Rows)
            {
                reviews.Add(

                    new ApartmentReview
                    {
                        ApartmentId = (int)row["ApartmentId"],
                        UserId = (int)row["UserId"],
                        Details = row["Details"].ToString() == null ? "Nema komentara" : row["Details"].ToString(),
                        Stars = (int)row["Stars"]
                    }
                    );
            }

            return reviews;
        }

        public void LeaveReview(ApartmentReview review)
        {

            SqlParameter[] parameters =
{
                new SqlParameter("@ApartmentId",review.ApartmentId),
                new SqlParameter("@UserId",review.UserId),
                new SqlParameter("@Details",review.Details),
                new SqlParameter("@Stars",review.Stars)
                
            };


            SqlHelper.ExecuteNonQuery(CS,nameof(LeaveReview), parameters);
        }

    }
}
