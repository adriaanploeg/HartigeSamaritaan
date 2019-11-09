﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RoosterPlanner.Models;

namespace RoosterPlanner.Data.Context.Seed
{
    internal class PersonSeed : BaseSeed<Person>
    {
        //Constructor
        public PersonSeed(ModelBuilder modelBuilder) : base(modelBuilder)
        {
        }

        public override List<Person> Seed()
        {
            var persons = new List<Person>()
            {
                new Person(Guid.Parse("25E5B0E6-82EF-45FE-BBDE-EF76021EC531")) { Oid = Guid.Parse("B691F9F7-C404-4D52-A34F-C90702CA7138"), Name = "Grace Hopper", LastEditBy = "System", LastEditDate = DateTime.UtcNow },
                new Person(Guid.Parse("7F66FC12-B1C0-481F-851B-3CC1F65FD20E")) { Oid = Guid.Parse("E2A94901-6942-4CFB-83FA-60343C0DE219"), Name = "John Wick", LastEditBy = "System", LastEditDate = DateTime.UtcNow }
            };

            this.modelBuilder.Entity<Person>().HasData(persons.ToArray());

            return persons;
        }
    }
}
