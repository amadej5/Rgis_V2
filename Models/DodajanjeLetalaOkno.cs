using System;


public class DodajanjeLetalaOkno {

    private EvidencaLetal evidencaLetal;

    public DodajanjeLetalaOkno(EvidencaLetal evidenca)
    {
        evidencaLetal = evidenca;
    }

    public void VnesiLetalo(string model, int kapaciteta)
    {
        evidencaLetal.NovoLetalo(model, kapaciteta);
        Console.WriteLine("Letalo uspešno dodano.");
    }

    public void IzpisiPodatkeOLetalu()
    {
        foreach (var letalo in evidencaLetal.VrniVsaLetala())
        {
            Console.WriteLine($"ID: {letalo.Id}, Model: {letalo.Model}, Kapaciteta: {letalo.Kapaciteta}");
        }
    }

    public void Close()
    {
        Console.WriteLine("Okno za dodajanje letal zaprto.");
    }

    /*public void VnesiLetalo() {
		throw new System.NotImplementedException("Not implemented");
	}
	public void IzpisiPodatkeOLetalu() {
		throw new System.NotImplementedException("Not implemented");
	}
	public void Close() {
		throw new System.NotImplementedException("Not implemented");
	}

	private EvidencaLetal dodajanje_letala;

	private GlavnoOkno glavnoOkno;*/

}
