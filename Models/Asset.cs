using System;
using System.ComponentModel.DataAnnotations;

namespace AssetManagement.WebApi.Models
{
    // T‰m‰ luokka edustaa yht‰ laitetta tietokannassa
    public class Asset
    {
        [Key] // M‰‰ritt‰‰ t‰m‰n taulun p‰‰avaimeksi (ID:n pit‰‰ olla uniikki)
        public string Id { get; set; } // Esim. "AVAIN-01"

        [Required] // Pakollinen tieto SQL-kannassa (ei saa olla tyhj‰)
        [MaxLength(100)] // Tekstin maksimipituus on 100 merkki‰
        public string Name { get; set; } // Laitteen nimi

        [Required]
        public string DeviceType { get; set; } // Laitteen tyyppi (esim. Tabletti)

        [Required]
        public string Status { get; set; } // Tila (esim. "Vapaa", "Huollossa")

        // Kysymysmerkki tyypin per‰ss‰ tarkoittaa, ett‰ kentt‰ saa olla tyhj‰ (null)
        public string? BorrowedBy { get; set; } // Kuka laitteen on lainannut
        
        public DateTime? ReturnDeadline { get; set; } // Milloin laite pit‰‰ palauttaa

        public DateTime LastChecked { get; set; } = DateTime.UtcNow; // Viimeisin tarkistusaika
    }
}
