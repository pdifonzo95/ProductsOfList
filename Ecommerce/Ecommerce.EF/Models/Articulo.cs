﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Domain.Models
{
    public partial class Articulo
    {
        public int Id { get; set; }
        public int IdTipo { get; set; }
        [Required]
        [StringLength(30)]
        public string NumeroSerie { get; set; }
        [StringLength(70)]
        public string Descripcion { get; set; }
        public string Marca { get; set; }
        public int IdLote { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Precio { get; set; }
        public virtual Usuario UsuarioAdjudicado { get; set; }
        public int? IdUsuarioAdjudicado { get; set; }
        public bool Activo { get; set; }
        [ForeignKey("IdLote")]
        [InverseProperty("Articulo")]
        public virtual Lote IdLoteNavigation { get; set; }
        [ForeignKey("IdTipo")]
        [InverseProperty("Articulo")]
        public virtual ArticuloTipo IdTipoNavigation { get; set; }
        public virtual ICollection<UserArticle> UserArticles { get; set; }
        public ArticuloEstado Estado { get; set; }

        public enum ArticuloEstado
        {
            [Display(Name = "INACTIVO")]
            NOT_ENABLED = 0,
            [Display(Name = "ACTIVO")]
            ENABLED = 1,
            [Display(Name = "CERRADO")]
            CLOSED = 2
        }
    }
}