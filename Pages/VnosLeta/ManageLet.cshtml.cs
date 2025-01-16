using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Rgis_V2.Pages.VnosLeta
{
    public class ManageLetModel : PageModel
    {
        private readonly EvidencaLetov _evidencaLetov;

        public ManageLetModel(EvidencaLetov evidencaLetov)
        {
            _evidencaLetov = evidencaLetov;
        }

        public List<Let> Leti => _evidencaLetov.PridobiLete();

        public IActionResult OnPostIzbris(string ime)
        {
            _evidencaLetov.IzbrisLeta(ime);
            return RedirectToPage();
        }

        public IActionResult OnPostOdpoved(string ime)
        {
            _evidencaLetov.OdpovedLeta(ime);
            return RedirectToPage();
        }
    }
}
