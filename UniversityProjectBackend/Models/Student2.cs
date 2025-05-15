namespace UniversityProjectBackend.Models
{
    public class Student2
    {
        public Student2(int id, string name, bool isWoman, DateTime birthDay, int schoolClassId)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Név nem lehet üres vagy null", nameof(name));
            }
            Id = id;
            Name = name;
            IsWoman = isWoman;
            BirthDay = birthDay;
            SchoolClassId = schoolClassId;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsWoman { get; set; }
        public DateTime BirthDay{ get; set; }
        public int SchoolClassId { get; set; }
    }
}
