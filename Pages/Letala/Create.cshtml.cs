using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Rgis_V2.Pages.Letala
{
    public class CreateModel : PageModel
    {
        private readonly EvidencaLetal _evidencaLetal;
        private readonly DodajanjeLetalaOkno _dodajanjeLetalaOkno;

        // Constructor injection
        public CreateModel(EvidencaLetal evidencaLetal)
        {
            _evidencaLetal = evidencaLetal;
            _dodajanjeLetalaOkno = new DodajanjeLetalaOkno(_evidencaLetal);
        }

        [BindProperty]
        public string Model { get; set; }

        [BindProperty]
        public int Kapaciteta { get; set; }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) return Page();

            _dodajanjeLetalaOkno.VnesiLetalo(Model, Kapaciteta);
            return RedirectToPage("/Index");
        }
    }
}
