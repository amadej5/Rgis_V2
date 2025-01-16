using System.Collections.Generic;

public class EvidencaPilotov
{
    private List<Pilot> piloti; // Seznam pilotov

    public EvidencaPilotov()
    {
        piloti = new List<Pilot>();
    }

    public void NovPilot(string ime, string priimek, int starost)
    {
        var pilot = new Pilot
        {
            Id = piloti.Count + 1,
            Ime = ime,
            Priimek = priimek,
            Starost = starost
        };

        piloti.Add(pilot);
    }

    public IEnumerable<Pilot> VrniVsePilote()
    {
        return piloti;
    }
}
