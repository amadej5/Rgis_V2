using System;

public class VnosPilotaOkno
{
    private EvidencaPilotov evidencaPilotov;

    public VnosPilotaOkno(EvidencaPilotov evidenca)
    {
        evidencaPilotov = evidenca;
    }

    public void VnesiPilota(string ime, string priimek, int starost)
    {
        evidencaPilotov.NovPilot(ime, priimek, starost);
        Console.WriteLine("Pilot uspešno dodan.");
    }

    public void IzpisiPodatkeOPilotih()
    {
        foreach (var pilot in evidencaPilotov.VrniVsePilote())
        {
            Console.WriteLine($"ID: {pilot.Id}, Ime: {pilot.Ime}, Priimek: {pilot.Priimek}, Starost: {pilot.Starost}");
        }
    }

    public void Close()
    {
        Console.WriteLine("Okno za vnos pilotov zaprto.");
    }
}
