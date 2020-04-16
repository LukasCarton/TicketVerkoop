namespace TicketVerkoop.ViewModels
{
    public class MatchSectionVM
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int AvailablePlaces { get; set; }
        public double Price { get; set; }
        public int Ring { get; set; }
        public string SectionId { get; set; }
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
    }
}
