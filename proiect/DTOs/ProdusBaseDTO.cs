using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;

namespace DTOs
{
    public class ProdusBaseDTO
    {
        public int idProdus { get; set; }
        public int idVanzator { get; set; }
        public string numeProdus { get; set; }
        public string descriereProdus { get; set; }
        public decimal pret { get; set; }
        public string unitateDeMasura { get; set; }
        public decimal cantitate { get; set; }
        public string imagine { get; set; }
    }

    public class CreateProdusViewModel
    {
        [Required(ErrorMessage = "ID is required")]
        [RegularExpression("([1-9][0-9]*)")]
        public int idVanzator { get; set; }
        [Required(ErrorMessage = "Product name is required")]
        [StringLength(100)]
        public string numeProdus { get; set; }
        [StringLength(200)]
        public string descriereProdus { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(0, 10000, ErrorMessage = "Price must be between 0 and 10000 units")]
        [DataType(DataType.Currency)]
        public decimal pret { get; set; }
        [Required(ErrorMessage = "Measure unit is required")]
        [StringLength(50)]
        public string unitateDeMasura { get; set; }
        [Required(ErrorMessage = "Quantity is required")]
        [Range(0, 10000, ErrorMessage = "Quantity must be between 0 and 10000 units")]
        public decimal cantitate { get; set; }
        [StringLength(200)]
        public string imagine { get; set; }
    }

    public class ReadProdusViewModel
    {
        public int idProdus { get; set; }
        public int idVanzator { get; set; }
        public string numeProdus { get; set; }
        public string descriereProdus { get; set; }
        public decimal pret { get; set; }
        public string unitateDeMasura { get; set; }
        public decimal cantitate { get; set; }
        public string imagine { get; set; }
    }

    public class UpdateProdusViewModel
    {
        [Required(ErrorMessage = "ID is required")]
        [RegularExpression("([1-9][0-9]*)")]
        public int idProdus { get; set; }
        [Required(ErrorMessage = "ID is required")]
        [RegularExpression("([1-9][0-9]*)")]
        public int idVanzator { get; set; }
        [Required(ErrorMessage = "Product name is required")]
        [StringLength(100)]
        public string numeProdus { get; set; }
        [StringLength(200)]
        public string descriereProdus { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(0, 10000, ErrorMessage = "Price must be between 0 and 10000 units")]
        [DataType(DataType.Currency)]
        public decimal pret { get; set; }
        [Required(ErrorMessage = "Measure unit is required")]
        [StringLength(50)]
        public string unitateDeMasura { get; set; }
        [Required(ErrorMessage = "Quantity is required")]
        [Range(0, 10000, ErrorMessage = "Quantity must be between 0 and 10000 units")]
        public decimal cantitate { get; set; }
        [StringLength(200)]
        public string imagine { get; set; }
    }

    public class ReadProdusCuVanzatorViewModel
    {
        public int idProdus { get; set; }
        public int idVanzator { get; set; }
        public string numeProdus { get; set; }
        public string descriereProdus { get; set; }
        public decimal pret { get; set; }
        public string unitateDeMasura { get; set; }
        public decimal cantitate { get; set; }
        public string imagine { get; set; }
        public ReadVanzatorViewModel vanzator { get; set; }
    }

    public class CreateProdusViewModelCuDropdown
    {
        [Required(ErrorMessage = "ID is required")]
        [RegularExpression("([1-9][0-9]*)")]
        public int idVanzator { get; set; }
        [Required(ErrorMessage = "Product name is required")]
        [StringLength(100)]
        public string numeProdus { get; set; }
        [StringLength(200)]
        public string descriereProdus { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(0, 10000, ErrorMessage = "Price must be between 0 and 10000 units")]
        [DataType(DataType.Currency)]
        public decimal pret { get; set; }
        [Required(ErrorMessage = "Measure unit is required")]
        [StringLength(50)]
        public string unitateDeMasura { get; set; }
        [Required(ErrorMessage = "Quantity is required")]
        [Range(0, 10000, ErrorMessage = "Quantity must be between 0 and 10000 units")]
        public decimal cantitate { get; set; }
        [StringLength(200)]
        public string imagine { get; set; }



        public IEnumerable<SelectListItem> unitatiDeMasura
        {
            get
            {
                List<string> unitati = new List<string> { "kilogram", "bucata", "litru", "legatura" };
                return
                    unitati.Select(unitate =>
                        new SelectListItem
                        {
                            Text = unitate,
                            Value = unitate,
                            Selected = unitate.Equals(unitateDeMasura)
                        });


            }
        }
    }
}
