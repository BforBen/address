using System;
using System.ComponentModel.DataAnnotations;

namespace GuildfordBoroughCouncil.Address.Models
{
    public enum AddressStatus
    {
        Active,
        Alternative,
        Provisional,
        Historic,
        Candidate,
        Rejected
    }

    /// <summary>
    /// Address search scope
    /// </summary>
    public enum AddressSearchScope
    {
        /// <summary>
        /// Search the LLPG
        /// </summary>
        Local,
        /// <summary>
        /// Search AddressBase but constrain results to the authority codes listed in the LocalPlusSurroundingCodes setting
        /// </summary>
        LocalPlusSurrounding,
        /// <summary>
        /// Search AddressBase if no results are found in the LLPG
        /// </summary>
        National
    }

    [DisplayColumn("FullAddress")]
    public class Address
    {
        public Int64? Uprn { get; set; }
        public Int64? Usrn { get; set; }
        [MaxLength(200)]
        public string Organisation { get; set; }
        [DataType(DataType.MultilineText)]
        [MaxLength(200)]
        public string Property { get; set; }
        [MaxLength(200)]
        public string Street { get; set; }
        [MaxLength(200)]
        public string Locality { get; set; }
        [MaxLength(200)]
        public string Town { get; set; }
        [MaxLength(200)]
        public string PostTown { get; set; }
        [MaxLength(200)]
        public string County { get; set; }
        [MaxLength(10)]
        public string PostCode { get; set; }
        [MaxLength(200)]
        public string Country { get; set; }

        public double? Longitude { get; set; }
        public double? Latitude { get; set; }

        public double? Northing { get; set; }
        public double? Easting { get; set; }

        public string Classification { get; set; }

        public string Distance { get; set; }

        public string FullAddress { get; set; }

        public AddressStatus Status { get; set; }

        public int? AuthorityCode { get; set; }
        public string Authority { get; set; }

        /// <summary>
        /// Is the address in the borough for the set authority code
        /// </summary>
        public bool InBorough
        {
            get
            {
                return (AuthorityCode == Properties.Settings.Default.AuthorityCode);
            }
        }
    }
}
