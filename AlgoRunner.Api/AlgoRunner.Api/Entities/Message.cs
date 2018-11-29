﻿using System;

namespace AlgoRunner.Api.Entities
{
    public class Message
    {
        public int Id { get; set; }
        public int UserID { get; set; }
        public string Title { get; set; }
        public string Context { get; set; }
        public DateTime CreateDate { get; set; }
    }
}