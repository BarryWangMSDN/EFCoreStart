﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SODbLoad
{
    public class Item
    {
        [Key]
        public int question_id { get; set; }

        private static readonly char delimiter = ';';
        private string _tags;
        public Owner owner { get; set; }
        public bool is_answered { get; set; }
        public int view_count { get; set; }
        public int answer_count { get; set; }
        public int score { get; set; }
        public int last_activity_date { get; set; }
        public int creation_date { get; set; }
       
        public string link { get; set; }
        public string title { get; set; }
        public int? last_edit_date { get; set; }
        public int? closed_date { get; set; }
        public string closed_reason { get; set; }

        [NotMapped]
        public string[] tags
        {
            get { return _tags.Split(delimiter); }
            set
            {
                _tags = string.Join($"{delimiter}", value);
            }
        }

    }
}
