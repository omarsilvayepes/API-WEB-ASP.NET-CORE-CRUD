using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.models
{
    public class Producto

    {   [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }
        [Required,MinLength(2,ErrorMessage ="El nombre debe tener como minimo {1} caracteres"),MaxLength(50)]
        public String name { get; set; }

        [Required,Range(0,2000, ErrorMessage = "El {0} debe  estar entre {1} y {2}")]
        public int stock { get; set; }
        [Required]
        public DateTime vencimiento { get; set; }
        [Required, MinLength(2, ErrorMessage = "la {0} debe tener como minimo {1} caracteres"), MaxLength(50)]
        public String categoria { get; set; }




    }
}
