using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sweeft.Models
{
    public class TeacherPupil
    {
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public int PupilId { get; set; }
        public Pupil Pupil { get; set; }
    }
}