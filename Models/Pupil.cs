namespace sweeft.Models
{
    public class Pupil
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Gender { get; set; }
        public string ClassName { get; set; } = string.Empty;
        public List<TeacherPupil> TeacherPupils { get; set; }
    }
}