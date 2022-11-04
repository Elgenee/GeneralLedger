using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace GeneralLedger.Core.Domain
{
    public class Agent
    {

        public Agent()
        {

        }

        public int Id { get; set; }

        [StringLength(500)]
        public string Name { get; set; }

        [Column(TypeName = "money")]
        public decimal? StartingDebit { get; set; }

        [StringLength(500)]
        public string Contact { get; set; }

        [StringLength(500)]
        public string Address { get; set; }

    }
}
