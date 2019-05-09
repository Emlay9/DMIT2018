using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Chinook.Data.Entities;
#endregion

namespace ChinookSystem.Data.Entities
{
    [Table("Tracks")]
    public class Track
    {
        private string _Composer;
        [Key]
        public int TrackId { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "Track Name is limited to 200 characters.")]
        public string Name { get; set; }

        public int? AlbumId { get; set; }

        public int MediaTypeId { get; set; }

        public int? GenreId { get; set; }

        [StringLength(220, ErrorMessage = "Composer Name is limited to 220 characters.")]
        public string Composer
        {
            get
            {
                return _Composer;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _Composer = null;
                }
                else
                {
                    _Composer = value;
                }
            }
        }

        [Range(0, 40, ErrorMessage = "Song must be greater than 0 seconds long")]
        public int Milliseconds { get; set; }

        public int? Bytes { get; set; }

        [Range(0, 200, ErrorMessage = "Unit Price must be greater than 0")]
        public decimal UnitPrice { get; set; }

        //navigational properties

        public virtual Album Album { get; set; }

        public virtual MediaType MediaType { get; set; }

        public virtual Genre Genre { get; set; }
    }
}
