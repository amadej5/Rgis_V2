using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Rgis_V2.Pages.DodajanjePilota
{
    public class CreatePilotcshtmlModel : PageModel
    {
        private readonly EvidencaPilotov _evidencaPilotov;
        private readonly VnosPilotaOkno _vnosPilotaOkno;

        public CreatePilotcshtmlModel(EvidencaPilotov evidencaPilotov)
        {
            _evidencaPilotov = evidencaPilotov;
            _vnosPilotaOkno = new VnosPilotaOkno(_evidencaPilotov);
        }

        [BindProperty]
        public string Ime { get; set; }

        [BindProperty]
        public string Priimek { get; set; }

        [BindProperty]
        public int Starost { get; set; }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _vnosPilotaOkno.VnesiPilota(Ime, Priimek, Starost);
            return RedirectToPage("/Index");
        }
    }
}
