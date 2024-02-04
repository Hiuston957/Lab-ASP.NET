using System;
using System.ComponentModel.DataAnnotations;
using Laboratorium3.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Laboratorium3Tests.Models
{
    [TestClass]
    public class AlbumTests
    {
        [TestMethod]
        public void Album_ValidData_ShouldPassValidation()
        {
            // Arrange
            var album = new Album
            {
                Id = 1,
                Nazwa = "Album Testowy",
                Zespol = "Zespół Testowy",
                Spis_piosenek = "Piosenka1, Piosenka2",
                Notowanie = 1,
                Data_wydania = DateTime.Now,
                Czas_trwania = 60
            };

            // Act
            var validationContext = new ValidationContext(album, null, null);
            var validationResult = new System.Collections.Generic.List<ValidationResult>();
            var isValid = Validator.TryValidateObject(album, validationContext, validationResult, true);

            // Assert
            Assert.IsTrue(isValid);
        }

        [TestMethod]
        public void Album_InvalidData_ShouldFailValidation()
        {
            // Arrange
            var album = new Album
            {
                Id = 1,
                Nazwa = null, // Invalid, as it is required
                Zespol = "Zespół Testowy",
                Spis_piosenek = "Piosenka1, Piosenka2",
                Notowanie = 0, // Invalid, as it should be greater than 0
                Data_wydania = DateTime.Now,
                Czas_trwania = -1 // Invalid, as it should be greater than 0
            };

            // Act
            var validationContext = new ValidationContext(album, null, null);
            var validationResult = new System.Collections.Generic.List<ValidationResult>();
            var isValid = Validator.TryValidateObject(album, validationContext, validationResult, true);

            // Assert
            Assert.IsFalse(isValid);
            Assert.AreEqual(3, validationResult.Count); // 3 expected validation errors
        }
    }
}
