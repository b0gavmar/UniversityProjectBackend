namespace UniversityProjectBackend.Models
{
    public class SchoolClass
    {
        public SchoolClass(int id, string classId)
        {
            if(string.IsNullOrEmpty(classId))
            {
                throw new ArgumentException("ClassId nem lehet üres vagy null", nameof(classId));
            }
            Id = id;
            ClassId = classId;
        }

        public int Id { get; set; }
        public string ClassId { get; set; }

        public override string ToString()
        {
            return $"Osztály idje: {Id} Osztály megnevezése: {ClassId}";
        }
    }
}
