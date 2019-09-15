using CaseStudy.DataTransferObjects;
using CaseStudy.DataTransferObjects.ResultsDTOs;
using CaseStudy.ViewModels.ResultDTOs;
using System;
using System.Collections.Generic;

namespace CaseStudy.Repositories
{
    public interface IApplicationRepository
    {
        List<ApplicantResultsDTO> ApplicantResults();

        Guid SubmitNewApplicant(ApplicantSummitDTO newApplicant);

        CreditCardResultsDTO GetApplicantsCreditCard(Guid applicantId);
    }
}