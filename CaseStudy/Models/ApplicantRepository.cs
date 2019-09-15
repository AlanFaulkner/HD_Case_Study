using AutoMapper;
using CaseStudy.DataTransferObjects;
using CaseStudy.DataTransferObjects.DatabaseDTOs;
using CaseStudy.DataTransferObjects.ResultsDTOs;
using CaseStudy.ViewModels.ResultDTOs;
using DomainLogic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CaseStudy.Repositories
{
    public sealed class ApplicantRepository : IApplicationRepository
    {
        private readonly ApplicationDatabaseContext _appDbContext;
        private readonly IMapper _mapper;

        public ApplicantRepository(ApplicationDatabaseContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        public List<ApplicantResultsDTO> ApplicantResults()
        {
            return _mapper.Map<List<ApplicantResultsDTO>>(_appDbContext.Applicants.ToList());
        }

        /// <summary>
        /// Maps new application to its domain object, validates the supplied values and approves application
        /// The results are maped to a database entity and saved to the database.
        /// </summary>
        /// <param name="newApplicant"></param>
        /// <returns> The database id of the application. </returns>
        public Guid SubmitNewApplicant(ApplicantSummitDTO newApplicant)
        {
            try
            {
                var application = _mapper.Map<Applicant>(newApplicant);
                var resultOfApproval = application.ApproveApplication();
                var databaseEntity = _mapper.Map<ApplicationDatabaseEntity>(resultOfApproval);

                _appDbContext.Add(databaseEntity);
                _appDbContext.SaveChanges();
                return databaseEntity.Id;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        /// <summary>
        /// Uses id of applicant to obtain their credit card result.
        /// </summary>
        /// <param name="applicantId"> Applicant database id </param>
        /// <returns> Credit card results data </returns>
        public CreditCardResultsDTO GetApplicantsCreditCard(Guid applicantId)
        {
            try
            {
                var result = _appDbContext.Applicants.FirstOrDefault(x => x.Id == applicantId);

                if (result == null) throw new ArgumentException("Not Found");
                return _mapper.Map<CreditCardResultsDTO>(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}