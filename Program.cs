using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

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

    static void Main()
    {
        string[] data = File.ReadAllLines("./in/in1_full.txt");
        int n = int.Parse(data[0]);
        List<Reservation> reservations = new List<Reservation>();

        for (int i = 1; i <= n; i++)
        {
            var parts = data[i].Split(' ');
            int p = int.Parse(parts[0]);
            int k = int.Parse(parts[1]);
            int z = int.Parse(parts[2]);

            reservations.Add(new Reservation(p, k, z, i));
        }

        Stopwatch s = new Stopwatch();
        s.Start();

        (int profit_r1, List<int> r1_ids) = profit(reservations);

        List<Reservation> remaining = reservations.Where(r => !r1_ids.Contains(r.id)).ToList();

        (int profit_r2, List<int> r2_ids) = profit(remaining);

        s.Stop();

        Console.WriteLine($"out: {profit_r1 + profit_r2}");
        Console.WriteLine($"elapsed: {s.ElapsedMilliseconds} ms");
    }

    static (int, List<int>) profit(List<Reservation> reservations)
    {
        if (reservations == null || reservations.Count == 0)
            return (0, []);

        int T = reservations.Max(r => r.k);

        List<Reservation>[] ending = new List<Reservation>[T + 1];
        for (int t = 0; t <= T; t++) ending[t] = [];
        foreach (var r in reservations) ending[r.k].Add(r);

        int[] Z = new int[T + 1];
        int[] parent = new int[T + 1]; // spamiętujemy z.p z porownania nizej (Z[z.p] + z.r) 
        int[] picked = new int[T + 1];

        Z[0] = 0;
        parent[0] = -1;
        picked[0] = -1;

        for (int t = 1; t <= T; t++)
        {
            Z[t] = Z[t - 1];
            parent[t] = t - 1;
            picked[t] = -1;

            foreach (var r in ending[t])
            {
                int val = Z[r.p] + r.z;
                if (val > Z[t])
                {
                    Z[t] = val;
                    parent[t] = r.p;
                    picked[t] = r.id;
                }
            }
        }

        List<int> chosen = new();
        int cur = T;
        while (cur > 0)
        {
            if (picked[cur] != -1)
                chosen.Add(picked[cur]);
            cur = parent[cur]; // cofamy sie do z.p bo nie ma zadnych innych w czasie trwania rezerwacji wiec jest nieco szybciej
        }

        return (Z[T], chosen);
    }
}