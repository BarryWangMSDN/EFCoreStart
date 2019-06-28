using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SODbLoadV2
{
    public class Comment
    {     
        public bool edited { get; set; }
        public int score { get; set; }
        public int creation_date { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int post_id { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int comment_id { get; set; }
    }
}
