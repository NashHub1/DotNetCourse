namespace HelloWorld.Models
{
    public class Computer
    {
        public string Motherboard { get; set; } = "";
        public int CPUCores { get; set; }
        public bool HasWifi { get; set; }
        public bool HasLTE { get; set; }
        public DateTime ReleaseDate { get; set; }
        public decimal Price { get; set; }
        public string VideoCard { get; set; } = "";

        // // Die String Properties dürfen nicht NUll sein bei der erstellung, warum - Keine Ahung, alternativer
        // // weg wäre das:
        
        // public Computer()
        // {
        //     if (VideoCard == null)
        //     {
        //         VideoCard = "";
        //     }
        //     if (Motherboard == null)
        //     {
        //         Motherboard = "";
        //     }
        // }

    }
}