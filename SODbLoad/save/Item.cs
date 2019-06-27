using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SODbLoadV2
{
    public class Item
    {
        
        public List<Comment> comments { get; set; }
        public List<Answer> answers { get; set; }
        public Owner owner { get; set; }
        public int comment_count { get; set; }
        public bool is_answered { get; set; }
        public int view_count { get; set; }
        public int answer_count { get; set; }
        public int score { get; set; }
        public int last_activity_date { get; set; }
        public int creation_date { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int question_id { get; set; }
        public string link { get; set; }
        public string title { get; set; }
        public int? last_edit_date { get; set; }
        public int? accepted_answer_id { get; set; }

        public string[] tags { get; set; }


    }
}
