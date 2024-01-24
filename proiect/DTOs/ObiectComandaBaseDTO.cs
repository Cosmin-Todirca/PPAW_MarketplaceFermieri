using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DTOs
{
    public class ObiectComandaBaseDTO
    {
        public int idObiectComanda { get; set; }
        public int idComanda { get; set; }
        public int idProdus { get; set; }
        public int idClient { get; set; }
        public string situatiePlata { get; set; }
        public decimal cantitateComanda { get; set; }
    }

    public class CreateObiectComandaDTO
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
    public class ReadObiectComandaDTO
    {
        public int idObiectComanda { get; set; }
        public int idComanda { get; set; }
        public int idProdus { get; set; }
        public int idClient { get; set; }
        public string situatiePlata { get; set; }
        public decimal cantitateComanda { get; set; }
    }
    public class UpdateObiectComandaDTO
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

    public class ReadObiectComandaCuProdusDTO
    {
        public int idObiectComanda { get; set; }
        public int idComanda { get; set; }
        public int idProdus { get; set; }
        public int idClient { get; set; }
        public string situatiePlata { get; set; }
        public decimal cantitateComanda { get; set; }
        public ReadProdusDTO produs { get; set; }

    }
    public class ReadObiectComandaCartDTO
    { 
        public List<ReadObiectComandaCuProdusDTO> obiecteComanda { get; set; }
        public decimal transportPrice { get; set; }
        public decimal totalDiscount { get; set; }
        public decimal totalPriceWithoutTransport { get; set; }
        public decimal totalPrice { get; set; }


    }

}
