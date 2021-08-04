using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cgm.Ecoupon.Api.Models.CompanyDetails
{
    public class CompanyDetailsDto
    {
        [Required]
        public string CompanyName { get; set; }
        [Required]
        public string CompanyBName { get; set; }
        [Required]
        public string CompanyDescription { get; set; }
        [Required]
        public string CompanyImageUrl { get; set; }
        [Required]
        public string UserId { get; set; }

        public Guid CompanyId { get; set; }
        [Required]
        public string BackendMobileNumber { get; set; }
        [Required]
        public string BackendMobileNumberPassword { get; set; }

        public Guid OfferBackendNumberId { get; set; }

    }

    public class CompanyDetailsAddDto
    {
        [Required]
        public string CompanyName { get; set; }
        [Required]
        public string CompanyBName { get; set; }
        [Required]
        public string CompanyDescription { get; set; }
        [Required]
        public string CompanyImageUrl { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required]
        public string BackendMobileNumber { get; set; }
        [Required]
        public string BackendMobileNumberPassword { get; set; }
    }

    public class CompanyDetailsDeleteDto
    {
        [Required]
        public Guid CompanyId { get; set; }
        [Required]
        public string UserId { get; set; }

    }

    public class UploadCompanyDetailsDto
    {
        public List<CompanyDetailsDto> CompanyDetailsList { get; set; }
        public string UserId { get; set; }
    }
}