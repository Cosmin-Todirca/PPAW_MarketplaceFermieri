using System.ComponentModel.DataAnnotations;

namespace ViewModels
{
    public class VanzatorBaseViewModel
    {
        public int idVanzator { get; set; }
        public string numeVanzator { get; set; }
        public string prenumeVanzator { get; set; }
        public string email { get; set; }
        public string numarTelefon { get; set; }

        public bool logicalDelete { get; set; }
    }
    public class CreateVanzatorViewModel
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(100)]
        public string numeVanzator { get; set; }
        [Required(ErrorMessage = "Surname is required")]
        [StringLength(100)]
        public string prenumeVanzator { get; set; }
        [StringLength(200)]
        public string email { get; set; }
        [Required(ErrorMessage = "PhoneNumber is required")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(11)]
        public string numarTelefon { get; set; }
        [Required(ErrorMessage = "Delete field is required")]
        public bool logicalDelete { get; set; }
    }

    public class ReadVanzatorViewModel
    {
        public int idVanzator { get; set; }
        public string numeVanzator { get; set; }
        public string prenumeVanzator { get; set; }
        public string email { get; set; }
        public string numarTelefon { get; set; }
        public bool logicalDelete { get; set; }

    }

    //https://dotnettutorials.net/lesson/automapper-in-c-sharp/

    public class ReadVanzatorCardViewModel
    {
        public int idVanzator { get; set; }
        public string numeVanzator { get; set; }
        public string prenumeVanzator { get; set; }
    }

    public class UpdateVanzatorViewModel
    {
        [Required(ErrorMessage = "ID is required")]
        [RegularExpression("([1-9][0-9]*)")]
        public int idVanzator { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [StringLength(100)]
        public string numeVanzator { get; set; }
        [Required(ErrorMessage = "Surname is required")]
        [StringLength(100)]
        public string prenumeVanzator { get; set; }
        [StringLength(200)]
        public string email { get; set; }
        [Required(ErrorMessage = "PhoneNumber is required")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(11)]
        public string numarTelefon { get; set; }
        [Required(ErrorMessage = "Delete field is required")]
        public bool logicalDelete { get; set; }
    }
}
