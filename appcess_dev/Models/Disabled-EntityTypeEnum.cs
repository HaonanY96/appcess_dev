using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace appcess_dev.Models
{
    public enum EntityTypeEnum
    {
        App,
        File
    }

    public static class EntityTypeEnumExtensions
    {
        public static string ToDescriptionString(this EntityTypeEnum entityType)
        {
            switch (entityType)
            {
                case EntityTypeEnum.App:
                    return "APP";
                case EntityTypeEnum.File:
                    return "FILE";
                default:
                    throw new ArgumentOutOfRangeException(nameof(entityType), entityType, null);
            }
        }
    }
}
