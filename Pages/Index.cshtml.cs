using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Rgis_V2.Pages
{
    public class IndexModel : PageModel
    {

        public List<Let> Leti { get; set; }
        public IEnumerable<Pilot> Piloti { get; private set; }
        public List<Letalo> Letala { get; set; }


        private readonly ILogger<IndexModel> _logger;
        private readonly EvidencaLetal _evidencaLetal;
        private readonly EvidencaPilotov _evidencaPilotov;
        private readonly EvidencaLetov _evidencaLetov;



        public IndexModel(ILogger<IndexModel> logger, EvidencaLetal evidencaLetal, EvidencaPilotov evidencaPilotov, EvidencaLetov evidencaLetov)
        {
            _logger = logger;
            _evidencaLetal = evidencaLetal;
            _evidencaPilotov = evidencaPilotov;
            _evidencaLetov = evidencaLetov;



        }
       

        public void OnGet()
        {
            Letala = _evidencaLetal.VrniVsaLetala().ToList();
            Piloti = _evidencaPilotov.VrniVsePilote();
            Leti = _evidencaLetov.PridobiLete();

        }


     
    }
}