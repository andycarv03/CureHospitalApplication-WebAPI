using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CureHospitalDALCrossPlatform.Models;
using CureHospitalDALCrossPlatForm;
using CureHospitalWebService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CureHospitalWebService.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HomeController : Controller
    {
        HospitalRepository hospitalRepository;
        public HomeController(HospitalRepository repository)
        {
            hospitalRepository = repository;
        }

        #region FetchDoctorIDs
        [HttpGet]
        public JsonResult FetchDoctorIDs(string specializationCode)
        {
            List<int> doctorIds;
            try
            {
                doctorIds = hospitalRepository.FetchDoctorIDs(specializationCode);
            }
            catch (Exception ex) 
            {
                doctorIds = null;
            }
            return Json(doctorIds);

        }
        #endregion

        #region AddDoctorSpecialization
        [HttpPost]
        public bool AddDoctorSpecialization(int doctorId, string specializationCode, DateTime specializationDate)
        {
            bool result;
            try
            {
                result = hospitalRepository.AddDoctorSpecialization(doctorId, specializationCode, specializationDate);
            }
            catch (Exception ex) 
            {
                result = false;
            }
            return result;
        }
        #endregion

        #region UpdateSurgeryTime
        [HttpPut]
        public int UpdateSurgeryTime(Models.Surgery surgery)
        {
            int result;
            try
            {
                result = hospitalRepository.UpdateSurgeryTime(surgery.SurgeryId, surgery.EndTime);
            }
            catch(Exception ex) 
            {
                result = 0;
            }
            return result;
        }
        #endregion

        #region RemoveSurgeryDetails
        [HttpDelete]
        public JsonResult RemoveSurgeryDetails(DateTime surgeryDate)
        {
            bool result;
            try
            {
                result = hospitalRepository.RemoveSurgeryDetails(surgeryDate);
            }
            catch( Exception ex ) 
            {
                result = false;
            }
            return Json(result);
        }
        #endregion
    }
}