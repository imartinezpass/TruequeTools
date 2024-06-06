﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/*
 
Esta clase establece la entidad "Trueque" y sus atributos
 
 */

namespace TruequeTools.Entities
{

    [Table("trueques")]

    public class Trueque
    {

        //ID UNIVOCO

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        //METADATA

        [Column("estado")]
        public int Estado { get; set; } = 0; //0 pendiente, -1 no concretado, 1 concretado sin ventas, 2 concretado con ventas

        [Column("productos")]
        public string? Productos { get; set; }

        //CLAVES EXTERNAS

        [Column("ofertaId")]
        public int OfertaId { get; set; }

        //ATRIBUTOS NO SQL - FOREGIN KEY FIELDS

        public Oferta? Oferta { get; set; }

    }

}