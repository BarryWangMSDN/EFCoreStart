using System;
using System.Collections.Generic;
using System.Text;

namespace SODbLoadV2
{
    public class Comment
    {
        public Owner owner { get; set; }
        public bool edited { get; set; }
        public int score { get; set; }
        public int creation_date { get; set; }
        public int post_id { get; set; }
        public int comment_id { get; set; }
    }
}
