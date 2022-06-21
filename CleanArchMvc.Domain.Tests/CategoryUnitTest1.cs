using CleanArchMvc.Domain.Entities;
using FluentAssertions;
using Xunit;
using System;

namespace CleanArchMvc.Domain.Tests
{
    public class CategoryUnitTest1
    {
        [Fact(DisplayName = "Create Category Object With Valid State")]
        public void CreateCategory_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Category(1, "Category Name");
            action.Should()
                  .NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateCategory_NegativeIdValue_DomainExecptionInvalidId()
        {
            Action action = () => new Category(-1, "Category Name");
            action.Should()
                  .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                  .WithMessage("Invalid Id value");
        }

        [Fact]
        public void CreateCategory_ShotNameValue_DomainExecptionShortName()
        {
            Action action = () => new Category(1, "Ca");
            action.Should()
                  .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                  .WithMessage("Invalid name, too short, minimum 3 characters");
        }

        [Fact]
        public void CreateCategory_MissingNameValue_DomainExecptionRequiredtName()
        {
            Action action = () => new Category(1, "");
            action.Should()
                  .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateCategory_WithNullNameValue_DomainExecptionInvalidName()
        {
            Action action = () => new Category(1, String.Empty);
            action.Should()
                  .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();

        }
    }
}
