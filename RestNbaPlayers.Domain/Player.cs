namespace RestNbaPlayers.Domain
{
    public sealed class Player
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? JerseyNum { get; set; }
        public Team Team { get; set; }
        public bool? IsActive { get; set; }
    }
}