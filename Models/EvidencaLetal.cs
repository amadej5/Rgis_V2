using System;

public class EvidencaLetal {
    private List<Letalo> letala; // Seznam letal

    public EvidencaLetal()
    {
        letala = new List<Letalo>();
    }

    public void NovoLetalo(string model, int kapaciteta)
    {
        var letalo = new Letalo
        {
            Id = letala.Count + 1,
            Model = model,
            Kapaciteta = kapaciteta
        };

        letala.Add(letalo);
    }

    public IEnumerable<Letalo> VrniVsaLetala()
    {
        return letala;
    }

}
