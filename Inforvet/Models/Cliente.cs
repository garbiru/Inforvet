using Inforvet.Areas.Identity.Data;

namespace Inforvet.Models
{
    public class Cliente
    {
        public string Id { get; set; }
        public List<Utente> Utentes { get; set; }
        public InforvetUser InforvetUser { get; set; }
    }
}
