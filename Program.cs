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
        int T = reservations.Max(r => r.k);

        List<Reservation>[] ending = new List<Reservation>[T + 1];
        for (int t = 0; t <= T; t++) ending[t] = new();
        foreach (var r in reservations) ending[r.k].Add(r);

        int[] Z = new int[T + 1];
        int[] picked = new int[T + 1];

        Z[0] = 0;
        picked[0] = -1;

        for (int t = 1; t <= T; t++)
        {
            Z[t] = Z[t - 1];
            picked[t] = -1;

            foreach (var r in ending[t])
            {
                if (Z[r.p] + r.z > Z[t])
                {
                    Z[t] = Z[r.p] + r.z;
                    picked[t] = r.id;
                }
            }
        }

        int cur = T;
        while (cur > 0)
        {
            if (picked[cur] != -1)
            {
                var reservation = reservations[picked[cur]];
                cur = reservation.p;
            }
            else --cur;
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

        var room1 = profit(reservations, ref excluded);
        var room2 = profit(reservations, ref excluded);

        s.Stop();
        Console.WriteLine($"Zysk:{room1 + room2}");
        Console.WriteLine($"elapsed: {s.ElapsedMilliseconds} ms");
    }
}
