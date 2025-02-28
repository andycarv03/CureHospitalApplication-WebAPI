using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Data;
using CureHospitalDALCrossPlatform.Models;

namespace CureHospitalDALCrossPlatForm
{
    public class HospitalRepository
    {
        CureWellDBContext context;

        #region Constructor
        public HospitalRepository(CureWellDBContext context)
        {
            this.context = context;
            
        }
        #endregion

        #region FetchDoctorIDs
        public List<int> FetchDoctorIDs(string specializationCode)
        {
            List<int> doctorId = new List<int>();
            try
            {
                doctorId = (from v in context.DoctorSpecializations 
                            where v.SpecializationCode.Equals(specializationCode) 
                            select v.DoctorId).ToList();
            }
            catch (Exception)
            {
                doctorId = null;
            }
            return doctorId;
        }
        #endregion

        #region AddDoctorSpecialization
        public bool AddDoctorSpecialization(int doctorId, string specializationCode, DateTime specializationDate)
        {
            bool retval = false;
            try
            {
                DoctorSpecialization dsObj = new DoctorSpecialization();
                dsObj.DoctorId = doctorId;
                dsObj.SpecializationCode = specializationCode;
                dsObj.SpecializationDate = specializationDate;

                context.DoctorSpecializations.Add(dsObj);
                context.SaveChanges();
                retval = true;
            }
            catch (Exception)            
            {
                retval = false;
            }
            return retval;
        }
        #endregion

        #region UpdateSurgeryTime
        public int UpdateSurgeryTime(int surgeryID, decimal newEndTime)
        {
            int retval = 0;
            try
            {
                var surgeryObj = context.Surgeries.Find(surgeryID);
                if (newEndTime > surgeryObj.StartTime)
                {
                    surgeryObj.EndTime = newEndTime;
                    context.SaveChanges();
                    retval = 1;
                }
            }
            catch (Exception)
            {
                retval = 0;
            }
            return retval;
        }
        #endregion

        #region RemoveSurgeryDetails
        public bool RemoveSurgeryDetails(DateTime surgeryDate)
        {
            bool retVal = false;
            try
            {
                var surgeryObjList = context.Surgeries.Where(x => x.SurgeryDate == surgeryDate).ToList<Surgery>();
                foreach (Surgery obj in surgeryObjList)
                {
                    context.Surgeries.Remove(obj);
                    context.SaveChanges();
                }
                retVal = true;
            }
            catch (Exception)
            {
                retVal = false;
            }
            return retVal;
        }
        #endregion
    }
}
