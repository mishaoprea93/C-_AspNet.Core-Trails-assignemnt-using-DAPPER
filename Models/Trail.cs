using System.ComponentModel.DataAnnotations;
using System;

namespace lost_in_woods.Models{
    public class Trail{
        public int id{get;set;}
        [Required]
        public string TrailName{get;set;}
        [Required]
        [MinLength(10)]
        public string Description{get;set;}
        [Required]
        public int TrailLength{get;set;}
        [Required]
        public int Elevation{get;set;}
        [Required]
        public string Longitude{get;set;}
        [Required]
        public string Latitude{get;set;}
        public DateTime created_at{get;set;}
        public DateTime updated_at{get;set;}

    }
}