namespace WebScraping.Entity
{
    public class Footballer
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Position { get; set; }
        public string Club { get; set; }
        public string Nationality { get; set; }
        public int Age { get; set; }

        public Footballer(int id, string fullName, string position, string club, 
                          string nationality, int age)
        {
            Id = id;
            FullName = fullName;
            Position = position;
            Club = club;
            Nationality = nationality;
            Age = age;
        }

        public override string? ToString()
        {
            return $@"{Id}. {FullName} - {Position} - {Club} - {Nationality} - {Age} age";
        }
    }
}
