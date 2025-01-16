using System;

public class EvidencaLetov {
    private List<Let> seznamLetov = new List<Let>();

    public List<Let> PridobiLete()
    {
        return seznamLetov;
    }

    public void DodajLet(Let let)
    {
        seznamLetov.Add(let);
    }

    public void IzbrisLeta(string imeLeta)
    {
        Let letZaIzbris = seznamLetov.Find(l => l.ImeLeta == imeLeta);
        if (letZaIzbris != null)
        {
            seznamLetov.Remove(letZaIzbris);
        }
    }

    public void OdpovedLeta(string imeLeta)
    {
        Let letZaOdpoved = seznamLetov.Find(l => l.ImeLeta == imeLeta);
        if (letZaOdpoved != null)
        {
            letZaOdpoved.Odpovedan = true;
        }
    }

    public void OddajPorocilo(string imeLeta, string porocilo)
    {
        Let letZaPorocilo = seznamLetov.Find(l => l.ImeLeta == imeLeta);
        if (letZaPorocilo != null)
        {
            letZaPorocilo.Porocilo = porocilo;
            Console.WriteLine($"Poroèilo za let '{imeLeta}' uspešno oddano.");
        }
        else
        {
            Console.WriteLine($"Let z imenom '{imeLeta}' ne obstaja.");
        }
    }
}
