using System;
using System.Linq;

public class VnosLetaOkno {

    private EvidencaLetov _evidencaLetov;
    private EvidencaPilotov _evidencaPilotov;
    private EvidencaLetal _evidencaLetal;

    public VnosLetaOkno(EvidencaLetov evidencaLetov, EvidencaPilotov evidencaPilotov, EvidencaLetal evidencaLetal)
    {
        _evidencaLetov = evidencaLetov;
        _evidencaPilotov = evidencaPilotov;
        _evidencaLetal = evidencaLetal;
    }
    public void OddajPorociloOLetu(string imeLeta, string porocilo)
    {
        if (string.IsNullOrWhiteSpace(porocilo))
        {
            Console.WriteLine("Napaka: Poroèilo ne sme biti prazno.");
            return;
        }

        _evidencaLetov.OddajPorocilo(imeLeta, porocilo);
    }
    public void VnesiLet(string imeLeta, string letalo, string pilot)
    {
        // Validate aircraft
      

        // Validate pilot
        if (!_evidencaPilotov.VrniVsePilote().Any(p => $"{p.Ime} {p.Priimek}" == pilot))
        {
            Console.WriteLine("Napaka: Izbrani pilot ne obstaja.");
            return;
        }

      

        // Create and add the flight
        Let novLet = new Let
        {
            ImeLeta = imeLeta,
            Letalo = letalo,
            Pilot = pilot,
            Odpovedan = false
        };

        _evidencaLetov.DodajLet(novLet);
        Console.WriteLine($"Uspešno dodan let: {imeLeta}");
    }

}
