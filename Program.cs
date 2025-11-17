class Program
{
    static int getReservations(string[] data)
    {
        int n, p, k, z;
        for (int i = 0; i < data.Length; i++)
        {
            System.Console.WriteLine(data[i]);
        }
        int.TryParse(data[0], out n);
        return 0;
    }

    static int Main(string[] args)
    {
        getReservations(File.ReadAllLines("./in/in1.txt"));
        return 0;
    }
}