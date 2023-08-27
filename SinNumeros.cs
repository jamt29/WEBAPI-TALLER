using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Ejercicio_26_07
{
    public class SinNumeros: ValidationAttribute
    {

        // Esta es la clase que implementa la lógica de validación personalizada.
        // Hereda de la clase abstracta ValidationResult.
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            // Si el valor es nulo o está vacío, la validación se considera exitosa.
            if (value == null || string.IsNullOrEmpty(value.ToString()))
                return ValidationResult.Success;

            // Convertir el valor a una cadena.
            var texto = value.ToString();

            // Verificar si el texto contiene números utilizando el método contieneNumeros.
            return contieneNumeros(texto) ? new ValidationResult("Este campo no puede incluir números") : ValidationResult.Success;
        }

        // Esta función estática verifica si una cadena contiene números utilizando una expresión regular.
        static bool contieneNumeros(string texto)
        {
            // Crear una instancia de la clase Regex para buscar dígitos numéricos (\d) en el texto.
            Regex regex = new Regex(@"\d");

            // Devolver true si se encuentra al menos un dígito numérico en el texto.
            return regex.IsMatch(texto);
        }
    }
}
