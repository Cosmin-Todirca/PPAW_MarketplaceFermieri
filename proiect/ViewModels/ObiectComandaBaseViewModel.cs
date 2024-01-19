﻿using System.ComponentModel.DataAnnotations;

namespace ViewModels
{
    public class ObiectComandaBaseViewModel
    {
        public int idObiectComanda { get; set; }
        public int idComanda { get; set; }
        public int idProdus { get; set; }
        public int idClient { get; set; }
        public string situatiePlata { get; set; }
        public decimal cantitateComanda { get; set; }
    }

    public class CreateObiectComandaViewModel
    {
        [Required(ErrorMessage = "ID is required")]
        [RegularExpression("([1-9][0-9]*)")]
        public int idComanda { get; set; }
        [Required(ErrorMessage = "ID is required")]
        [RegularExpression("([1-9][0-9]*)")]
        public int idProdus { get; set; }
        [Required(ErrorMessage = "ID is required")]
        [RegularExpression("([1-9][0-9]*)")]
        public int idClient { get; set; }
        [Required(ErrorMessage = "Status is required")]
        [StringLength(100)]
        public string situatiePlata { get; set; }
        [Required(ErrorMessage = "Quantity is required")]
        [Range(0, 10000, ErrorMessage = "Quantity must be between 0 and 10000 units")]
        public decimal cantitateComanda { get; set; }
    }
    public class ReadObiectComandaViewModel
    {
        public int idObiectComanda { get; set; }
        public int idComanda { get; set; }
        public int idProdus { get; set; }
        public int idClient { get; set; }
        public string situatiePlata { get; set; }
        public decimal cantitateComanda { get; set; }
    }
    public class UpdateObiectComandaViewModel
    {
        [Required(ErrorMessage = "ID is required")]
        [RegularExpression("([1-9][0-9]*)")]
        public int idObiectComanda { get; set; }
        [Required(ErrorMessage = "ID is required")]
        [RegularExpression("([1-9][0-9]*)")]
        public int idComanda { get; set; }
        [Required(ErrorMessage = "ID is required")]
        [RegularExpression("([1-9][0-9]*)")]
        public int idProdus { get; set; }
        [Required(ErrorMessage = "ID is required")]
        [RegularExpression("([1-9][0-9]*)")]
        public int idClient { get; set; }
        [Required(ErrorMessage = "Status is required")]
        [StringLength(100)]
        public string situatiePlata { get; set; }
        [Required(ErrorMessage = "Quantity is required")]
        [Range(0, 10000, ErrorMessage = "Quantity must be between 0 and 10000 units")]
        public decimal cantitateComanda { get; set; }
    }
}