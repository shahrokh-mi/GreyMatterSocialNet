﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GreyMatterSocialNet.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class GreyMatterEntities : DbContext
    {
        public GreyMatterEntities()
            : base("name=GreyMatterEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<OptionVote> OptionVotes { get; set; }
        public virtual DbSet<OutcomeVote> OutcomeVotes { get; set; }
        public virtual DbSet<Situation> Situations { get; set; }
        public virtual DbSet<SituationVote> SituationVotes { get; set; }
        public virtual DbSet<Option> Options { get; set; }
        public virtual DbSet<Outcome> Outcomes { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
}
