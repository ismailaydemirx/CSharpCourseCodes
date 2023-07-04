using System;

// arraylerin tipi önceden belirlendiği için, string veri tipi verdiğinde int giremezsin.
// arrayler gerçek hayat uygulamalarında bilgileri çekmek için kullanılır.
string[] students = new string[3];

students[0] = "İsmail";
students[1] = "Engin";
students[2] = "Aydemir";

string[] students2 = { "ismail", "halil", "görkem", "kerem" };

foreach (var student in students2)
{
    Console.WriteLine(student);
}

string[,] regions = new string[5, 3]
{
    { "İstanbul","İzmir","Balıkesir"},
    { "Ankara","Konya","Kırıkkale"},
    { "Antalya","Adana","Mersin"},
    { "Rize","Trabzon","Samsun"},
    { "İzmir","Muğla","Manisa"},
};

for (int i = 0; i <= regions.GetUpperBound(0); i++)
{

    for (int j = 0; j <= regions.GetUpperBound(1); j++)
    {
        Console.WriteLine(regions[i, j]);

    }
}


Console.WriteLine();
Console.ReadLine();

