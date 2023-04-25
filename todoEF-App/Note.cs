using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace todoEF_App
{
    public class Note
    {
        public int NoteId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public Colors myColor { get; set; }

        public User User { get; set; }
    }
}
