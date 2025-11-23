using System.Diagnostics;

class Program
{
    struct Reservation
    {
        public int p, k, z, id;
        public Reservation(int p, int k, int z, int id)
        {
            this.p = p;
            this.k = k;
            this.z = z;
            this.id = id;
        }
    }
    static int profit(List<Reservation> reservations, ref List<int> excluded)
    {
        int T = reservations.Max(r => r.k); // najpozniej konczaca sie rezerwacja
        List<Reservation>[] ending = new List<Reservation>[T + 1]; // lista rezerwacji grupowana po ich godzinie konca
        for (int t = 0; t <= T; t++)
            ending[t] = new List<Reservation>();

        foreach (var r in reservations)
            ending[r.k].Add(r); // dla rezerwacji konczacej sie o godzinie k dodajemy to do listy na indeksie k w liscie ending

        int[] Z = new int[T + 1];
        Z[0] = 0;

        for (int t = 1; t <= T; t++) // wszystkie godziny
        {
            Z[t] = Z[t - 1];

            foreach (var r in ending[t])
            {
                if (!excluded.Contains(r.id))
                {
                    if (Z[r.p] + r.z > Z[t])
                    {
                        Z[t] = Z[r.p] + r.z;
                        // THIS IS PREMATURE, TODO FIX !!!!!!!!!!!!!!!!!!!!!!!!!!
                        excluded.Add(r.id);
                    }
                }
            }
        }
        return Z[T];
    }

    static void Main()
    {
        string[] data = File.ReadAllLines("./in/in1_full.txt");

        Stopwatch s = new();
        s.Start();

        int n = int.Parse(data[0]);
        List<Reservation> reservations = new();
        List<int> excluded = new();

        for (int i = 1; i < n + 1; i++)
        {
            string[] parts = data[i].Split(' ');

            int p = int.Parse(parts[0]);
            int k = int.Parse(parts[1]);
            int z = int.Parse(parts[2]);

            reservations.Add(new Reservation(p, k, z, i));
        }

        int pokoj1 = profit(reservations, ref excluded);
        int pokoj2 = profit(reservations, ref excluded);
        int output = pokoj1 + pokoj2;
        s.Stop();
        System.Console.WriteLine($"Zysk:{output}");
        Console.WriteLine($"elapsed: {s.ElapsedMilliseconds} ms");
    }
}
