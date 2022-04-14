using Microsoft.AspNetCore.Hosting;
using MissingPersonWebApp.Data;
using MissingPersonWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MissingPersonWebApp.Logic
{
    public class ManageMissingPersonLogic
    {
       
        public List<MissingPersonModel> GetMissingPeopleDetail()
        {
            try
            {
                List<MissingPersonModel> missingPeopleList = new List<MissingPersonModel>();

                using (MissingPersonAwarenessContext entities = new MissingPersonAwarenessContext())
                {
                    missingPeopleList = (from people in entities.MissingPersonData
                                         orderby people.Id descending
                                         select new MissingPersonModel
                                         {
                                             Id = people.Id,
                                             FullName = people.FirstName,
                                             FirstName = people.FirstName,
                                             LastName = people.LastName,
                                             Age = people.Age,
                                             DateOfBirth = people.DateOfBirth,
                                             Address = people.Address,
                                             FatherName = people.FatherName,
                                             MotherName = people.MotherName,
                                             SpouseName = people.SpouseName,
                                             ImagePath = people.ImagePath,
                                             ImageName = people.ImageName,
                                             MissingDate = people.MissingDate,
                                             Found = people.Found == true ? true : false
                                         }).ToList();
                }
                return missingPeopleList;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public int SaveMissingPersonDetail(MissingPersonModel model)
        {
            try
            {
                var personDetail = new MissingPersonDatum();
                using (MissingPersonAwarenessContext entities = new MissingPersonAwarenessContext())
                {

                    personDetail.Address = model.Address;
                    personDetail.Age = CalculateAge(model.DateOfBirth);
                    personDetail.CreatedDatetime = DateTime.Now;
                    personDetail.DateOfBirth = model.DateOfBirth;
                    personDetail.FatherName = model.FatherName;
                    personDetail.MotherName = model.MotherName;
                    personDetail.SpouseName = model.SpouseName;
                    personDetail.ImagePath = model.ImagePath;
                    personDetail.ImageName = model.ImageName.Replace(" ","");
                    personDetail.FullName = model.FirstName + " " + model.LastName;
                    personDetail.FirstName = model.FirstName;
                    personDetail.LastName = model.LastName;
                    personDetail.MissingDate = model.MissingDate;
                    personDetail.Found = model.Found;
                    personDetail.IsLiveOnFacebook = model.PublishonFacebook;
                    personDetail.IsLiveOnTwitter = model.PublishonTwitter;

                    entities.MissingPersonData.Add(personDetail);
                    entities.SaveChanges();
                }

                return personDetail.Id; 
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public int CalculateAge(DateTime dateOfBirth)
        {
            try
            {
                int age = 0;
                age = DateTime.Now.Year - dateOfBirth.Year;
                if (DateTime.Now.DayOfYear < dateOfBirth.DayOfYear)
                    age = age - 1;

                return age;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        
        public bool UpdateMissingPersonDetail(MissingPersonModel model)
        {
            bool isUpdated = false;
            try
            {
                using (MissingPersonAwarenessContext entities = new MissingPersonAwarenessContext())
                {
                    var personDetail = (from x in entities.MissingPersonData
                                        where x.Id == model.Id
                                        select x).FirstOrDefault();

                    personDetail.Address = model.Address;
                    personDetail.Age = CalculateAge(model.DateOfBirth);
                    personDetail.CreatedDatetime = DateTime.Now;
                    personDetail.DateOfBirth = model.DateOfBirth;
                    personDetail.FatherName = model.FatherName;
                    personDetail.MotherName = model.MotherName;
                    personDetail.SpouseName = model.SpouseName;
                    personDetail.ImagePath = model.ImagePath;
                    personDetail.ImageName = model.ImageName;
                    personDetail.FullName = model.FirstName + " " + model.LastName;
                    personDetail.FirstName = model.FirstName;
                    personDetail.LastName = model.LastName;
                    personDetail.MissingDate = model.MissingDate;
                    personDetail.UpdateDatetime = DateTime.Now;
                    personDetail.IsLiveOnFacebook = model.PublishonFacebook;
                    personDetail.IsLiveOnTwitter = model.PublishonTwitter;

                    entities.Update(personDetail);
                    entities.SaveChanges();

                    isUpdated = true;
                }
            }
            catch (Exception ex)
            {
                return isUpdated;
            }

            return isUpdated;
        }

        public bool UpdateFacebookPostId(MissingPersonModel model)
        {
            bool isUpdated = false;
            try
            {
                using (MissingPersonAwarenessContext entities = new MissingPersonAwarenessContext())
                {
                    var personDetail = (from x in entities.MissingPersonData
                                        where x.Id == model.Id
                                        select x).FirstOrDefault();

                    personDetail.FacebookAccountId = model.FacebookAccountId;
                    personDetail.FacebookText = model.FacebookText;
                    personDetail.FacebookPostId = model.FacebookPostId;

                    entities.Update(personDetail);
                    entities.SaveChanges();

                    isUpdated = true;
                }

                return isUpdated;
            }
            catch (Exception ex)
            {
                return isUpdated;
            }
        }

        public bool UpdateTwitterPostId(MissingPersonModel model)
        {
            bool isUpdated = false;
            try
            {
                using (MissingPersonAwarenessContext entities = new MissingPersonAwarenessContext())
                {
                    var personDetail = (from x in entities.MissingPersonData
                                        where x.Id == model.Id
                                        select x).FirstOrDefault();

                    personDetail.TwitterAccountId = model.TwitterAccountId;
                    personDetail.TwitterText = model.TwitterText;
                    personDetail.TwitterPostId = model.TwitterPostId;

                    entities.Update(personDetail);
                    entities.SaveChanges();

                    isUpdated = true;
                }

                return isUpdated;
            }
            catch (Exception ex)
            {
                return isUpdated;
            }
        }

        public MissingPersonModel GetMissingPersonDetailById(int id)
        {
            try
            {
                MissingPersonModel model = new MissingPersonModel();
                using (MissingPersonAwarenessContext entities = new MissingPersonAwarenessContext())
                {
                    model = (from x in entities.MissingPersonData
                             where x.Id == id
                             select new MissingPersonModel
                             {
                                 Address = x.Address,
                                 Age = x.Age,
                                 CreatedDatetime = x.CreatedDatetime,
                                 DateOfBirth = x.DateOfBirth,
                                 FatherName = x.FatherName,
                                 ImageName = x.ImageName,
                                 ImagePath = x.ImagePath,
                                 FirstName = x.FirstName,
                                 Found = x.Found,
                                 FullName = x.FullName,
                                 Id = x.Id,
                                 LastName = x.LastName,
                                 MissingDate = x.MissingDate,
                                 MotherName = x.MotherName,
                                 SpouseName = x.SpouseName,
                                 PublishonFacebook= x.IsLiveOnFacebook,
                                 PublishonTwitter = x.IsLiveOnTwitter,
                                 FacebookPostId = x.FacebookPostId,
                                 TwitterPostId= x.TwitterPostId

                             }).FirstOrDefault();
                }

                return model;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool DeleteMissingPerson(int id)
        {
            bool isUpdated = false;

            using (MissingPersonAwarenessContext entities = new MissingPersonAwarenessContext())
            {
                var detail = (from x in entities.MissingPersonData
                              where x.Id == id
                              select x).FirstOrDefault();

                entities.MissingPersonData.Remove(detail);
                entities.SaveChanges();

                isUpdated = true;
            }

            return isUpdated;
        }
    }
}
