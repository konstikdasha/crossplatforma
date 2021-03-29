using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MvcValue.Models
{
    public class Value
    {
        public int Id { get; set; }
        public string Title { get; set; }

        //[DataType(DataType.Date)]
        //public DateTime ReleaseDate { get; set; }
        public string Category { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

    }
}
