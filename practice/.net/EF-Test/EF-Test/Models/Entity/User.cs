﻿namespace EF_Test.Models.Entity
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string email { get; set; }
        public bool isEmailConfirmed { get; set; }
    }
}
