using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace LocadoraAutomoveis.Dominio.Compartilhado
{
    public static class  EnumExtension
    {
        public static string GetDescripton(this Enum enumValue)
        {
            var field = enumValue.GetType().GetField(enumValue.ToString());

            if (Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
                return attribute.Description;

            return "Anotação não informada";
        }

    }
}
