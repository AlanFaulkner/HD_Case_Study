using AutoMapper;
using CaseStudy.DataTransferObjects;
using CaseStudy.DataTransferObjects.DatabaseDTOs;
using CaseStudy.DataTransferObjects.ResultsDTOs;
using CaseStudy.ViewModels.ResultDTOs;
using DomainLogic.Entities;

namespace CaseStudy
{
    /// <summary>
    /// configuration used by automapper to provide mapping between DTOs and entity objects
    /// </summary>
    public static class AutoMapperConfig
    {
        internal static bool MapperInitialised { get; private set; }

        public static MapperConfiguration Configure()
        {
            var configuration = new MapperConfiguration(config =>
            {
                config.CreateMap<ApplicantSummitDTO, Applicant>()
                    .ConstructUsing(x => new Applicant(x.FirstName, x.LastName, x.DateOfBirth, x.AnnualIncome))
                    .ForAllOtherMembers(x => x.Ignore());

                config.CreateMap<Applicant, ApplicationDatabaseEntity>()
                    .ForMember(x => x.CreditCardName, c => c.MapFrom(v => v.ApplicableCreditCard.CreditCardName))
                    .ForMember(x => x.APR, c => c.MapFrom(v => v.ApplicableCreditCard.APR))
                    .ForMember(x => x.Image, c => c.MapFrom(v => v.ApplicableCreditCard.Image))
                    .ForMember(x => x.WelcomeMessage, c => c.MapFrom(v => v.ApplicableCreditCard.WelcomeMessage));

                config.CreateMap<ApplicationDatabaseEntity, CreditCardResultsDTO>();
                config.CreateMap<ApplicationDatabaseEntity, ApplicantResultsDTO>();
            });

            configuration.AssertConfigurationIsValid();
            return configuration;
        }
    }
}