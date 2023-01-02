using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPIMusic.Models
{
    public class Song
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Path { get; set; }
        public string Title { get; set; }
        public int Piste { get; set; }
        public string Artiste { get; set; }
        public string Album { get; set; }
        public SongType SongType { get; set; }  
    }
}
