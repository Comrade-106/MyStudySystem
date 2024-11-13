﻿
using MyStudySystem.Domain.Common;

namespace MyStudySystem.Domain.Entities
{
    public class GlossaryEntry : AuditableEntity
    {
        public Guid GlossaryEntryId { get; private set; }
        public string Term { get; private set; } = string.Empty;
        public string Definition { get; private set; } = string.Empty;
        public Guid CourseId { get; private set; }

        public GlossaryEntry(string term, string definition)
        {
            GlossaryEntryId = Guid.NewGuid();
            Term = term;
            Definition = definition;
        }

        public void UpdateDefinition(string definition)
        {
            Definition = definition;
        }
    }
}