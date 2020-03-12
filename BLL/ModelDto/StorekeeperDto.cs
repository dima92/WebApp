namespace BLL.ModelDto
{
    public class StorekeeperDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SumKolDetail { get; set; }

        public StorekeeperDto(int id, string name, int sumKolDetail)
        {
            Id = id;
            Name = name;
            SumKolDetail = sumKolDetail;
        }
    }
}
