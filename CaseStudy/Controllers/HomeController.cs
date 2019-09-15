using CaseStudy.DataTransferObjects;
using CaseStudy.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CaseStudy.Controllers
{
    /// <summary>
    /// Default controller
    /// </summary>
    public class HomeController : Controller
    {
        private readonly IApplicationRepository _applicationRepository;

        public HomeController(IApplicationRepository applicationRepository)
        {
            _applicationRepository = applicationRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Default page displays web form for submitting application
        /// </summary>
        /// <param name="applicant"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Index(ApplicantSummitDTO applicant)
        {
            try
            {
                var result = _applicationRepository.SubmitNewApplicant(applicant);
                return RedirectToAction("ApplicationResults", new { applicationId = result });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest();
            }
        }

        /// <summary>
        /// Displays results data on a successful application
        /// </summary>
        /// <param name="applicationId"></param>
        /// <returns> Applicants result</returns>
        [HttpGet("{applicationId}")]
        public IActionResult ApplicationResults(Guid applicationId)
        {
            try
            {
                return View(_applicationRepository.GetApplicantsCreditCard(applicationId));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest();
            }
        }

        /// <summary>
        /// Returns a list of all applicants stored in database along with their results.
        /// </summary>
        /// <returns> All Applicants data. </returns>
        [HttpGet]
        public IActionResult DatabaseView()
        {
            try
            {
                return View(_applicationRepository.ApplicantResults());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest();
            }
        }
    }
}