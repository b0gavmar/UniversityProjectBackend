using UniversityProjectBackend.Models;

namespace UniversityProjectBackend.Repos
{
    public class SchoolClassRepo
    {
        private List<SchoolClass> _schoolClasses = new List<SchoolClass>();
        public void Add(SchoolClass schoolClass)
        {
            if (schoolClass == null)
            {
                throw new ArgumentNullException(nameof(schoolClass), "Iskolai osztály nem lehet null");
            }
            _schoolClasses.Add(schoolClass);
        }
        public List<SchoolClass> GetAllClasses()
        {
            return _schoolClasses;
        }
        
    }
}
