using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Rgis_V2.Pages.VnosLeta
{
    public class OddajPorociloModel : PageModel
    {
        private readonly EvidencaLetov _evidencaLetov;

        public OddajPorociloModel(EvidencaLetov evidencaLetov)
        {
            _evidencaLetov = evidencaLetov;
        }

        [BindProperty]
        public string ImeLeta { get; set; }

        [BindProperty]
        public string Porocilo { get; set; }

        public List<Let> Leti { get; private set; }

        public void OnGet()
        {
            Leti = _evidencaLetov.PridobiLete();
        }

        public IActionResult OnPost()
        {
            Leti = _evidencaLetov.PridobiLete();

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _evidencaLetov.OddajPorocilo(ImeLeta, Porocilo);
            return RedirectToPage("/Index");
        }
    }
}
