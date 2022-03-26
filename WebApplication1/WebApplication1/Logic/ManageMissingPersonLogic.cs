using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using WebApplication1.Data;
using WebApplication1.Models;
using System.Web.Mvc;

namespace WebApplication1.Logic
{
    public class ManageMissingPersonLogic
    {
        public List<MissingPersonModel> GetMissingPeopleDetail()
        {
            try
            {
                List<MissingPersonModel> missingPeopleList = new List<MissingPersonModel>();

                using (MissingPersonEntities entities = new MissingPersonEntities())
                {
                    missingPeopleList = (from people in entities.MissingPersonDatas
                                         orderby people.Id descending
                                         select new MissingPersonModel
                                         {
                                             Id= people.Id,
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

        public bool SaveMissingPersonDetail(MissingPersonModel model)
        {
            try
            {
                using (MissingPersonEntities entities = new MissingPersonEntities())
                {
                    var personDetail = new MissingPersonData();

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
                    personDetail.Found = model.Found;

                    entities.MissingPersonDatas.Add(personDetail);
                    entities.SaveChanges();

                }
                
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private static int CalculateAge(DateTime dateOfBirth)
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



        public void UpdateMissingPersonDetail(MissingPersonModel model)
        {
            try
            {
                using (MissingPersonEntities entities = new MissingPersonEntities())
                {
                    var personDetail = (from x in entities.MissingPersonDatas
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

                    entities.SaveChanges();
                }
            }
            catch (Exception ex)
            {

            }
        }

        public MissingPersonModel GetMissingPersonDetailById(int id)
        {
            try
            {
                MissingPersonModel model = new MissingPersonModel();
                using (MissingPersonEntities entities = new MissingPersonEntities())
                {
                    model = (from x in entities.MissingPersonDatas
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
                                 SpouseName = x.SpouseName

                             }).FirstOrDefault();
                }

                return model;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}