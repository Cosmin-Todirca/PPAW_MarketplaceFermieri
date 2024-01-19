using System;
using System.ComponentModel.DataAnnotations;

namespace ViewModels
{
    public class ClientBaseViewModel
    {
        public int idClient { get; set; }
        public string numeClient { get; set; }
        public string prenumeClient { get; set; }
        public string email { get; set; }
        public string numarTelefon { get; set; }
    }


    public class CreateClientViewModel
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(100)]
        public string numeClient { get; set; }
        [Required(ErrorMessage = "Surname is required")]
        [StringLength(100)]
        public string prenumeClient { get; set; }
        [StringLength(200)]
        public string email { get; set; }
        [Required(ErrorMessage = "PhoneNumber is required")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(11)]
        public string numarTelefon { get; set; }
    }
    public class ReadClientViewModel
    {
        public int idClient { get; set; }
        public string numeClient { get; set; }
        public string prenumeClient { get; set; }
        public string email { get; set; }
        public string numarTelefon { get; set; }
    }

    public class UpdateClientViewModel
    {
        [Required(ErrorMessage = "ID is required")]
        [RegularExpression("([1-9][0-9]*)")]
        public int idClient { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [StringLength(100)]
        public string numeClient { get; set; }
        [Required(ErrorMessage = "Surname is required")]
        [StringLength(100)]
        public string prenumeClient { get; set; }
        [StringLength(200)]
        public string email { get; set; }
        [Required(ErrorMessage = "PhoneNumber is required")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(11)]
        public string numarTelefon { get; set; }
    }
}
