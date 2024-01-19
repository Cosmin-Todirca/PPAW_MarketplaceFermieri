using System;
using System.ComponentModel.DataAnnotations;

namespace ViewModels
{
    public class ComandaBaseViewModel
    {
        public int idComanda { get; set; }
        public int idClient { get; set; }
        public DateTime dataComanda { get; set; }
        public string situatieComanda { get; set; }
        public decimal total { get; set; }
    }

    public class CreateComandaViewModel
    {
        [Required(ErrorMessage = "IDClient is required")]
        [RegularExpression("([1-9][0-9]*)")]
        public int idClient { get; set; }
        //public DateTime dataComanda { get; set; }
        [Required(ErrorMessage = "Status is required")]
        [StringLength(50)]
        public string situatieComanda { get; set; }
        [Required(ErrorMessage = "Total is required")]
        [Range(0, 10000, ErrorMessage = "Total must be between 0 and 10000 units")]
        [DataType(DataType.Currency)]
        public decimal total { get; set; }
    }

    public class ReadComandaViewModel
    {
        public int idComanda { get; set; }
        public int idClient { get; set; }
        public DateTime dataComanda { get; set; }
        public string situatieComanda { get; set; }
        public decimal total { get; set; }
    }
    public class UpdateComandaViewModel
    {
        [Required(ErrorMessage = "IDComanda is required")]
        [RegularExpression("([1-9][0-9]*)")]
        public int idComanda { get; set; }
        [Required(ErrorMessage = "IDClient is required")]
        [RegularExpression("([1-9][0-9]*)")]
        public int idClient { get; set; }
        //public DateTime dataComanda { get; set; }
        [Required(ErrorMessage = "Status is required")]
        [StringLength(50)]
        public string situatieComanda { get; set; }
        [Required(ErrorMessage = "Price is required")]
        [Range(0, 10000, ErrorMessage = "Price must be between 0 and 10000 units")]
        [DataType(DataType.Currency)]
        public decimal total { get; set; }
    }
}
