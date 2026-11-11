    internal class Videogames
    {
    public string Cim { get; set; }
    public string Mufaj { get; set; }
    public DateTime KiadasDatum { get; set; }
    public int AktivJatekosok { get; set; }
    public float Ertekeles { get; set; }

    public override string ToString() =>
        $"\tCim: {Cim}\n" +
        $"\tMűfaj: {Mufaj}\n" +
        $"\tKiadás Dátum: {KiadasDatum}\n" +
        $"\tAktív Játékosok: {AktivJatekosok} db\n" +
        $"\tErtekeles: {Ertekeles:0.0}/5.0\n";
}

