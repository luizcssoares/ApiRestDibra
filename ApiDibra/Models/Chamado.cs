using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ApiDibra.Models
{
    [Table("Chamado")]
    public class Chamado
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string descricao { get; set; }
        public DateTime dtabertura { get; set; }
        public DateTime dtencerramento { get; set; }        
    }
}