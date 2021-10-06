using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dip.Domain
{
    public class Question
    {
        public string Title { get; set; }

        public Answer Answer { get; set; }
    }
}
