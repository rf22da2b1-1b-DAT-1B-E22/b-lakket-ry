// See https://aka.ms/new-console-template for more information

using b_lakket_ry.abstractDatastructures;
using b_lakket_ry.model;

IRyBiler bilKat = new RyBilerDictionary();


Console.WriteLine("Alle Biler");
ICollection<Bil> biler = bilKat.HentAlleBiler();
foreach (Bil bil in biler)
{
    Console.WriteLine(bil);
}

Console.Write("Add bil: ");
try
{
    Bil bil1 = new Bil("Lilla","AB34567",231300);
    Console.WriteLine(bil1);
    bilKat.Tilføj(bil1);
    Console.WriteLine("prøver igen");
    bilKat.Tilføj(bil1);
}catch(ArgumentException ae)
{
    Console.WriteLine(ae.Message);
}

Console.WriteLine("Alle røde biler");
ICollection<Bil> rødeBiler = bilKat.FindRødeBiler();
foreach(Bil bil in rødeBiler)
{
    Console.WriteLine(bil);
}

Console.WriteLine("bil med id = 2 hhv 1234");
try
{
    Bil fundenBil = bilKat.FindBilVedId(2);
    Console.WriteLine(fundenBil);
    fundenBil = bilKat.FindBilVedId(1234);
}catch(KeyNotFoundException knfe)
{
    Console.WriteLine(knfe.Message);
}

Console.WriteLine("bil med reg nummer = AB34567 hhv aaaabbbb");
try
{
    Bil fundenBil = bilKat.FindBilVedRegistreringsNummer("AB34567");
    Console.WriteLine(fundenBil);
    fundenBil = bilKat.FindBilVedRegistreringsNummer("aaaabbbb");
}
catch (KeyNotFoundException knfe)
{
    Console.WriteLine(knfe.Message);
}


Console.WriteLine("bil ældst");
try
{
    Bil fundenBil = bilKat.FindÆldsteBil();
    Console.WriteLine(fundenBil);
}
catch (ArgumentException ae)
{
    Console.WriteLine(ae.Message);
}

Console.WriteLine("bil nyeste");
try
{
    Bil fundenBil = bilKat.FindNyesteBil();
    Console.WriteLine(fundenBil);
}
catch (ArgumentException ae)
{
    Console.WriteLine(ae.Message);
}




