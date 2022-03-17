using Inforvet.Areas.Identity.Data;

namespace Inforvet.Models
{
    public class Utente
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Weight { get; set; }
        public string Race { get; set; }
        public string Sex { get; set; }
        public string State { get; set; }
        public string ClienteId { get; set; }
    }
}
