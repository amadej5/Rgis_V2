using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace Rgis_V2.Pages.VnosLeta
{
    public class CreateLetModel : PageModel
    {
        private readonly EvidencaLetov _evidencaLetov;
        private readonly EvidencaPilotov _evidencaPilotov;
        private readonly EvidencaLetal _evidencaLetal;
        private readonly VnosLetaOkno _vnosLetaOkno;

        public CreateLetModel(EvidencaLetov evidencaLetov, EvidencaPilotov evidencaPilotov, EvidencaLetal evidencaLetal)
        {
            _evidencaLetov = evidencaLetov;
            _evidencaPilotov = evidencaPilotov;
            _evidencaLetal = evidencaLetal;
            _vnosLetaOkno = new VnosLetaOkno(_evidencaLetov, _evidencaPilotov, _evidencaLetal);
        }

        [BindProperty]
        public string ImeLeta { get; set; }

        [BindProperty]
        public string Letalo { get; set; }

        [BindProperty]
        public int PilotId { get; set; } // Use PilotId for validation and selection

        public List<string> Letala { get; private set; }
        public List<Pilot> Piloti { get; private set; } // Use Pilot objects to display more details

        public void OnGet()
        {
            // Retrieve available pilots and aircraft
            Piloti = _evidencaPilotov.VrniVsePilote().ToList();
        }

        public IActionResult OnPost()
        {
            // Reload pilots and aircraft in case of validation failure
            Piloti = _evidencaPilotov.VrniVsePilote().ToList();

            if (!ModelState.IsValid)
            {
                return Page();
            }

      

            var selectedPilot = Piloti.FirstOrDefault(p => p.Id == PilotId);
            if (selectedPilot == null)
            {
                ModelState.AddModelError(nameof(PilotId), "Izbrani pilot ne obstaja.");
                return Page();
            }

            // Add the new flight
            _vnosLetaOkno.VnesiLet(ImeLeta, Letalo, $"{selectedPilot.Ime} {selectedPilot.Priimek}");
            return RedirectToPage("/Index");
        }
    }
}