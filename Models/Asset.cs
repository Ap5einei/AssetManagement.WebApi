using System;
using System.ComponentModel.DataAnnotations;

namespace AssetManagement.WebApi.Models
{
    // Tämä luokka edustaa yhtä laitetta tietokannassa
    public class Asset
    {
        [Key] // Määrittää tämän taulun pääavaimeksi (ID:n pitää olla uniikki)
        public string Id { get; set; } // Esim. "AVAIN-01"

        [Required] // Pakollinen tieto SQL-kannassa (ei saa olla tyhjä)
        [MaxLength(100)] // Tekstin maksimipituus on 100 merkkiä
        public string Name { get; set; } // Laitteen nimi

        [Required]
        public string DeviceType { get; set; } // Laitteen tyyppi (esim. Tabletti)

        [Required]
        public string Status { get; set; } // Tila (esim. "Vapaa", "Huollossa")

        // Kysymysmerkki tyypin perässä tarkoittaa, että kenttä saa olla tyhjä (null)
        public string? BorrowedBy { get; set; } // Kuka laitteen on lainannut
        
        public DateTime? ReturnDeadline { get; set; } // Milloin laite pitää palauttaa

        public DateTime LastChecked { get; set; } = DateTime.UtcNow; // Viimeisin tarkistusaika
    }
}
