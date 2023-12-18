using FillSign.Ds.Domain;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FillSign.Ds.Application.Commands
{
    internal class InsertDocumentCommandValidator : AbstractValidator<Document>
    {
        public InsertDocumentCommandValidator()
        {
            RuleFor(p => p.Title).NotEmpty()
                .WithMessage("Title is required.");
        }
    }
}
